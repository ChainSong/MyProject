
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
//using L._52ABP.Application.Dtos;
//using L._52ABP.Common.Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MyProject.WarehouseCore;
using MyProject.WarehouseCore.Dtos;
//using MyProject.WarehouseCore.Exporting;
using MyProject.WarehouseCore.DomainService;
using MyProject.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.WarehouseCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>

    [AbpAuthorize]
    public class WarehouseUserMappingAppService : MyProjectAppServiceBase, IWarehouseUserMappingAppService
    {

        private readonly IRepository<WarehouseUserMapping, long> _warehouseUserMappingRepository;


        private readonly IWarehouseUserMappingManager _warehouseUserMappingManager;


        /// <summary>
        /// 构造函数
        ///</summary>

        public WarehouseUserMappingAppService(IRepository<WarehouseUserMapping, long> warehouseUserMappingRepository
            , IWarehouseUserMappingManager warehouseUserMappingManager
            )
        {
            _warehouseUserMappingRepository = warehouseUserMappingRepository;
            _warehouseUserMappingManager = warehouseUserMappingManager;


        }


        /// <summary>
        /// 获取的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_Query)]
        [HttpPost]
        public async Task<PagedResultDto<WarehouseUserMappingListDto>> GetPaged(GetWarehouseUserMappingsInput input)
        {

            var query = _warehouseUserMappingRepository.GetAll()
                          .WhereIf(!input.UserName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索UserName
                          a.UserName.Contains(input.UserName))
                           .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索WarehouseName
                          a.WarehouseName.Contains(input.WarehouseName))
                             .WhereIf(input.UserId != 0, a =>
                            //模糊搜索UserId
                            a.UserId == (input.UserId))
                              .WhereIf(input.WarehouseId != 0, a =>
                            //模糊搜索WarehouseId
                            a.UserId == (input.WarehouseId)
            );
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var warehouseUserMappingList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var warehouseUserMappingListDtos = ObjectMapper.Map<List<WarehouseUserMappingListDto>>(warehouseUserMappingList);

            return new PagedResultDto<WarehouseUserMappingListDto>(count, warehouseUserMappingListDtos);
        }


        /// <summary>
        /// 通过指定id获取WarehouseUserMappingListDto信息
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_Query)]
        [HttpGet]
        public async Task<WarehouseUserMappingListDto> GetById(EntityDto<long> input)
        {
            var entity = await _warehouseUserMappingRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WarehouseUserMappingListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_Create, WarehouseUserMappingPermissions.WarehouseUserMapping_Edit)]
        [HttpGet]
        public async Task<GetWarehouseUserMappingForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWarehouseUserMappingForEditOutput();
            WarehouseUserMappingEditDto editDto;

            if (input.Id.HasValue)
            {


                var entity = await _warehouseUserMappingRepository.GetAsync(input.Id.Value);
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
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_Create, WarehouseUserMappingPermissions.WarehouseUserMapping_Edit)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWarehouseUserMappingInput input)
        {

            if (input.WarehouseUserMapping.Id.HasValue)
            {
                await Update(input.WarehouseUserMapping);
            }
            else
            {
                await Create(input.WarehouseUserMapping);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_Create)]
        protected virtual async Task<WarehouseUserMappingEditDto> Create(WarehouseUserMappingEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WarehouseUserMapping>(input);
            //调用领域服务
            entity = await _warehouseUserMappingManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WarehouseUserMappingEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_Edit)]
        protected virtual async Task Update(WarehouseUserMappingEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _warehouseUserMappingRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _warehouseUserMappingRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_Delete)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _warehouseUserMappingRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除WarehouseUserMapping的方法
        /// </summary>
        //[AbpAuthorize(WarehouseUserMappingPermissions.WarehouseUserMapping_BatchDelete)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _warehouseUserMappingManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


