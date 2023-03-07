using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using AutoMapper;
using EFCore.BulkExtensions;
using MyProject.ASNCore.Dtos;
using MyProject.ASNCore.Enumerate;
using MyProject.ASNCore.Interface;
using MyProject.Common.SnowflakeCommon;
using MyProject.CommonCore;
using MyProject.CustomerCore.DomainService;
using MyProject.Dtos;
using MyProject.InventoryCore.Enumerate;
using MyProject.Sessions.AbpSessionExtension;
using MyProject.WarehouseCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ASNCore.Strategy
{
    public class ASNDefaultStrategy : IASNInterface
    {


        /// <summary>
        ///【WMS_ASN】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASN, long> _wms_asnRepository;
        /// <summary>
        ///【WMS_ASNDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASNDetail, long> _wms_asndetailRepository;



        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;


        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;
        public ASNDefaultStrategy(
            IRepository<WMS_ASN, long> wms_asnRepository,
            IRepository<WMS_ASNDetail, long> wms_asndetailRepository,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager
        )
        {
            _wms_asnRepository = wms_asnRepository;
            _wms_asndetailRepository = wms_asndetailRepository;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;
        }



        /// <summary>
        /// 默认方法不做任何处理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<List<OrderStatusDto>> Strategy(List<WMS_ASNEditDto> request, IAbpSessionExtension abpSession)
        {
            Response<List<OrderStatusDto>> response = new Response<List<OrderStatusDto>>() { Data = new List<OrderStatusDto>() };

            //开始校验数据
            //List<OrderStatusDto> orderStatus = new List<OrderStatusDto>();
            //1判断PreOrder 是否已经存在已有的订单

            var asnCheck = _wms_asnRepository.GetAll().Where(a => request.Select(r => r.ExternReceiptNumber).ToList().Contains(a.ExternReceiptNumber));
            if (asnCheck != null && asnCheck.ToList().Count > 0)
            {
                asnCheck.ToList().ForEach(b =>
                {
                    response.Data.Add(new OrderStatusDto()
                    {
                        ExternOrder = b.ExternReceiptNumber,
                        SystemOrder = b.ASNNumber,
                        Type = b.ReceiptType,
                        StatusCode = StatusCode.warning,
                        //StatusMsg = StatusCode.warning.ToString(),
                        Msg = "订单已存在"
                    });

                });
                response.Code = StatusCode.error;
                response.Msg = "订单异常";
                return response;
            }


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WMS_ASNEditDto, WMS_ASN>()
                   //添加创建人为当前用户
                   .ForMember(a => a.Creator, opt => opt.MapFrom(c => abpSession.UserName))
                   .ForMember(a => a.ASNDetails, opt => opt.MapFrom(c => c.ASNDetails))
                   //添加库存状态为可用
                   .ForMember(a => a.ASNStatus, opt => opt.MapFrom(c => ASNStatusEnum.新增))
                   .ForMember(a => a.CreationTime, opt => opt.MapFrom(c => DateTime.Now))
                   .ForMember(a => a.UpdateTime, opt => opt.Ignore())
                   .ForMember(a => a.CompleteTime, opt => opt.Ignore());
                cfg.CreateMap<WMS_ASNDetailEditDto, WMS_ASNDetail>()
               //添加创建人为当前用户
               .ForMember(a => a.Creator, opt => opt.MapFrom(c => abpSession.UserName))
               .ForMember(a => a.CreationTime, opt => opt.MapFrom(c => DateTime.Now))
               .ForMember(a => a.UpdateTime, opt => opt.Ignore());

            });

            var mapper = new Mapper(config);

            var asnData = mapper.Map<List<WMS_ASN>>(request);
            int LineNumber = 1;
            asnData.ForEach(item =>
            {
                var CustomerId = _customerusermappingManager.Query().Where(b => b.CustomerName == item.CustomerName).First().CustomerId;
                var WarehouseId = _warehouseusermappingManager.Query().Where(b => b.WarehouseName == item.WarehouseName).First().WarehouseId;
                var ASNNumber = SnowFlakeHelper.GetSnowInstance().NextId().ToString();
                item.ASNNumber = ASNNumber;
                item.CustomerId = CustomerId;
                item.WarehouseId = WarehouseId;
                item.ASNDetails.ForEach(a =>
                {
                    a.ASNNumber = ASNNumber;
                    a.CustomerId = CustomerId;
                    a.CustomerName = item.CustomerName;
                    a.WarehouseId = WarehouseId;
                    a.WarehouseName = item.WarehouseName;
                    a.ExternReceiptNumber = item.ExternReceiptNumber;
                    a.LineNumber = LineNumber.ToString().PadLeft(5, '0');
                });
                LineNumber++;
            });

            //开始插入订单
            _wms_asnRepository.GetDbContext().BulkInsert(asnData, options => options.IncludeGraph = true);
            asnData.ToList().ForEach(b =>
            {
                response.Data.Add(new OrderStatusDto()
                {
                    ExternOrder = b.ExternReceiptNumber,
                    SystemOrder = b.ASNNumber,
                    Type = b.ReceiptType,
                    StatusCode = StatusCode.success,
                    //StatusMsg = StatusCode.warning.ToString(),
                    Msg = "订单新增成功"
                });

            });
            response.Code = StatusCode.success;
            return response;

        }
    }
}
