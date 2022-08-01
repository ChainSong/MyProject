
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
using MyProject.ProductCore;
using MyProject.ProductCore.Dtos;
using MyProject.ProductCore.DomainService;

using MyProject.Authorization;

namespace MyProject.ProductCore
{
	/// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
	[ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
	public class WMS_ProductAppService : MyProjectAppServiceBase, IWMS_ProductAppService
	{
		/// <summary>
		///【WMS_Product】仓储层
		/// </summary>
		private readonly IRepository<WMS_Product, long>	_wms_productRepository;

		/// <summary>
		///【WMS_Product】领域服务
		/// </summary>
		private readonly IWMS_ProductManager _wms_productManager;
		
		public WMS_ProductAppService(
			IRepository<WMS_Product, long>  wms_productRepository,
			IWMS_ProductManager wms_productManager
        )
        {
			_wms_productRepository = wms_productRepository;
			_wms_productManager=wms_productManager;
        }

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

		/// <summary>
		///【WMS_Product】获取的分页列表信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		[HttpPost]
		public async Task<PagedResultDto<WMS_ProductListDto>> GetPaged(GetWMS_ProductsInput input)
		{
			var query = _wms_productRepository.GetAll()
                            //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段SKU
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SKU.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段GoodsName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段GoodsType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsType.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段SKUClassification
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SKUClassification.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段SKULevel
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SKULevel.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段SKUGroup
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SKUGroup.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段ManufacturerSKU
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ManufacturerSKU.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段RetailSKU
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.RetailSKU.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段ReplaceSKU
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ReplaceSKU.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段BoxGroup
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BoxGroup.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Country
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Country.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Manufacturer
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Manufacturer.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段DangerCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.DangerCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Vvolume
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Vvolume.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段StandardVolume
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.StandardVolume.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Weight
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Weight.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段StandardWeight
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.StandardWeight.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段NetWeight
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.NetWeight.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段StandardNetWeight
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.StandardNetWeight.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Cost
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Cost.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Color
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Color.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Remark
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Creator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.FilterText))                                                                                      
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

			var entityListDtos = ObjectMapper.Map<List<WMS_ProductListDto>>(entityList);

			return new PagedResultDto<WMS_ProductListDto>(count,entityListDtos);
		}

		/// <summary>
		///【WMS_Product】通过指定id获取MemberListDto信息
		/// </summary>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		[HttpGet]
		public async Task<WMS_ProductListDto> GetById(EntityDto<long> input)
		{
			var entity = await _wms_productRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<WMS_ProductListDto>(entity);
			return dto;
 		}

		/// <summary>
		///【WMS_Product】 获取编辑
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		[HttpPost]
		public async Task<GetWMS_ProductForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetWMS_ProductForEditOutput();
			WMS_ProductEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _wms_productRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<WMS_ProductEditDto>(entity);
			}
			else
			{
				editDto = new WMS_ProductEditDto();
			}
            output.WMS_Product = editDto;
			return output;
		}
		/// <summary>
		///【WMS_Product】 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		[HttpPost]
		public async Task CreateOrUpdate(CreateOrUpdateWMS_ProductInput input)
		{
			
			if (input.WMS_Product.Id.HasValue)
			{
				await Update(input.WMS_Product);
			}
			else
			{
				await Create(input.WMS_Product);
			}
		}
		/// <summary>
		///【WMS_Product】新增
		/// </summary>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		protected virtual async Task<WMS_ProductEditDto> Create(WMS_ProductEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Product>(input);
            //调用领域服务
            entity = await _wms_productManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<WMS_ProductEditDto>(entity);
            return dto;
		}

		/// <summary>
		///【WMS_Product】编辑
		/// </summary>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		protected virtual async Task Update(WMS_ProductEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
			var key =  input.Id.Value;
			var entity = await _wms_productRepository.GetAsync(key);
			//  input.MapTo(entity);
			//将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_productManager.UpdateAsync(entity);
		}

		/// <summary>
		///【WMS_Product】删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		[HttpGet]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _wms_productManager.DeleteAsync(input.Id);
		}

		/// <summary>
		///【WMS_Product】 批量删除Member的方法
		/// </summary>
		//[AbpAuthorize(WMS_ProductPermissions.Node)]
		[HttpPost]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_productManager.BatchDelete(input);
		}

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展应用服务实现*/
		#endregion
	}
}
