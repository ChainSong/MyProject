
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

namespace MyProject.WarehouseCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WarehouseUserMappingAppService : MyProjectAppServiceBase, IWarehouseUserMappingAppService
    {
        /// <summary>
        ///【WarehouseUserMapping】仓储层
        /// </summary>
        private readonly IRepository<WarehouseUserMapping, long> _warehouseusermappingRepository;
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

        public WarehouseUserMappingAppService(
            IRepository<WarehouseUserMapping, long> warehouseusermappingRepository,
            IWarehouseUserMappingManager warehouseusermappingManager,
            IRepository<WMS_Warehouse, long> wms_warehouseRepository,
            IWMS_WarehouseManager wms_warehouseManager
        )
        {
            _warehouseusermappingRepository = warehouseusermappingRepository;
            _warehouseusermappingManager = warehouseusermappingManager;
            _wms_warehouseRepository = wms_warehouseRepository;
            _wms_warehouseManager = wms_warehouseManager;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WarehouseUserMapping】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WarehouseUserMappingListDto>> GetPaged(GetWarehouseUserMappingsInput input)
        {
            var query = _warehouseusermappingRepository.GetAll()
                          //模糊搜索 字段UserName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UserName.Contains(input.FilterText))
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.FilterText))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.FilterText))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WarehouseUserMappingListDto>>(entityList);

            return new PagedResultDto<WarehouseUserMappingListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WarehouseUserMapping】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        [HttpGet]
        public async Task<WarehouseUserMappingListDto> GetById(EntityDto<long> input)
        {
            var entity = await _warehouseusermappingRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WarehouseUserMappingListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WarehouseUserMapping】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        [HttpGet]
        public async Task<GetWarehouseUserMappingForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWarehouseUserMappingForEditOutput();
            WarehouseUserMappingEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _warehouseusermappingRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WarehouseUserMappingEditDto>(entity);
            }
            else
            {
                editDto = new WarehouseUserMappingEditDto();
            }
            output.WarehouseUserMapping = editDto;
            return output;
        }
        /// <summary>
        ///【WarehouseUserMapping】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWarehouseUserMappingInput input)
        {
            var entity = ObjectMapper.Map<List<WarehouseUserMapping>>(input.WarehouseUserMappings);
            //调用领域服务
            //先删除mapping关系

            await _warehouseusermappingManager.UserIdDelete(entity.First().UserId);
            //然后创建mapping关系
            foreach (var item in entity)
            {
                if (item.Status > 0)
                {
                    item.Creator = AbpSession.UserName;
                    await _warehouseusermappingManager.CreateAsync(item);
                }
            }
            //var dto = ObjectMapper.Map<WarehouseUserMappingEditDto>(entity);
            //return dto;
            //if (input.WarehouseUserMapping.Id.HasValue)
            //{
            //    await Update(input.WarehouseUserMapping);
            //}
            //else
            //{
            //    await Create(input.WarehouseUserMapping);
            //}
        }
        /// <summary>
        ///【WarehouseUserMapping】新增
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        protected virtual async Task<WarehouseUserMappingEditDto> Create(WarehouseUserMappingEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WarehouseUserMapping>(input);
            //调用领域服务
            entity = await _warehouseusermappingManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WarehouseUserMappingEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WarehouseUserMapping】编辑
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        protected virtual async Task Update(WarehouseUserMappingEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _warehouseusermappingRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _warehouseusermappingManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WarehouseUserMapping】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _warehouseusermappingManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WarehouseUserMapping】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _warehouseusermappingManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/


        [HttpPost]
        public async Task<PagedResultDto<WarehouseUserMappingListDto>> GetMapping(WarehouseUserMappingEditDto input)
        {

            var query = _warehouseusermappingRepository.GetAll()
                      //模糊搜索 字段UserName
                      .WhereIf(!input.UserName.IsNullOrWhiteSpace(), a => a.UserName.Contains(input.UserName))
                      .WhereIf(input.UserId != 0, a => a.UserName == (input.UserName))
                      //模糊搜索 字段WarehouseName
                      .WhereIf(input.WarehouseId != 0, a => a.WarehouseId == (input.WarehouseId))
                      .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName == (input.WarehouseName))
        //模糊搜索 字段Creator

        ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderByDescending(a => a.Id).AsNoTracking()
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WarehouseUserMappingListDto>>(entityList);

            return new PagedResultDto<WarehouseUserMappingListDto>(count, entityListDtos);


        }
        #endregion
    }
}
