using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EFCore.BulkExtensions;
using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptCore.Enumerate;
using MyProject.ReceiptReceivingCore.Dtos;
using MyProject.ReceiptReceivingCore.Interface;
using MyProject.Sessions.AbpSessionExtension;
using MyProject.TableColumns;
using MyProject.TableColumns.DomainService;
using MyProject.WarehouseCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptReceivingCore.Strategy
{
    public class ReceiptReceivingDefaultStrategy : IReceiptReceivingInterface
    {
        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        //private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Receipt】领域服务
        /// </summary>

        private IWMS_ReceiptManager _wms_receiptManager;

        /// <summary>
        ///【WMS_ReceiptReceiving】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptReceiving, long> _wms_receiptreceivingRepository;

        private readonly ITable_ColumnsManager _table_ColumnsManager;

        /// <summary>
        ///【WMS_ReceiptDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptDetail, long> _wms_receiptdetailRepository;

        /// <summary>
        ///【WMS_Location】仓储层
        /// </summary>
        private readonly IRepository<WMS_Location, long> _wms_locationRepository;


        public ReceiptReceivingDefaultStrategy(
            IWMS_ReceiptManager wms_receiptManager,
                IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
                     ITable_ColumnsManager table_ColumnsManager,
                         IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
                           IRepository<WMS_Location, long> wms_locationRepository

        )
        {
            _wms_receiptManager = wms_receiptManager;
            _wms_receiptreceivingRepository = wms_receiptreceivingRepository;
            _table_ColumnsManager = table_ColumnsManager;
            _wms_receiptdetailRepository = wms_receiptdetailRepository;
            _wms_locationRepository = wms_locationRepository;
        }

        //默认方法不做任何处理
        public Response Strategy(dynamic request, IAbpSessionExtension abpSession)
        {
            Response response = new Response();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WMS_ReceiptDetail, WMS_ReceiptReceiving>());
            var mapper = new Mapper(config);
            //解析DataTable
            //response.Data = receipts;
            //上架方法是将 入库单的数据，按照每一行拆开添加 库区库位之后 整合数据插入到上架表
            //按照订单号，SKU,批次号，行号的方式整合数据 ：系统约定入库单每一单的最小颗粒度为 SKU+LineNumber
            List<WMS_ReceiptReceiving> receiptReceivings = new List<WMS_ReceiptReceiving>();

            //使用 一个临时变量作为缓存使用，减少数据库访问次数，且减少内存消耗
            WMS_Receipt receiptOrderTemp = new WMS_Receipt();


            foreach (var item in (request as List<WMS_ReceiptReceivingEditDto>))
            {
                if (receiptOrderTemp == null || receiptOrderTemp.ReceiptNumber != item.ReceiptNumber)
                {
                    //获取同订单下的数据作为校验
                    receiptOrderTemp = _wms_receiptManager.Query().Include(a => a.ReceiptDetails).Where(a =>
                    a.ReceiptNumber == item.ReceiptNumber).FirstOrDefaultAsync().Result;
                }
                if (receiptOrderTemp == null || string.IsNullOrEmpty(receiptOrderTemp.ReceiptNumber))
                {
                    response.Code = StatusCode.error;
                    response.Msg = "订单:" + item.ReceiptNumber + "不存在";
                    return response;
                }
                if (receiptOrderTemp.ReceiptStatus == (int)ReceiptStatusEnum.完成)
                {
                    response.Code = StatusCode.error;
                    response.Msg = "订单:" + item.ReceiptNumber + "已完成";
                    return response;
                }

                var receiptOrderLineData = receiptOrderTemp.ReceiptDetails.Where(a => a.SKU == item.SKU && a.LineNumber == item.LineNumber).FirstOrDefault();

                if (receiptOrderLineData != null)
                {

                    var dto = mapper.Map<WMS_ReceiptReceiving>(receiptOrderLineData);

                    var area = _wms_locationRepository.GetAll().Where(a => a.WarehouseId == receiptOrderLineData.WarehouseId && a.Location == item.Location).FirstOrDefault();

                    if (area == null)
                    {
                        response.Code = StatusCode.error;
                        response.Msg = "库位:" + item.Location + "在仓库：" + item.WarehouseName + "中不存在";
                        return response;
                    }

                    dto.Area = area.AreaName;
                    dto.Location = item.Location;
                    dto.ReceivedQty = item.ReceivedQty;
                    dto.ReceiptDetailId = receiptOrderLineData.Id;
                    dto.ReceiptReceivingStatus = (int)ReceiptReceivingStatusEnum.上架;
                    receiptReceivings.Add(dto);
                }
                else
                {
                    continue;
                }
            }
            //删除已经上架的明细
            _wms_receiptreceivingRepository.Delete(a => (request as List<WMS_ReceiptReceivingEditDto>).Select(b => b.ReceiptNumber).Contains(a.ReceiptNumber));
            //上架明细添加到上架表
            _wms_receiptreceivingRepository.GetDbContext().BulkInsert(receiptReceivings.ToList());
            //修改入库单的状态
            //_wms_receiptManager.Query().Where(a => (request as List<WMS_ReceiptReceivingEditDto>).Select(b => b.ReceiptNumber).Contains(a.ReceiptNumber)).BatchUpdate(new WMS_Receipt { ReceiptStatus = (int)ReceiptReceivingStatusEnum.上架 });
            _wms_receiptManager.Query().Where(a => (request as List<WMS_ReceiptReceivingEditDto>).Select(b => b.ReceiptNumber).Contains(a.ReceiptNumber)).ForEachAsync(c =>
            {
                c.ReceiptStatus = (int)ReceiptReceivingStatusEnum.上架;
                _wms_receiptManager.UpdateAsync(c);
            });

            //.BatchUpdate(new WMS_Receipt { ReceiptStatus = (int)ReceiptReceivingStatusEnum.上架 });
            //修改入库单的上架数量
            //_wms_receiptdetailRepository.GetAll().Where(a => request.Contains(a.Id)).BatchUpdate(a => new WMS_ReceiptDetail { ReceivedQty = _wms_receiptreceivingRepository.GetAll().Where(re => re.ReceiptDetailId == a.Id).Sum(c => c.ReceivedQty) });

            response.Code = StatusCode.success;
            //throw new NotImplementedException();
            return response;
        }


        //private List<Table_Columns> GetColumns(string TableName, IAbpSessionExtension abpSession)
        //{
        //    return _table_ColumnsManager.Query()
        //       .Where(a => a.TableName == TableName &&
        //         a.RoleName == abpSession.RoleName &&
        //         a.IsImportColumn == 1
        //       )
        //      .Select(a => new Table_Columns
        //      {
        //          DisplayName = a.DisplayName,
        //          DbColumnName = a.DbColumnName,
        //          IsImportColumn = a.IsImportColumn
        //      }).ToList();
        //}
    }
}