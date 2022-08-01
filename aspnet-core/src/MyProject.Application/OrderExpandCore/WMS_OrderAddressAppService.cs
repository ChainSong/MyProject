
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
using MyProject.OrderExpandCore;
using MyProject.OrderExpandCore.Dtos;
using MyProject.OrderExpandCore.DomainService;

using MyProject.Authorization;

namespace MyProject.OrderExpandCore
{
	/// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
	[ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
	public class WMS_OrderAddressAppService : MyProjectAppServiceBase, IWMS_OrderAddressAppService
	{
		/// <summary>
		///【WMS_OrderAddress】仓储层
		/// </summary>
		private readonly IRepository<WMS_OrderAddress, long>	_wms_orderaddressRepository;

		/// <summary>
		///【WMS_OrderAddress】领域服务
		/// </summary>
		private readonly IWMS_OrderAddressManager _wms_orderaddressManager;
		
		public WMS_OrderAddressAppService(
			IRepository<WMS_OrderAddress, long>  wms_orderaddressRepository,
			IWMS_OrderAddressManager wms_orderaddressManager
        )
        {
			_wms_orderaddressRepository = wms_orderaddressRepository;
			_wms_orderaddressManager=wms_orderaddressManager;
        }
		
        #region -------------------------------------------------辅助工具生成---------------------------------------------- 
		
		/// <summary>
        ///【WMS_OrderAddress】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_OrderAddressPermissions.Node)]
        public async Task<PagedResultDto<WMS_OrderAddressListDto>> GetPaged(GetWMS_OrderAddresssInput input)
		{
			var query = _wms_orderaddressRepository.GetAll()
                            //模糊搜索 字段PreOrderId
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.PreOrderId.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段PreOrderNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.PreOrderNumber.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段ExternReceiptNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ExternReceiptNumber.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Name
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Name.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Phone
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Phone.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段ZipCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ZipCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Province
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Province.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段City
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.City.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Country
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Country.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Address
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Address.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段ExpressCompany
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ExpressCompany.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段ExpressNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ExpressNumber.Contains(input.FilterText))                                                                                      
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<WMS_OrderAddressListDto>>(entityList);

			return new PagedResultDto<WMS_OrderAddressListDto>(count,entityListDtos);
		}

		/// <summary>
		///【WMS_OrderAddress】通过指定id获取MemberListDto信息
		/// </summary>
		[AbpAuthorize(WMS_OrderAddressPermissions.Node)]
		public async Task<WMS_OrderAddressListDto> GetById(EntityDto<long> input)
		{
			var entity = await _wms_orderaddressRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<WMS_OrderAddressListDto>(entity);
			return dto;
 		}

		/// <summary>
		///【WMS_OrderAddress】 获取编辑
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(WMS_OrderAddressPermissions.Node)]
		public async Task<GetWMS_OrderAddressForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetWMS_OrderAddressForEditOutput();
			WMS_OrderAddressEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _wms_orderaddressRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<WMS_OrderAddressEditDto>(entity);
			}
			else
			{
				editDto = new WMS_OrderAddressEditDto();
			}
            output.WMS_OrderAddress = editDto;
			return output;
		}
		/// <summary>
		///【WMS_OrderAddress】 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(WMS_OrderAddressPermissions.Node)]
		public async Task CreateOrUpdate(CreateOrUpdateWMS_OrderAddressInput input)
		{
			
			if (input.WMS_OrderAddress.Id.HasValue)
			{
				await Update(input.WMS_OrderAddress);
			}
			else
			{
				await Create(input.WMS_OrderAddress);
			}
		}
		/// <summary>
		///【WMS_OrderAddress】新增
		/// </summary>
		[AbpAuthorize(WMS_OrderAddressPermissions.Node)]
		protected virtual async Task<WMS_OrderAddressEditDto> Create(WMS_OrderAddressEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_OrderAddress>(input);
            //调用领域服务
            entity = await _wms_orderaddressManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<WMS_OrderAddressEditDto>(entity);
            return dto;
		}

		/// <summary>
		///【WMS_OrderAddress】编辑
		/// </summary>
		[AbpAuthorize(WMS_OrderAddressPermissions.Node)]
		protected virtual async Task Update(WMS_OrderAddressEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
			var key =  input.Id.Value;
			var entity = await _wms_orderaddressRepository.GetAsync(key);
			//  input.MapTo(entity);
			//将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_orderaddressManager.UpdateAsync(entity);
		}

		/// <summary>
		///【WMS_OrderAddress】删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(WMS_OrderAddressPermissions.Node)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _wms_orderaddressManager.DeleteAsync(input.Id);
		}

		/// <summary>
		///【WMS_OrderAddress】 批量删除Member的方法
		/// </summary>
		[AbpAuthorize(WMS_OrderAddressPermissions.Node)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_orderaddressManager.BatchDelete(input);
		}

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展应用服务实现*/
		#endregion
	}
}
