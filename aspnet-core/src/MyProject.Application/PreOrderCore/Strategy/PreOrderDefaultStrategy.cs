using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using AutoMapper;
using EFCore.BulkExtensions;
using MyProject.Common.SnowflakeCommon;
using MyProject.CommonCore;
using MyProject.CustomerCore.DomainService;
using MyProject.Dtos;
using MyProject.PreOrderCore.Dtos;
using MyProject.PreOrderCore.Enumerate;
using MyProject.PreOrderCore.Interface;
using MyProject.Sessions.AbpSessionExtension;
using MyProject.TableColumns.DomainService;
using MyProject.WarehouseCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PreOrderCore.Strategy
{
    public class PreOrderDefaultStrategy : IPreOrderInterface
    {


        /// <summary>
        ///【WMS_PreOrder】仓储层
        /// </summary>
        private readonly IRepository<WMS_PreOrder, long> _wms_preorderRepository;

        /// <summary>
        ///【WMS_PreOrderDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_PreOrderDetail, long> _wms_preorderdetailRepository;


        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;

        //private readonly ITable_ColumnsManager _table_ColumnsManager;
        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;

        public PreOrderDefaultStrategy(
            IRepository<WMS_PreOrder, long> wms_preorderRepository,
            IRepository<WMS_PreOrderDetail, long> wms_preorderdetailRepository,

            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager
            )
        {
            _wms_preorderRepository = wms_preorderRepository;
            _wms_preorderdetailRepository = wms_preorderdetailRepository;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;

        }

        //处理预出库单业务
        public Task<Response<List<OrderStatusDto>>> Strategy(List<WMS_PreOrderEditDto> request, IAbpSessionExtension abpSession)
        {
            return Task.Run(() =>
            {
                Response<List<OrderStatusDto>> response = new Response<List<OrderStatusDto>>() { Data = new List<OrderStatusDto>() };

                var asnCheck = _wms_preorderRepository.GetAll().Where(a => request.Select(r => r.ExternOrderNumber).ToList().Contains(a.ExternOrderNumber));
                if (asnCheck != null && asnCheck.ToList().Count > 0)
                {
                    asnCheck.ToList().ForEach(b =>
                    {
                        response.Data.Add(new OrderStatusDto()
                        {
                            ExternOrder = b.ExternOrderNumber,
                            SystemOrder = b.PreOrderNumber,
                            Type = b.OrderType,
                            Msg = "订单已存在"
                        });

                    });
                    response.Code = StatusCode.error;
                    response.Msg = "订单异常";
                    return response;
                }




                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<WMS_PreOrderEditDto, WMS_PreOrder>()
                       //添加创建人为当前用户
                       .ForMember(a => a.Creator, opt => opt.MapFrom(c => abpSession.UserName))
                       .ForMember(a => a.PreOrderDetails, opt => opt.MapFrom(c => c.PreOrderDetails))
                       //添加库存状态为可用
                       .ForMember(a => a.PreOrderStatus, opt => opt.MapFrom(c => PreOrderStatusEnum.新增))
                       .ForMember(a => a.CreationTime, opt => opt.MapFrom(c => DateTime.Now))
                       .ForMember(a => a.UpdateTime, opt => opt.Ignore());


                    cfg.CreateMap<WMS_PreOrderDetailEditDto, WMS_PreOrderDetail>()
                   //添加创建人为当前用户
                   .ForMember(a => a.Creator, opt => opt.MapFrom(c => abpSession.UserName))
                   .ForMember(a => a.CreationTime, opt => opt.MapFrom(c => DateTime.Now))
                   .ForMember(a => a.UpdateTime, opt => opt.Ignore());

                });

                var mapper = new Mapper(config);

                var asnData = mapper.Map<List<WMS_PreOrder>>(request);
                int LineNumber = 1;
                asnData.ForEach(item =>
                {
                    var CustomerId = _customerusermappingManager.Query().Where(b => b.CustomerName == item.CustomerName).First().CustomerId;
                    var WarehouseId = _warehouseusermappingManager.Query().Where(b => b.WarehouseName == item.WarehouseName).First().WarehouseId;
                    var PreOrderNumber = SnowFlakeHelper.GetSnowInstance().NextId().ToString();
                    item.PreOrderNumber = PreOrderNumber;
                    item.CustomerId = CustomerId;
                    item.WarehouseId = WarehouseId;
                    item.DetailCount = item.PreOrderDetails.Sum(pd => pd.OriginalQty);
                    item.PreOrderDetails.ForEach(a =>
                    {
                        a.PreOrderNumber = PreOrderNumber;
                        a.CustomerId = CustomerId;
                        a.CustomerName = item.CustomerName;
                        a.WarehouseId = WarehouseId;
                        a.WarehouseName = item.WarehouseName;
                        a.ExternOrderNumber = item.ExternOrderNumber;
                        a.LineNumber = LineNumber.ToString().PadLeft(5, '0'); 
                    });
                    LineNumber++;
                });

                //开始校验数据
                _wms_preorderRepository.GetDbContext().BulkInsert(asnData, options => options.IncludeGraph = true);
                response.Code = StatusCode.success;
                return response;
            });
        }
    }
}
