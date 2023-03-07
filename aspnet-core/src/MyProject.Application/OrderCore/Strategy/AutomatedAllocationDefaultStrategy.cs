using Abp.Domain.Repositories;
using MyProject.CommonCore;
using MyProject.CustomerCore.DomainService;
using MyProject.Dtos;
using MyProject.InventoryCore;
using MyProject.OrderCore.Interface;
using MyProject.PreOrderCore;
using MyProject.Sessions.AbpSessionExtension;
using MyProject.WarehouseCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.OrderCore.Strategy
{
    public class AutomatedAllocationDefaultStrategy : IAutomatedAllocationInterface
    {
 




        /// <summary>
		///【WMS_Order】仓储层
		/// </summary>
		private readonly IRepository<WMS_Order, long> _wms_orderRepository;

        /// <summary>
		///【WMS_OrderDetail】仓储层
		/// </summary>
		private readonly IRepository<WMS_OrderDetail, long> _wms_orderdetailRepository;
        //private readonly ITable_ColumnsManager _table_ColumnsManager;
        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;


        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;
        /// <summary>
        ///【WMS_Inventory_Usable】仓储层
        /// </summary>
        private readonly IRepository<WMS_Inventory_Usable, long> _wms_inventory_usableRepository;

        public AutomatedAllocationDefaultStrategy(
            IRepository<WMS_Order, long> wms_orderRepository,
            IRepository<WMS_OrderDetail, long> wms_orderdetailRepository,
            IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager
            )
        { 
            _wms_orderRepository = wms_orderRepository;
            _wms_orderdetailRepository = wms_orderdetailRepository;
            _wms_inventory_usableRepository = wms_inventory_usableRepository;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;

        }

        //处理预出库单业务
        public Task<Response<List<OrderStatusDto>>> Strategy(List<long> request, IAbpSessionExtension abpSession)
        {
            return Task.Run(() =>
            {
                Response<List<OrderStatusDto>> response = new Response<List<OrderStatusDto>>() { Data = new List<OrderStatusDto>() };

                //var preOrderData = _wms_preorderRepository.GetAll().Where(a => request.Contains(a.Id));
                //if (preOrderData != null && preOrderData.ToList().Count > 0)
                //{
                //    preOrderData.ToList().ForEach(b =>
                //    {
                //        if (b.PreOrderStatus >= (int)PreOrderStatusEnum.转出库)
                //            response.Data.Add(new OrderStatusDto()
                //            {
                //                Id = b.Id,
                //                ExternOrder = b.ExternOrderNumber,
                //                SystemOrder = b.PreOrderNumber,
                //                Type = b.OrderType,
                //                StatusCode = StatusCode.warning,
                //                //StatusMsg = (string)StatusCode.warning,
                //                Msg = "订单状态异常"
                //            });

                //    });
                //    response.Code = StatusCode.error;
                //    response.Msg = "订单异常";
                //    return response;
                //}



                //将需要分配的订单发送到分配队列
                //分配队列按照客户ID+仓库ID创建

                //获取需要分配的订单，采用自动分配
                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<WMS_PreOrder, WMS_Order>()
                //         .ForMember(a => a.PreOrderId, opt => opt.MapFrom(c => c.Id))
                //         //添加创建人为当前用户
                //         .ForMember(a => a.Creator, opt => opt.MapFrom(c => abpSession.UserName))
                //         .ForMember(a => a.OrderDetails, opt => opt.MapFrom(c => c.PreOrderDetails))
                //         //添加库存状态为可用
                //         .ForMember(a => a.OrderStatus, opt => opt.MapFrom(c => OrderStatusEnum.待处理))
                //         .ForMember(a => a.CreationTime, opt => opt.MapFrom(c => DateTime.Now))
                //         //忽略修改时间
                //         .ForMember(a => a.UpdateTime, opt => opt.Ignore())
                //         .ForMember(a => a.CompleteTime, opt => opt.Ignore());


                //    cfg.CreateMap<WMS_PreOrderDetail, WMS_OrderDetail>()
                //   .ForMember(a => a.PreOrderDetailId, opt => opt.MapFrom(c => c.Id))
                //   //添加创建人为当前用户
                //   .ForMember(a => a.Creator, opt => opt.MapFrom(c => abpSession.UserName))
                //   .ForMember(a => a.CreationTime, opt => opt.MapFrom(c => DateTime.Now))
                //   //忽略修改时间
                //   .ForMember(a => a.UpdateTime, opt => opt.Ignore());

                //});

                //preOrderData.ToList().ForEach(a =>
                //{
                //    //声明分配后需要插入的库存
                //    List<WMS_Inventory_Usable> invs = new List<WMS_Inventory_Usable>();
                //    //声明分配后需要插入的出库明细
                //    List<WMS_OrderDetail> ods = new List<WMS_OrderDetail>();
                //    if (a.PreOrderStatus == (int)PreOrderStatusEnum.新增)
                //    {
                //        //判断订单数量足不足够分配
                //        var iCheck=



                //        //获取明细
                //        a.PreOrderDetails.ForEach(pd =>
                //        {
                //            //获取可用库存
                //            var inventory = _wms_inventory_usableRepository.GetAll()
                //                //必须的条件
                //                .Where(i =>
                //                i.CustomerId == pd.CustomerId &&
                //                i.WarehouseId == pd.WarehouseId &&
                //                i.SKU == pd.SKU &&
                //                i.InventoryStatus == (int)InventoryStatusEnum.可用
                //                )
                //                //可选的条件 UPC
                //                .WhereIf(!pd.UPC.IsNullOrWhiteSpace(), a => a.UPC == pd.UPC)
                //                //可选的条件 UnitCode
                //                .WhereIf(!pd.UnitCode.IsNullOrWhiteSpace(), a => a.UnitCode == pd.UnitCode)
                //                //可选的条件 Onwer
                //                .WhereIf(!pd.Onwer.IsNullOrWhiteSpace(), a => a.Onwer == pd.Onwer)
                //                //可选的条件 BoxCode
                //                .WhereIf(!pd.BoxCode.IsNullOrWhiteSpace(), a => a.BoxCode == pd.BoxCode)
                //                //可选的条件 TrayCode
                //                .WhereIf(!pd.TrayCode.IsNullOrWhiteSpace(), a => a.TrayCode == pd.TrayCode)
                //                //可选的条件 BatchCode
                //                .WhereIf(!pd.BatchCode.IsNullOrWhiteSpace(), a => a.BatchCode == pd.BatchCode);
                //            if (inventory.Any() && inventory.Sum(i => i.Qty) > pd.AllocatedQty)
                //            {
                //                inventory.ToList().ForEach(iv =>
                //                {
                //                    //这利分为两部分，
                //                    //1部分是当前行库存满足分配要求，
                //                    //2部分是当前行库存不满足分配要求，
                //                    if (iv.Qty >= pd.AllocatedQty)
                //                    {

                //                    }

                //                });
                //            }
                //            else
                //            {

                //            }


                //        });

                //    }

                //});




                //var mapper = new Mapper(config);

                //var asnData = mapper.Map<List<WMS_Order>>(preOrderData);
                //int LineNumber = 1;
                //asnData.ForEach(item =>
                //{
                //    //var CustomerId = _customerusermappingManager.Query().Where(b => b.CustomerName == item.CustomerName).First().CustomerId;
                //    //var WarehouseId = _warehouseusermappingManager.Query().Where(b => b.WarehouseName == item.WarehouseName).First().WarehouseId;
                //    var OrderNumber = SnowFlakeHelper.GetSnowInstance().NextId().ToString();
                //    item.OrderNumber = OrderNumber;
                //    //item.CustomerId = CustomerId;
                //    //item.WarehouseId = WarehouseId;
                //    //item.DetailCount = item.OrderDetails.Sum(pd => pd.OriginalQty);
                //    item.OrderDetails.ForEach(a =>
                //    {
                //        a.OrderNumber = OrderNumber;
                //        //a.CustomerId = CustomerId;
                //        //a.CustomerName = item.CustomerName;
                //        //a.WarehouseId = WarehouseId;
                //        //a.WarehouseName = item.WarehouseName;
                //        a.ExternOrderNumber = item.ExternOrderNumber;
                //        a.LineNumber = LineNumber.ToString().PadLeft(5, '0');
                //    });
                //    LineNumber++;
                //});

                //开始校验数据
                //_wms_preorderRepository.GetDbContext().BulkInsert(asnData, options => options.IncludeGraph = true);
                response.Code = StatusCode.success;
                return response;
            });
        }
    }
}
