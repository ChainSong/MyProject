using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Runtime.Session;
using AutoMapper;
using EFCore.BulkExtensions;
using MyProject.ASNCore;
using MyProject.ASNCore.DomainService;
using MyProject.ASNCore.Dtos;
using MyProject.Common.SnowflakeCommon;
using MyProject.CommonCore;
using MyProject.Dtos;
using MyProject.InventoryCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptCore.Dtos;
using MyProject.ReceiptCore.Enumerate;
using MyProject.ReceiptCore.Interface;
using MyProject.ReceiptReceivingCore;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using MyProject.ASNCore.Enumerate;
using MyProject.InventoryCore.Enumerate;

namespace MyProject.ReceiptCore.Strategy
{
    public class ReceiptInventoryDefaultStrategy : IReceiptInventoryInterface
    {
        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Inventory_Usable】仓储层
        /// </summary>
        private readonly IRepository<WMS_Inventory_Usable, long> _wms_inventory_usableRepository;

        /// <summary>
        ///【WMS_ReceiptReceiving】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptReceiving, long> _wms_receiptreceivingRepository;

        /// <summary>
        ///【WMS_ReceiptDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptDetail, long> _wms_receiptdetailRepository;

        /// <summary>
        ///【WMS_ReceiptReceiving】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASNDetail, long> _wms_asndetailRepository;

        /// <summary>
        ///【WMS_ASN】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASN, long> _wms_asnRepository;

        public ReceiptInventoryDefaultStrategy(
          IRepository<WMS_ASN, long> wms_asnRepository,
          IRepository<WMS_ASNDetail, long> wms_asndetailRepository,
          IRepository<WMS_Receipt, long> wms_receiptRepository,
          IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
          IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
          IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository

        )
        {
            _wms_receiptRepository = wms_receiptRepository;
            _wms_inventory_usableRepository = wms_inventory_usableRepository;
            _wms_receiptreceivingRepository = wms_receiptreceivingRepository;
            _wms_receiptdetailRepository = wms_receiptdetailRepository;
            _wms_asnRepository = wms_asnRepository;
            _wms_asndetailRepository = wms_asndetailRepository;
        }

