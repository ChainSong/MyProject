
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
	public class WMS_AreaAppService : MyProjectAppServiceBase, IWMS_AreaAppService
	{
		/// <summary>
		///【WMS_Area】仓储层
		/// </summary>
		private readonly IRepository<WMS_Area, long>	_wms_areaRepository;

		/// <summary>
		///【WMS_Area】领域服务
		/// </summary>
		private readonly IWMS_AreaManager _wms_areaManager;
		
		public WMS_AreaAppService(
			IRepository<WMS_Area, long>  wms_areaRepository,
			IWMS_AreaManager wms_areaManager
        )
        {
			_wms_areaRepository = wms_areaRepository;
			_wms_areaManager=wms_areaManager;
        }

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

		/// <summary>
		///【WMS_Area】获取的分页列表信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		[HttpPost]
		public async Task<PagedResultDto<WMS_AreaListDto>> GetPaged(GetWMS_AreasInput input)
		{
			var query = _wms_areaRepository.GetAll()
                            //模糊搜索 字段WarehouseName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段AreaName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.AreaName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段AreaType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.AreaType.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Remark
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.FilterText))                                                                                      
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

			var entityListDtos = ObjectMapper.Map<List<WMS_AreaListDto>>(entityList);

			return new PagedResultDto<WMS_AreaListDto>(count,entityListDtos);
		}

		/// <summary>
		///【WMS_Area】通过指定id获取MemberListDto信息
		/// </summary>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		[HttpGet]
		public async Task<WMS_AreaListDto> GetById(EntityDto<long> input)
		{
			var entity = await _wms_areaRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<WMS_AreaListDto>(entity);
			return dto;
 		}

		/// <summary>
		///【WMS_Area】 获取编辑
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		[HttpGet]
		public async Task<GetWMS_AreaForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetWMS_AreaForEditOutput();
			WMS_AreaEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _wms_areaRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<WMS_AreaEditDto>(entity);
			}
			else
			{
				editDto = new WMS_AreaEditDto();
			}
            output.WMS_Area = editDto;
			return output;
		}
		/// <summary>
		///【WMS_Area】 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		[HttpPost]
		public async Task CreateOrUpdate(CreateOrUpdateWMS_AreaInput input)
		{
			
			if (input.WMS_Area.Id.HasValue)
			{
				await Update(input.WMS_Area);
			}
			else
			{
				await Create(input.WMS_Area);
			}
		}
		/// <summary>
		///【WMS_Area】新增
		/// </summary>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		protected virtual async Task<WMS_AreaEditDto> Create(WMS_AreaEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Area>(input);
            //调用领域服务
            entity = await _wms_areaManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<WMS_AreaEditDto>(entity);
            return dto;
		}

		/// <summary>
		///【WMS_Area】编辑
		/// </summary>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		protected virtual async Task Update(WMS_AreaEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
			var key =  input.Id.Value;
			var entity = await _wms_areaRepository.GetAsync(key);
			//  input.MapTo(entity);
			//将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_areaManager.UpdateAsync(entity);
		}

		/// <summary>
		///【WMS_Area】删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		[HttpGet]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _wms_areaManager.DeleteAsync(input.Id);
		}

		/// <summary>
		///【WMS_Area】 批量删除Member的方法
		/// </summary>
		//[AbpAuthorize(WMS_AreaPermissions.Node)]
		[HttpPost]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_areaManager.BatchDelete(input);
		}

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展应用服务实现*/
		#endregion
	}
}
