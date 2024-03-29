
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos;
using MyProject.OrderCore;
using MyProject.OrderCore.Dtos;
using MyProject.OrderCore.DomainService;

using MyProject.Authorization;
using MyProject.OrderCore.Interface;
using MyProject.OrderCore.Factory;
using MyProject.CustomerCore.DomainService;
using MyProject.InventoryCore;
using DotNetCore.CAP;
using MyProject.TableColumns.DomainService;
using MyProject.PreOrderCore;
using MyProject.WarehouseCore.DomainService;
using MyProject.PreOrderCore.DomainService;

namespace MyProject.OrderCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_OrderAppService : MyProjectAppServiceBase, IWMS_OrderAppService
    {
        /// <summary>
        ///【WMS_Order】仓储层
        /// </summary>
        private readonly IRepository<WMS_Order, long> _wms_orderRepository;

        /// <summary>
        ///【WMS_Order】领域服务
        /// </summary>
        private readonly IWMS_OrderManager _wms_orderManager;


        /// <summary>
        ///【WMS_PreOrder】仓储层
        /// </summary>
        private readonly IRepository<WMS_PreOrder, long> _wms_preorderRepository;

        /// <summary>
        ///【WMS_PreOrder】领域服务
        /// </summary>
        private readonly IWMS_PreOrderManager _wms_preorderManager;

        /// <summary>
        ///【WMS_PreOrderDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_PreOrderDetail, long> _wms_preorderdetailRepository;

        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;

        private readonly ITable_ColumnsManager _table_ColumnsManager;
        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;


        /// <summary>
        ///【WMS_Inventory_Usable】仓储层
        /// </summary>
        private readonly IRepository<WMS_Inventory_Usable, long> _wms_inventory_usableRepository;

        public ICapPublisher _publisher { get; set; }


        /// <summary>
        ///【WMS_OrderDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_OrderDetail, long> _wms_orderdetailRepository;

        public WMS_OrderAppService(
            IRepository<WMS_Order, long> wms_orderRepository,
            IWMS_OrderManager wms_orderManager,
             IRepository<WMS_PreOrder, long> wms_preorderRepository,
            IRepository<WMS_PreOrderDetail, long> wms_preorderdetailRepository,
            IRepository<WMS_OrderDetail, long> wms_orderdetailRepository,
            IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
            IWMS_PreOrderManager wms_preorderManager,
            ITable_ColumnsManager table_ColumnsManager,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager,
            ICapPublisher publisher
        )
        {
            _wms_orderRepository = wms_orderRepository;
            _wms_orderManager = wms_orderManager;
            _wms_preorderRepository = wms_preorderRepository;
            _wms_preorderdetailRepository = wms_preorderdetailRepository;
            _wms_preorderManager = wms_preorderManager;
            _wms_orderRepository = wms_orderRepository;
            _wms_orderdetailRepository = wms_orderdetailRepository;
            _wms_inventory_usableRepository = wms_inventory_usableRepository;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;
            _table_ColumnsManager = table_ColumnsManager;
            _publisher = publisher;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_Order】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_OrderListDto>> GetPaged(GetWMS_OrdersInput input)
        {
            var query = _wms_orderRepository.GetAll()
                          //模糊搜索 字段PreOrderNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.PreOrderNumber.Contains(input.FilterText))
                          //模糊搜索 字段ExternOrderNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ExternOrderNumber.Contains(input.FilterText))
                          //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.FilterText))
                          //模糊搜索 字段OrderType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.OrderType.Contains(input.FilterText))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.FilterText))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.FilterText))
                          //模糊搜索 字段Remark
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.FilterText))
                          //模糊搜索 字段Str1
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str1.Contains(input.FilterText))
                          //模糊搜索 字段Str2
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str2.Contains(input.FilterText))
                          //模糊搜索 字段Str3
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str3.Contains(input.FilterText))
                          //模糊搜索 字段Str4
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str4.Contains(input.FilterText))
                          //模糊搜索 字段Str5
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str5.Contains(input.FilterText))
                          //模糊搜索 字段Str6
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str6.Contains(input.FilterText))
                          //模糊搜索 字段Str7
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str7.Contains(input.FilterText))
                          //模糊搜索 字段Str8
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str8.Contains(input.FilterText))
                          //模糊搜索 字段Str9
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str9.Contains(input.FilterText))
                          //模糊搜索 字段Str10
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str10.Contains(input.FilterText))
                          //模糊搜索 字段Str11
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str11.Contains(input.FilterText))
                          //模糊搜索 字段Str12
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str12.Contains(input.FilterText))
                          //模糊搜索 字段Str13
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str13.Contains(input.FilterText))
                          //模糊搜索 字段Str14
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str14.Contains(input.FilterText))
                          //模糊搜索 字段Str15
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str15.Contains(input.FilterText))
                          //模糊搜索 字段Str16
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str16.Contains(input.FilterText))
                          //模糊搜索 字段Str17
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str17.Contains(input.FilterText))
                          //模糊搜索 字段Str18
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str18.Contains(input.FilterText))
                          //模糊搜索 字段Str19
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str19.Contains(input.FilterText))
                          //模糊搜索 字段Str20
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str20.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WMS_OrderListDto>>(entityList);

            return new PagedResultDto<WMS_OrderListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_Order】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        [HttpGet]
        public async Task<WMS_OrderListDto> GetById(EntityDto<long> input)
        {
            //var entity = await _wms_orderRepository.in(a=>a.OrderDetails).g(input.Id);
            var entity = await _wms_orderRepository.GetAllIncluding(a => a.OrderDetails).Where(b => b.Id == input.Id).FirstAsync();

            var dto = ObjectMapper.Map<WMS_OrderListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Order】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        [HttpPost]
        public async Task<GetWMS_OrderForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_OrderForEditOutput();
            WMS_OrderEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_orderRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_OrderEditDto>(entity);
            }
            else
            {
                editDto = new WMS_OrderEditDto();
            }
            output.WMS_Order = editDto;
            return output;
        }
        /// <summary>
        ///【WMS_Order】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_OrderInput input)
        {

            if (input.WMS_Order.Id.HasValue)
            {
                await Update(input.WMS_Order);
            }
            else
            {
                await Create(input.WMS_Order);
            }
        }
        /// <summary>
        ///【WMS_Order】新增
        /// </summary>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        protected virtual async Task<WMS_OrderEditDto> Create(WMS_OrderEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Order>(input);
            //调用领域服务
            entity = await _wms_orderManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_OrderEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Order】编辑
        /// </summary>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        protected virtual async Task Update(WMS_OrderEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_orderRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_orderManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_Order】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_orderManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_Order】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_OrderPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_orderManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/


        /// <summary>
        /// 自动分配库存
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<OrderStatusDto>> BatchAutomatedAllocation (List<long> input)
        {


            //获取勾选的订单的客户
            //获取需要导入的客户，根据客户调用不同的配置方法(根据系统单号获取)
            var CustomerData = _wms_orderRepository.GetAll().Where(a => a.Id == input.First()).FirstOrDefault();
            long CustomerId = 0;
            if (CustomerData != null)
            {
                CustomerId = CustomerData.CustomerId;
            }
            IAutomatedAllocationInterface factory = AutomatedAllocationFactory.AutomatedAllocation(_wms_orderRepository, _wms_orderdetailRepository, _wms_inventory_usableRepository, _warehouseusermappingManager, _customerusermappingManager, CustomerId);
            var data = factory.Strategy(input, AbpSession);

            return data.Result.Data;
        }

        #endregion
    }
}