        //默认方法不做任何处理
        public Response<List<OrderStatusDto>> Strategy(List<long> request, IAbpSessionExtension abpSession)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WMS_ReceiptReceiving, WMS_Inventory_Usable>()
                //自定义投影，将上架表ID 投影到库存表中
                .ForMember(a => a.ReceiptReceivingId, opt => opt.MapFrom(c => c.Id))
                //添加创建人为当前用户
                .ForMember(a => a.Creator, opt => opt.MapFrom(c => abpSession.UserName))
                //创建时间
                .ForMember(a => a.CreationTime, opt => opt.MapFrom(c => DateTime.Now))
                //库龄
                .ForMember(a => a.InventoryTime, opt => opt.MapFrom(c => DateTime.Now))
                //数量
                .ForMember(a => a.Qty, opt => opt.MapFrom(c => c.ReceivedQty))
                //添加库存状态为可用
                .ForMember(a => a.InventoryStatus, opt => opt.MapFrom(c => InventoryStatusEnum.可用))
                //忽略需要转换的字段
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.Updator, opt => opt.Ignore())
                .ForMember(a => a.UpdateTime, opt => opt.Ignore())
                );
            var mapper = new Mapper(config);
            Response<List<OrderStatusDto>> response = new Response<List<OrderStatusDto>>() { Data = new List<OrderStatusDto>() };
            List<OrderStatusDto> orderStatuses = new List<OrderStatusDto>();
            //List<WMS_ReceiptDetail> receiptDetails = new List<WMS_ReceiptDetail>();

            //receipts.WMS_Receipts = new List<WMS_ReceiptEditDto>();
            //判断receipts  是否可以转入库单
            List<WMS_Inventory_Usable> inventory = new List<WMS_Inventory_Usable>();

            request.ForEach(a =>
            {
                //判断上架单和入库单数量是否一致，一致就加入库存
                var receipt = _wms_receiptRepository.GetAllIncluding(b => b.ReceiptDetails, b => b.ReceiptReceivings).Where(b => b.Id == a).FirstOrDefault();
                if (receipt != null && receipt.ReceiptStatus == (int)ReceiptStatusEnum.上架)
                {
                    //var receiptreceiving = _wms_receiptreceivingRepository.GetAll().Where(b => b.ReceiptId == a).ToList();
                    if (receipt.ReceiptDetails.Sum(r => r.ReceivedQty) == receipt.ReceiptReceivings.Sum(r => r.ReceivedQty))
                    {
                        var inventoryData = mapper.Map<List<WMS_Inventory_Usable>>(receipt.ReceiptReceivings);
                        //inventory.AddRange(inventoryData);
                        //添加到库存表
                        _wms_inventory_usableRepository.GetDbContext().BulkInsert(inventoryData);
                        //修改入库单状态
                        _wms_receiptRepository.GetAll().Where(a => a.Id == receipt.Id).BatchUpdate(new WMS_Receipt { ReceiptStatus = (int)ReceiptStatusEnum.完成, CompleteTime = DateTime.Now });
                        //修改入库单明细中的入库数量
                        //_wms_receiptdetailRepository.GetDbContext().BulkUpdate();
                        _wms_receiptdetailRepository.GetAll().Where(a => a.ReceiptId == receipt.Id).ToList().ForEach(e =>
                         {
                             e.ReceivedQty = _wms_receiptreceivingRepository.GetAll().Where(re => re.ReceiptDetailId == e.Id).Sum(c => c.ReceivedQty);
                             e.Updator = abpSession.UserName;
                             e.UpdateTime = DateTime.Now;
                             _wms_receiptdetailRepository.Update(e);
                         });

                        //修改上架表中的状态
                        _wms_receiptreceivingRepository.GetAll().Where(a => request.Contains(a.ReceiptId)).BatchUpdate(new WMS_ReceiptReceiving { ReceiptReceivingStatus = (int)ReceiptStatusEnum.完成, Updator = abpSession.UserName, UpdateTime = DateTime.Now });
                        //修改ASN 状态
                        _wms_asnRepository.GetAll().Where(a => a.Id == receipt.ASNId).BatchUpdate(new WMS_ASN { ASNStatus = (int)ASNStatusEnum.完成, CompleteTime = DateTime.Now });
                        //修改ASN 明细中的实际入库数量
                        //_wms_asndetailRepository.GetAll().Where(a => request.Contains(a.Id)).BatchUpdate(v =>new WMS_ASNDetail{ ReceivedQty = _wms_receiptreceivingRepository.GetAll().Where(re => re.ASNDetailId == v.Id).Sum(c => c.ReceivedQty)});
                        _wms_asndetailRepository.GetAll().Where(a => a.ASNId == receipt.ASNId).ToList().ForEach(e =>
                        {
                            e.ReceivedQty = _wms_receiptreceivingRepository.GetAll().Where(re => re.ASNDetailId == e.Id).Sum(c => c.ReceivedQty);
                            e.Updator = abpSession.UserName;
                            e.UpdateTime = DateTime.Now;
                            _wms_asndetailRepository.Update(e);
                        });
                        orderStatuses.Add(new OrderStatusDto()
                        {
                            Id = a,
                            ExternOrder = receipt.ExternReceiptNumber,
                            SystemOrder = receipt.ReceiptNumber,
                            StatusCode = StatusCode.success,
                            //StatusMsg = StatusCode.success.ToString(),
                            Msg = "订单添加成功"
                        });
                    }
                    else
                    {
                        orderStatuses.Add(new OrderStatusDto() { 
                            Id = a, ExternOrder = receipt.ExternReceiptNumber, 
                            SystemOrder = receipt.ReceiptNumber,
                            StatusCode = StatusCode.error,
                            //StatusMsg = StatusCode.error.ToString(), 
                            Msg = "请检查订单数量" });
                    }
                }
                else if (receipt.ReceiptStatus != (int)ReceiptStatusEnum.上架)
                {
                    orderStatuses.Add(new OrderStatusDto() { 
                        Id = a, ExternOrder = receipt.ExternReceiptNumber, 
                        SystemOrder = receipt.ReceiptNumber,
                        StatusCode = StatusCode.error,
                        //StatusMsg = StatusCode.error.ToString(),
                        Msg = "请检查订单状态" });
                }
            });

            response.Data = orderStatuses;
            response.Code = StatusCode.success;
            //throw new NotImplementedException();
            return response;
        }
    }
}