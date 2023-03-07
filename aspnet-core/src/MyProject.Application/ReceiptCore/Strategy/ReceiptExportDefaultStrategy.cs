using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;

using Microsoft.EntityFrameworkCore;
using MyProject.ASNCore;
using MyProject.ASNCore.DomainService;
using MyProject.ASNCore.Dtos;
using MyProject.Common.SnowflakeCommon;
using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptCore.Dtos;
using MyProject.ReceiptCore.Interface;
using MyProject.Sessions.AbpSessionExtension;
using MyProject.TableColumns;
using MyProject.TableColumns.DomainService;
using MyProject.TableColumns.Dtos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptCore.Strategy
{
    public class ReceiptExportDefaultStrategy : IReceiptExportInterface
    {

        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        //private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        //private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Receipt】领域服务
        /// </summary>

        private IWMS_ReceiptManager _wms_receiptManager;

        private readonly ICacheManager _cacheManage;

        private readonly ITable_ColumnsManager _table_ColumnsManager;

        private readonly ITable_ColumnsDetailManager _table_ColumnsDetailManager;
        ///// <summary>
        /////【WMS_ASN】领域服务
        ///// </summary>
        //private IWMS_ASNManager _wms_asnManager;
        //private readonly IObjectMapper _mapper;

        public ReceiptExportDefaultStrategy(
             IWMS_ReceiptManager wms_receiptManager,
                ICacheManager cacheManage,
                     ITable_ColumnsManager table_ColumnsManager,
                     ITable_ColumnsDetailManager table_ColumnsDetailManager
        )
        {
            _wms_receiptManager = wms_receiptManager;
            _cacheManage = cacheManage;
            _table_ColumnsManager = table_ColumnsManager;
            _table_ColumnsDetailManager = table_ColumnsDetailManager;
        }

        //默认方法不做任何处理
        public Response<DataTable> Strategy(List<long> request, IAbpSessionExtension abpSession)
        {
            Response<DataTable> response = new Response<DataTable>();
            CreateOrUpdateWMS_ReceiptInput receipts = new CreateOrUpdateWMS_ReceiptInput();
            receipts.WMS_Receipts = new List<WMS_ReceiptEditDto>();

            var headerTableColumn = GetColumns("WMS_Receipt", abpSession);
            var detailTableColumn = GetColumns("WMS_ReceiptDetail", abpSession);
            var receiptData = _wms_receiptManager.Query().Include(a => a.ReceiptDetails).Where(a => request.Contains(a.Id)).ToListAsync();
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
            ////1，构建主表需要的信息
            //foreach (var item in )
            //{
            //    if (item.IsImportColumn == 1)
            //    {
            //        dc = dt.Columns.Add(item.DisplayName, typeof(string));
            //    }
            //}
            ////2.构建明细需要的信息
            //foreach (var item in detailTableColumn)
            //{
            //    if (item.IsImportColumn == 1 && !dt.Columns.Contains(item.DisplayName))
            //    {
            //        dc = dt.Columns.Add(item.DisplayName, typeof(string));
            //    }
            //}


            //塞数据
            receiptData.Result.ForEach(a =>
            {
                DataRow row = dt.NewRow();
                Type receiptType = a.GetType();
                a.ReceiptDetails.ForEach(c =>
                {
                    Type receiptDetailType = c.GetType();
                    headerTableColumn.ForEach(h =>
                    {
                        if (h.IsImportColumn == 1 && dt.Columns.Contains(h.DisplayName))
                        {
                            PropertyInfo property = receiptType.GetProperty(h.DbColumnName);
                            //如果该字段有下拉选项，则值取下拉选项中的值
                            if (h.TableColumnsDetails.Count > 0)
                            {
                                var val = property.GetValue(a);
                                var data = h.TableColumnsDetails.Where(c => c.CodeStr == Convert.ToString(val) || c.CodeInt == Convert.ToInt32(val)).FirstOrDefault();
                                if (data != null)
                                {
                                    row[h.DisplayName] = data.Name;
                                }
                                else
                                {
                                    row[h.DisplayName] = "";
                                }
                            }
                            else
                            {
                                row[h.DisplayName] = property.GetValue(a);
                            }

                        }
                    });

                    detailTableColumn.ForEach(d =>
                      {
                          if (d.IsImportColumn == 1 && dt.Columns.Contains(d.DisplayName))
                          {
                              PropertyInfo property = receiptDetailType.GetProperty(d.DbColumnName);
                              row[d.DisplayName] = property.GetValue(c);

                          }
                      });
                });
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
                  IsImportColumn = a.IsImportColumn,
                  TableColumnsDetails = _table_ColumnsDetailManager.Query().Where(b => b.Associated == a.Associated)
              .Select(b =>
                new Table_ColumnsDetail
                {
                    Id = b.Id,
                    CodeInt = b.CodeInt,
                    CodeStr = b.CodeStr,
                    Name = b.Name,
                    Type = b.Type,
                    Color = b.Color,
                    Associated = b.Associated,
                    Status = b.Status,
                }
              ).ToList(),

              }).ToList();
        }


    }

    //public class PropertyValue<T>
    //{
    //    private static ConcurrentDictionary<string, MemberGetDelegate> _memberGetDelegate = new ConcurrentDictionary<string, MemberGetDelegate>();
    //    delegate object MemberGetDelegate(T obj);
    //    public PropertyValue(T obj)
    //    {
    //        Target = obj;
    //    }
    //    public T Target { get; private set; }
    //    public object Get(string name)
    //    {
    //        MemberGetDelegate memberGet = _memberGetDelegate.GetOrAdd(name, BuildDelegate);
    //        return memberGet(Target);
    //    }
    //    private MemberGetDelegate BuildDelegate(string name)
    //    {
    //        Type type = typeof(T);
    //        PropertyInfo property = type.GetProperty(name);
    //        return (MemberGetDelegate)Delegate.CreateDelegate(typeof(MemberGetDelegate), property.GetGetMethod());
    //    }
    //}
}