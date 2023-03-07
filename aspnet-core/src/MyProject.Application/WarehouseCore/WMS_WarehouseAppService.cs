
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
using MyProject.WarehouseCore;
using MyProject.WarehouseCore.Dtos;
using MyProject.WarehouseCore.DomainService;

using MyProject.Authorization;
using MyProject.CommonCore;

namespace MyProject.WarehouseCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_WarehouseAppService : MyProjectAppServiceBase, IWMS_WarehouseAppService
    {
        /// <summary>
        ///【WMS_Warehouse】仓储层
        /// </summary>
        private readonly IRepository<WMS_Warehouse, long> _wms_warehouseRepository;

        /// <summary>
        ///【WMS_Warehouse】领域服务
        /// </summary>
        private readonly IWMS_WarehouseManager _wms_warehouseManager;


        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;

        public WMS_WarehouseAppService(
            IRepository<WMS_Warehouse, long> wms_warehouseRepository,
            IWMS_WarehouseManager wms_warehouseManager,
             IWarehouseUserMappingManager warehouseusermappingManager
        )
        {
            _wms_warehouseRepository = wms_warehouseRepository;
            _wms_warehouseManager = wms_warehouseManager;
            _warehouseusermappingManager = warehouseusermappingManager;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_Warehouse】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_WarehouseListDto>> GetPaged(GetWMS_WarehousesInput input)
        {
            var query = _wms_warehouseRepository.GetAll()
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.WarehouseName))
                          //模糊搜索 字段WarehouseType
                          .WhereIf(!input.WarehouseType.IsNullOrWhiteSpace(), a => a.WarehouseType.Contains(input.WarehouseType))
                          //模糊搜索 字段Description
                          .WhereIf(!input.Description.IsNullOrWhiteSpace(), a => a.Description.Contains(input.Description))
                          //模糊搜索 字段Company
                          .WhereIf(!input.Company.IsNullOrWhiteSpace(), a => a.Company.Contains(input.Company))
                          //模糊搜索 字段Address
                          .WhereIf(!input.Address.IsNullOrWhiteSpace(), a => a.Address.Contains(input.Address))
                          //模糊搜索 字段Province
                          .WhereIf(!input.Province.IsNullOrWhiteSpace(), a => a.Province.Contains(input.Province))
                          //模糊搜索 字段City
                          .WhereIf(!input.City.IsNullOrWhiteSpace(), a => a.City.Contains(input.City))
                          //模糊搜索 字段Contractor
                          .WhereIf(!input.Contractor.IsNullOrWhiteSpace(), a => a.Contractor.Contains(input.Contractor))
                          //模糊搜索 字段ContractorAddress
                          .WhereIf(!input.ContractorAddress.IsNullOrWhiteSpace(), a => a.ContractorAddress.Contains(input.ContractorAddress))
                          //模糊搜索 字段Mobile
                          .WhereIf(!input.Mobile.IsNullOrWhiteSpace(), a => a.Mobile.Contains(input.Mobile))
                          //模糊搜索 字段Phone
                          .WhereIf(!input.Phone.IsNullOrWhiteSpace(), a => a.Phone.Contains(input.Phone))
                          //模糊搜索 字段Fax
                          .WhereIf(!input.Fax.IsNullOrWhiteSpace(), a => a.Fax.Contains(input.Fax))
                          //模糊搜索 字段Email
                          .WhereIf(!input.Email.IsNullOrWhiteSpace(), a => a.Email.Contains(input.Email))
                          //模糊搜索 字段Remark
                          .WhereIf(!input.Remark.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.Remark))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.Creator.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.Creator))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.Updator.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.Updator))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WMS_WarehouseListDto>>(entityList);

            return new PagedResultDto<WMS_WarehouseListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_Warehouse】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        [HttpPost]
        public async Task<WMS_WarehouseListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wms_warehouseRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_WarehouseListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Warehouse】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        [HttpGet]
        public async Task<GetWMS_WarehouseForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_WarehouseForEditOutput();
            WMS_WarehouseEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_warehouseRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_WarehouseEditDto>(entity);
            }
            else
            {
                editDto = new WMS_WarehouseEditDto();
            }
            output.WMS_Warehouse = editDto;
            return output;
        }
        /// <summary>
        ///【WMS_Warehouse】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_WarehouseInput input)
        {

            if (input.WMS_Warehouse.Id.HasValue)
            {
                await Update(input.WMS_Warehouse);
            }
            else
            {
                await Create(input.WMS_Warehouse);
            }
        }
        /// <summary>
        ///【WMS_Warehouse】新增
        /// </summary>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        protected virtual async Task<WMS_WarehouseEditDto> Create(WMS_WarehouseEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Warehouse>(input);
            //调用领域服务
            entity = await _wms_warehouseManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_WarehouseEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Warehouse】编辑
        /// </summary>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        protected virtual async Task Update(WMS_WarehouseEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_warehouseRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_warehouseManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_Warehouse】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_warehouseManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_Warehouse】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_WarehousePermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_warehouseManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        /// <summary>
        /// 仓库的下拉列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<List<SelectListItem>> GetWarehouseSelect(string input)
        {


            var query = _warehouseusermappingManager.Query()
                        .Where(a => a.UserId == AbpSession.UserId)
            ;
            // TODO:根据传入的参数添加过滤条件

            //var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(a => a.Id).AsNoTracking()
                    .Select(a => new SelectListItem { Label = a.WarehouseName, Value = a.WarehouseId.ToString() })
                    .ToListAsync();

            //var entityListDtos = ObjectMapper.Map<List<WMS_WarehouseListDto>>(entityList);
            return entityList;
        }

        /// <summary>
        /// 获取所有的仓库，用于用户-仓库关系
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<List<WMS_WarehouseListDto>> GetAll(string input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var query = _wms_warehouseRepository.GetAll()

            ;
            // TODO:根据传入的参数添加过滤条件

            //var count = await query.CountAsync();

            var entityList = await query
                    .OrderByDescending(a => a.Id).AsNoTracking()
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WMS_WarehouseListDto>>(entityList);
            return entityListDtos;
        }

        #endregion
    }
}
