
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
using MyProject.InventoryCore;
using MyProject.InventoryCore.Dtos;
using MyProject.InventoryCore.DomainService;

using MyProject.Authorization;
using MyProject.CustomerCore.DomainService;
using MyProject.WarehouseCore.DomainService;
using MyProject.TableColumns.DomainService;

namespace MyProject.InventoryCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_Inventory_UsableAppService : MyProjectAppServiceBase, IWMS_Inventory_UsableAppService
    {
        /// <summary>
        ///【WMS_Inventory_Usable】仓储层
        /// </summary>
        private readonly IRepository<WMS_Inventory_Usable, long> _wms_inventory_usableRepository;

        /// <summary>
        ///【WMS_Inventory_Usable】领域服务
        /// </summary>
        private readonly IWMS_Inventory_UsableManager _wms_inventory_usableManager;

        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;

        private readonly ITable_ColumnsManager _table_ColumnsManager;
        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;


        public WMS_Inventory_UsableAppService(
            IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
            IWMS_Inventory_UsableManager wms_inventory_usableManager,
            ITable_ColumnsManager table_ColumnsManager,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager
        )
        {
            _wms_inventory_usableRepository = wms_inventory_usableRepository;
            _wms_inventory_usableManager = wms_inventory_usableManager;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;
            _table_ColumnsManager = table_ColumnsManager;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_Inventory_Usable】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_Inventory_UsableListDto>> GetPaged(GetWMS_Inventory_UsablesInput input)
        {
            var query = _wms_inventory_usableRepository.GetAll()
                            //添加查询限制（默认必有的查询条件）
                           .Where(a => _warehouseusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.WarehouseId).Contains(a.WarehouseId))
                           .Where(a => _customerusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.CustomerId).Contains(a.CustomerId))

                          //模糊搜索 字段CustomerName
                          .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.CustomerName))
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.WarehouseName))
                          //模糊搜索 字段Area
                          .WhereIf(!input.Area.IsNullOrWhiteSpace(), a => a.Area.Contains(input.Area))
                          //模糊搜索 字段Location
                          .WhereIf(!input.Location.IsNullOrWhiteSpace(), a => a.Location.Contains(input.Location))
                          //模糊搜索 字段SKU
                          .WhereIf(!input.SKU.IsNullOrWhiteSpace(), a => a.SKU.Contains(input.SKU))
                          //模糊搜索 字段UPC
                          .WhereIf(!input.UPC.IsNullOrWhiteSpace(), a => a.UPC.Contains(input.UPC))
                          //模糊搜索 字段GoodsType
                          .WhereIf(!input.GoodsType.IsNullOrWhiteSpace(), a => a.GoodsType.Contains(input.GoodsType))
                          //模糊搜索 字段GoodsName
                          .WhereIf(!input.GoodsName.IsNullOrWhiteSpace(), a => a.GoodsName.Contains(input.GoodsName))
                          //模糊搜索 字段UnitCode
                          .WhereIf(!input.UnitCode.IsNullOrWhiteSpace(), a => a.UnitCode.Contains(input.UnitCode))
                          //模糊搜索 字段Onwer
                          .WhereIf(!input.Onwer.IsNullOrWhiteSpace(), a => a.Onwer.Contains(input.Onwer))
                          //模糊搜索 字段BoxCode
                          .WhereIf(!input.BoxCode.IsNullOrWhiteSpace(), a => a.BoxCode.Contains(input.BoxCode))
                          //模糊搜索 字段TrayCode
                          .WhereIf(!input.TrayCode.IsNullOrWhiteSpace(), a => a.TrayCode.Contains(input.TrayCode))
                          //模糊搜索 字段BatchCode
                          .WhereIf(!input.BatchCode.IsNullOrWhiteSpace(), a => a.BatchCode.Contains(input.BatchCode))
                          //模糊搜索 字段Remark
                          .WhereIf(!input.Remark.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.Remark))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.Creator.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.Creator))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.Updator.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.Updator))
                          //模糊搜索 字段Str1
                          .WhereIf(!input.Str1.IsNullOrWhiteSpace(), a => a.Str1.Contains(input.Str1))
                          //模糊搜索 字段Str2
                          .WhereIf(!input.Str2.IsNullOrWhiteSpace(), a => a.Str2.Contains(input.Str2))
                          //模糊搜索 字段Str3
                          .WhereIf(!input.Str3.IsNullOrWhiteSpace(), a => a.Str3.Contains(input.Str3))
                          //模糊搜索 字段Str4
                          .WhereIf(!input.Str4.IsNullOrWhiteSpace(), a => a.Str4.Contains(input.Str4))
                          //模糊搜索 字段Str5
                          .WhereIf(!input.Str5.IsNullOrWhiteSpace(), a => a.Str5.Contains(input.Str5))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WMS_Inventory_UsableListDto>>(entityList);

            return new PagedResultDto<WMS_Inventory_UsableListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_Inventory_Usable】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        [HttpGet]
        public async Task<WMS_Inventory_UsableListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wms_inventory_usableRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_Inventory_UsableListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Inventory_Usable】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        [HttpPost]
        public async Task<GetWMS_Inventory_UsableForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_Inventory_UsableForEditOutput();
            WMS_Inventory_UsableEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_inventory_usableRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_Inventory_UsableEditDto>(entity);
            }
            else
            {
                editDto = new WMS_Inventory_UsableEditDto();
            }
            output.WMS_Inventory_Usable = editDto;
            return output;
        }
        /// <summary>
        ///【WMS_Inventory_Usable】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_Inventory_UsableInput input)
        {

            if (input.WMS_Inventory_Usable.Id.HasValue)
            {
                await Update(input.WMS_Inventory_Usable);
            }
            else
            {
                await Create(input.WMS_Inventory_Usable);
            }
        }
        /// <summary>
        ///【WMS_Inventory_Usable】新增
        /// </summary>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        protected virtual async Task<WMS_Inventory_UsableEditDto> Create(WMS_Inventory_UsableEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Inventory_Usable>(input);
            //调用领域服务
            entity = await _wms_inventory_usableManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_Inventory_UsableEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Inventory_Usable】编辑
        /// </summary>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        protected virtual async Task Update(WMS_Inventory_UsableEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_inventory_usableRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_inventory_usableManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_Inventory_Usable】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_inventory_usableManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_Inventory_Usable】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_Inventory_UsablePermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_inventory_usableManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        #endregion
    }
}
