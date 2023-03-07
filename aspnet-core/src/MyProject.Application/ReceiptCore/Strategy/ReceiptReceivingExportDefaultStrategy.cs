using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using MyProject.ASNCore;
using MyProject.ASNCore.DomainService;
using MyProject.ASNCore.Dtos;
using MyProject.Common.SnowflakeCommon;
using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptCore.Dtos;
using MyProject.ReceiptCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore.Repositories;
using MyProject.Sessions.AbpSessionExtension;
using EFCore.BulkExtensions;
using MyProject.ReceiptCore.Enumerate;
using MyProject.ASNCore.Enumerate;
using MyProject.ReceiptReceivingCore;
using AutoMapper;
using Abp.Runtime.Caching;
using MyProject.TableColumns.DomainService;
using MyProject.TableColumns;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MyProject.InventoryCore;

namespace MyProject.ReceiptCore.Strategy
{

    public class ReceiptReceivingExportDefaultStrategy : IReceiptReceivingExportInterface
    {
        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Receipt】领域服务
        /// </summary>

        //private IWMS_ReceiptManager _wms_receiptManager;

        /// <summary>
        ///【WMS_ReceiptDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptDetail, long> _wms_receiptdetailRepository;
        /// <summary>
        ///【WMS_ReceiptReceiving】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptReceiving, long> _wms_receiptreceivingRepository;

        /// <summary>
        ///【WMS_Inventory_Usable】仓储层
        /// </summary>
        private readonly IRepository<WMS_Inventory_Usable, long> _wms_inventory_usableRepository;

        private readonly ICacheManager _cacheManage;

        private readonly ITable_ColumnsManager _table_ColumnsManager;


        public ReceiptReceivingExportDefaultStrategy(
            IRepository<WMS_Receipt, long> wms_receiptRepository,
            IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
            IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
            IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
            ICacheManager cacheManage, ITable_ColumnsManager table_ColumnsManager
        )
        {
            _wms_receiptRepository = wms_receiptRepository;
            _wms_receiptdetailRepository = wms_receiptdetailRepository;
            _wms_receiptreceivingRepository = wms_receiptreceivingRepository;
            _wms_inventory_usableRepository = wms_inventory_usableRepository;
            _cacheManage = cacheManage;
            _table_ColumnsManager = table_ColumnsManager;

        }

        //默认方法不做任何处理
        public Response<DataTable> Strategy(List<long> request, IAbpSessionExtension abpSession)
        {

            Response<DataTable> response = new Response<DataTable>();
            CreateOrUpdateWMS_ReceiptInput receipts = new CreateOrUpdateWMS_ReceiptInput();
            receipts.WMS_Receipts = new List<WMS_ReceiptEditDto>();

            var headerTableColumn = GetColumns("WMS_Receipt", abpSession);
            var detailTableColumn = GetColumns("WMS_ReceiptReceiving", abpSession);
            var receiptData = _wms_receiptRepository.GetAllIncluding(a => a.ReceiptDetails, a => a.ReceiptReceivings).Where(a => request.Contains(a.Id)).ToListAsync();
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            //1，构建主表需要的信息
            headerTableColumn.ForEach(a =>
            {
                if (a.IsImportColumn == 1)
                {
                    dc = dt.Columns.Add(a.DisplayName, typeof(string));
                }
            });
            //2.构建明细需要的信息
            detailTableColumn.ForEach(a =>
            {
                if (a.IsImportColumn == 1 && !dt.Columns.Contains(a.DisplayName))
                {
                    dc = dt.Columns.Add(a.DisplayName, typeof(string));
                }
            });

            //塞数据
            receiptData.Result.ForEach(a =>
            {
                DataRow row = dt.NewRow();
                //判断是采用上架表数据，还是使用入库明细数据(上架表有数据，就采用上架表数据，否则采用入库明细数据)
                //采用入库明细数据需要推荐上架库位
                Type receiptType = a.GetType();
                if (a.ReceiptReceivings == null || a.ReceiptReceivings.Count==0)
                {
                    a.ReceiptDetails.ForEach(c =>
                    {

                        Type receiptDetailType = c.GetType();
                        headerTableColumn.ForEach(h =>
                        {
                            if (h.IsImportColumn == 1 && dt.Columns.Contains(h.DisplayName))
                            {
                                PropertyInfo property = receiptType.GetProperty(h.DbColumnName);
                                if (property != null)
                                {
                                    row[h.DisplayName] = property.GetValue(a);
                                }
                                else
                                {
                                    //判断是库位 ，获取推荐库位
                                    if (h.DbColumnName == "Location")
                                    {
                                        var LocationData = _wms_inventory_usableRepository.GetAll().Where(i => i.CustomerId == a.CustomerId && i.WarehouseId == a.WarehouseId && i.SKU == c.SKU).GroupBy(i => i.Location).OrderBy(i => i.Sum(d => d.Qty)).FirstOrDefaultAsync();
                                        if (LocationData == null)
                                        {
                                            row[h.DisplayName] = "";
                                        }
                                        else {
                                            row[h.DisplayName] = LocationData.Result.Key;
                                        }
                                        
                                    }
                                    else
                                    {
                                        row[h.DisplayName] = "";
                                    }
                                }
                            }
                        });

                        detailTableColumn.ForEach(d =>
                        {
                            if (d.IsImportColumn == 1 && dt.Columns.Contains(d.DisplayName))
                            {
                                PropertyInfo property = receiptDetailType.GetProperty(d.DbColumnName);
                                if (property != null)
                                {
                                    row[d.DisplayName] = property.GetValue(c);
                                }
                                else
                                {
                                    row[d.DisplayName] = "";
                                }

                            }
                        });
                    });
                }
                else
                {
                    a.ReceiptReceivings.ForEach(c =>
                    {
                        Type receiptReceivingType = c.GetType();
                        headerTableColumn.ForEach(h =>
                        {
                            if (h.IsImportColumn == 1 && dt.Columns.Contains(h.DisplayName))
                            {
                                PropertyInfo property = receiptType.GetProperty(h.DbColumnName);
                                if (property != null)
                                {
                                    row[h.DisplayName] = property.GetValue(a);
                                }
                                else
                                {
                                    row[h.DisplayName] = "";
                                }
                            }
                        });

                        detailTableColumn.ForEach(d =>
                        {
                            if (d.IsImportColumn == 1 && dt.Columns.Contains(d.DisplayName))
                            {
                                PropertyInfo property = receiptReceivingType.GetProperty(d.DbColumnName);
                                if (property != null)
                                {
                                    row[d.DisplayName] = property.GetValue(c);
                                }
                                else
                                {
                                    row[d.DisplayName] = "";
                                }

                            }
                        });
                    });
                }
                dt.Rows.Add(row);

            });
            response.Data = dt;
            response.Code = StatusCode.success;
            //throw new NotImplementedException();
            return response;
        }


        private List<Table_Columns> GetColumns(string TableName, IAbpSessionExtension abpSession)
        {
            return _table_ColumnsManager.Query()
               .Where(a => a.TableName == TableName &&
                 a.RoleName == abpSession.RoleName &&
                 a.IsImportColumn == 1
               )
              .Select(a => new Table_Columns
              {
                  DisplayName = a.DisplayName,
                  //由于框架约定大于配置， 数据库的字段首字母小写
                  //DbColumnName = a.DbColumnName.Substring(0, 1).ToLower() + a.DbColumnName.Substring(1)
                  DbColumnName = a.DbColumnName,
                  IsImportColumn = a.IsImportColumn
              }).ToList();
        }
    }
}