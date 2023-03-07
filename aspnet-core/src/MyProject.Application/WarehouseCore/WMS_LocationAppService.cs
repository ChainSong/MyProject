
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
    public class WMS_LocationAppService : MyProjectAppServiceBase, IWMS_LocationAppService
    {
        /// <summary>
        ///【WMS_Location】仓储层
        /// </summary>
        private readonly IRepository<WMS_Location, long> _wms_locationRepository;

        /// <summary>
        ///【WMS_Location】领域服务
        /// </summary>
        private readonly IWMS_LocationManager _wms_locationManager;

        public WMS_LocationAppService(
            IRepository<WMS_Location, long> wms_locationRepository,
            IWMS_LocationManager wms_locationManager
        )
        {
            _wms_locationRepository = wms_locationRepository;
            _wms_locationManager = wms_locationManager;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_Location】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_LocationListDto>> GetPaged(GetWMS_LocationsInput input)
        {
            var query = _wms_locationRepository.GetAll()
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.WarehouseName))
                          //模糊搜索 字段AreaId
                          .WhereIf(input.AreaId != 0, a => a.AreaId == (input.AreaId))
                          //模糊搜索 字段AreaName
                          .WhereIf(!input.AreaName.IsNullOrWhiteSpace(), a => a.AreaName == (input.AreaName))
                          //模糊搜索 字段LocationStatus
                          .WhereIf(input.LocationStatus != 0, a => a.LocationStatus == (input.LocationStatus))
                          //模糊搜索 字段Location
                          .WhereIf(!input.Location.IsNullOrWhiteSpace(), a => a.Location == (input.Location))
                          //模糊搜索 字段LocationType
                          .WhereIf(!input.LocationType.IsNullOrWhiteSpace(), a => a.LocationType == (input.LocationType))
                          //模糊搜索 字段ABCClassification
                          .WhereIf(!input.ABCClassification.IsNullOrWhiteSpace(), a => a.ABCClassification == (input.ABCClassification))
                          //模糊搜索 字段LocationLevel
                          .WhereIf(!input.LocationLevel.IsNullOrWhiteSpace(), a => a.LocationLevel.Contains(input.LocationLevel))
                          //模糊搜索 字段GoodsPutOrder
                          .WhereIf(!input.GoodsPutOrder.IsNullOrWhiteSpace(), a => a.GoodsPutOrder.Contains(input.GoodsPutOrder))
                          //模糊搜索 字段GoodsPickOrder
                          .WhereIf(!input.GoodsPickOrder.IsNullOrWhiteSpace(), a => a.GoodsPickOrder.Contains(input.GoodsPickOrder))
                          //模糊搜索 字段SKU
                          .WhereIf(!input.SKU.IsNullOrWhiteSpace(), a => a.SKU.Contains(input.SKU))
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

            var entityListDtos = ObjectMapper.Map<List<WMS_LocationListDto>>(entityList);

            return new PagedResultDto<WMS_LocationListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_Location】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        [HttpGet]
        public async Task<WMS_LocationListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wms_locationRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_LocationListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Location】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        [HttpGet]
        public async Task<GetWMS_LocationForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_LocationForEditOutput();
            WMS_LocationEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_locationRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_LocationEditDto>(entity);
            }
            else
            {
                editDto = new WMS_LocationEditDto();
            }
            output.WMS_Location = editDto;
            return output;
        }
        /// <summary>
        ///【WMS_Location】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_LocationInput input)
        {

            if (input.WMS_Location.Id.HasValue)
            {
                await Update(input.WMS_Location);
            }
            else
            {
                await Create(input.WMS_Location);
            }
        }
        /// <summary>
        ///【WMS_Location】新增
        /// </summary>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        protected virtual async Task<WMS_LocationEditDto> Create(WMS_LocationEditDto input)
        {

            //TODO:新增前的逻辑判断，是否允许新增
            input.Creator = AbpSession.UserName;


            var entity = ObjectMapper.Map<WMS_Location>(input);
            //调用领域服务
            entity = await _wms_locationManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_LocationEditDto>(entity);
            return dto;


        }

        /// <summary>
        ///【WMS_Location】编辑
        /// </summary>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        protected virtual async Task Update(WMS_LocationEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            input.Updator = AbpSession.UserName;
            input.Updator = AbpSession.UserName;
            var key = input.Id.Value;
            var entity = await _wms_locationRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_locationManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_Location】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_locationManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_Location】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_LocationPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_locationManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        #endregion
    }
}
