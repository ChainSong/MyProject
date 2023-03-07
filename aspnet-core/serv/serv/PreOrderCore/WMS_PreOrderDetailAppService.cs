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
using serv;
using serv.Dtos;
using MyProject;
using MyProject.PreOrderCore;
using MyProject.PreOrderCore.DomainService;

using MyProject.Authorization;

namespace MyProject.PreOrderCore
{
	/// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
	public class WMS_PreOrderDetailAppService : ${ClassName}ServiceBase, IWMS_PreOrderDetailAppService
	{
		/// <summary>
		///【WMS_PreOrderDetail】仓储层
		/// </summary>
		private readonly IRepository<WMS_PreOrderDetail, long>	_wms_preorderdetailRepository;

		/// <summary>
		///【WMS_PreOrderDetail】领域服务
		/// </summary>
		private readonly IWMS_PreOrderDetailManager _wms_preorderdetailManager;
		
		public WMS_PreOrderDetailAppService(
			IRepository<WMS_PreOrderDetail, long>  wms_preorderdetailRepository,
			IWMS_PreOrderDetailManager wms_preorderdetailManager
        )
        {
			_wms_preorderdetailRepository = wms_preorderdetailRepository;
			_wms_preorderdetailManager=wms_preorderdetailManager;
        }
		
        #region -------------------------------------------------辅助工具生成---------------------------------------------- 
		
		/// <summary>
        ///【WMS_PreOrderDetail】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
        public async Task<PagedResultDto<WMS_PreOrderDetailListDto>> GetPaged(GetWMS_PreOrderDetailsInput input)
		{
			var query = _wms_preorderdetailRepository.GetAll()
                            //模糊搜索 字段PreOrderNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.PreOrderNumber.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段ExternOrderNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ExternOrderNumber.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段WarehouseName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段LineNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.LineNumber.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段SKU
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SKU.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段UPC
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UPC.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段GoodsName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段GoodsType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsType.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段BoxCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BoxCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段TrayCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TrayCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段BatchCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BatchCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段UnitCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UnitCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Onwer
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Onwer.Contains(input.FilterText))                                                                                      
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

			var entityListDtos = ObjectMapper.Map<List<WMS_PreOrderDetailListDto>>(entityList);

			return new PagedResultDto<WMS_PreOrderDetailListDto>(count,entityListDtos);
		}

		/// <summary>
		///【WMS_PreOrderDetail】通过指定id获取MemberListDto信息
		/// </summary>
		[AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
		public async Task<WMS_PreOrderDetailListDto> GetById(EntityDto<long> input)
		{
			var entity = await _wms_preorderdetailRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<WMS_PreOrderDetailListDto>(entity);
			return dto;
 		}

		/// <summary>
		///【WMS_PreOrderDetail】 获取编辑
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
		public async Task<GetWMS_PreOrderDetailForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetWMS_PreOrderDetailForEditOutput();
			WMS_PreOrderDetailEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _wms_preorderdetailRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<WMS_PreOrderDetailEditDto>(entity);
			}
			else
			{
				editDto = new WMS_PreOrderDetailEditDto();
			}
            output.WMS_PreOrderDetail = editDto;
			return output;
		}
		/// <summary>
		///【WMS_PreOrderDetail】 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
		public async Task CreateOrUpdate(CreateOrUpdateWMS_PreOrderDetailInput input)
		{
			
			if (input.WMS_PreOrderDetail.Id.HasValue)
			{
				await Update(input.WMS_PreOrderDetail);
			}
			else
			{
				await Create(input.WMS_PreOrderDetail);
			}
		}
		/// <summary>
		///【WMS_PreOrderDetail】新增
		/// </summary>
		[AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
		protected virtual async Task<WMS_PreOrderDetailEditDto> Create(WMS_PreOrderDetailEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_PreOrderDetail>(input);
            //调用领域服务
            entity = await _wms_preorderdetailManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<WMS_PreOrderDetailEditDto>(entity);
            return dto;
		}

		/// <summary>
		///【WMS_PreOrderDetail】编辑
		/// </summary>
		[AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
		protected virtual async Task Update(WMS_PreOrderDetailEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
			var key =  input.Id.Value;
			var entity = await _wms_preorderdetailRepository.GetAsync(key);
			//  input.MapTo(entity);
			//将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_preorderdetailManager.UpdateAsync(entity);
		}

		/// <summary>
		///【WMS_PreOrderDetail】删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _wms_preorderdetailManager.DeleteAsync(input.Id);
		}

		/// <summary>
		///【WMS_PreOrderDetail】 批量删除Member的方法
		/// </summary>
		[AbpAuthorize(WMS_PreOrderDetailPermissions.Node)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_preorderdetailManager.BatchDelete(input);
		}

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展应用服务实现*/
		#endregion
	}
}
