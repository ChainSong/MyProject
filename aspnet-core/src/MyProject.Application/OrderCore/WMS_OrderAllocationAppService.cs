
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

namespace MyProject.OrderCore
{
	/// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
	[ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
	public class WMS_OrderAllocationAppService : MyProjectAppServiceBase, IWMS_OrderAllocationAppService
	{
		/// <summary>
		///【WMS_OrderAllocation】仓储层
		/// </summary>
		private readonly IRepository<WMS_OrderAllocation, long>	_wms_orderallocationRepository;

		/// <summary>
		///【WMS_OrderAllocation】领域服务
		/// </summary>
		private readonly IWMS_OrderAllocationManager _wms_orderallocationManager;
		
		public WMS_OrderAllocationAppService(
			IRepository<WMS_OrderAllocation, long>  wms_orderallocationRepository,
			IWMS_OrderAllocationManager wms_orderallocationManager
        )
        {
			_wms_orderallocationRepository = wms_orderallocationRepository;
			_wms_orderallocationManager=wms_orderallocationManager;
        }
		
        #region -------------------------------------------------辅助工具生成---------------------------------------------- 
		
		/// <summary>
        ///【WMS_OrderAllocation】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
        public async Task<PagedResultDto<WMS_OrderAllocationListDto>> GetPaged(GetWMS_OrderAllocationsInput input)
		{
			var query = _wms_orderallocationRepository.GetAll()
                            //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段WarehouseName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Area
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Area.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Location
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Location.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段SKU
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SKU.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段UPC
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UPC.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段GoodsType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsType.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段GoodsName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段UnitCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UnitCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Onwer
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Onwer.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段BoxCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BoxCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段TrayCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TrayCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段BatchCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BatchCode.Contains(input.FilterText))                                                                                      
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
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<WMS_OrderAllocationListDto>>(entityList);

			return new PagedResultDto<WMS_OrderAllocationListDto>(count,entityListDtos);
		}

		/// <summary>
		///【WMS_OrderAllocation】通过指定id获取MemberListDto信息
		/// </summary>
		//[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
		public async Task<WMS_OrderAllocationListDto> GetById(EntityDto<long> input)
		{
			var entity = await _wms_orderallocationRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<WMS_OrderAllocationListDto>(entity);
			return dto;
 		}

		/// <summary>
		///【WMS_OrderAllocation】 获取编辑
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
		public async Task<GetWMS_OrderAllocationForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetWMS_OrderAllocationForEditOutput();
			WMS_OrderAllocationEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _wms_orderallocationRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<WMS_OrderAllocationEditDto>(entity);
			}
			else
			{
				editDto = new WMS_OrderAllocationEditDto();
			}
            output.WMS_OrderAllocation = editDto;
			return output;
		}
		/// <summary>
		///【WMS_OrderAllocation】 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
		public async Task CreateOrUpdate(CreateOrUpdateWMS_OrderAllocationInput input)
		{
			
			if (input.WMS_OrderAllocation.Id.HasValue)
			{
				await Update(input.WMS_OrderAllocation);
			}
			else
			{
				await Create(input.WMS_OrderAllocation);
			}
		}
		/// <summary>
		///【WMS_OrderAllocation】新增
		/// </summary>
		//[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
		protected virtual async Task<WMS_OrderAllocationEditDto> Create(WMS_OrderAllocationEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_OrderAllocation>(input);
            //调用领域服务
            entity = await _wms_orderallocationManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<WMS_OrderAllocationEditDto>(entity);
            return dto;
		}

		/// <summary>
		///【WMS_OrderAllocation】编辑
		/// </summary>
		//[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
		protected virtual async Task Update(WMS_OrderAllocationEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
			var key =  input.Id.Value;
			var entity = await _wms_orderallocationRepository.GetAsync(key);
			//  input.MapTo(entity);
			//将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_orderallocationManager.UpdateAsync(entity);
		}

		/// <summary>
		///【WMS_OrderAllocation】删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _wms_orderallocationManager.DeleteAsync(input.Id);
		}

		/// <summary>
		///【WMS_OrderAllocation】 批量删除Member的方法
		/// </summary>
		//[AbpAuthorize(WMS_OrderAllocationPermissions.Node)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_orderallocationManager.BatchDelete(input);
		}

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展应用服务实现*/
		#endregion
	}
}
