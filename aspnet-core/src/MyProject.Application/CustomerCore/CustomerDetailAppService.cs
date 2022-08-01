
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
using MyProject.CustomerCore;
using MyProject.CustomerCore.Dtos;
using MyProject.CustomerCore.DomainService;

using MyProject.Authorization;

namespace MyProject.CustomerCore
{
	/// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
	[ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
	public class CustomerDetailAppService : MyProjectAppServiceBase, ICustomerDetailAppService
	{
		/// <summary>
		///【CustomerDetail】仓储层
		/// </summary>
		private readonly IRepository<CustomerDetail, long>	_customerdetailRepository;

		/// <summary>
		///【CustomerDetail】领域服务
		/// </summary>
		private readonly ICustomerDetailManager _customerdetailManager;
		
		public CustomerDetailAppService(
			IRepository<CustomerDetail, long>  customerdetailRepository,
			ICustomerDetailManager customerdetailManager
        )
        {
			_customerdetailRepository = customerdetailRepository;
			_customerdetailManager=customerdetailManager;
        }
		
        #region -------------------------------------------------辅助工具生成---------------------------------------------- 
		
		/// <summary>
        ///【CustomerDetail】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(CustomerDetailPermissions.Node)]
        public async Task<PagedResultDto<CustomerDetailListDto>> GetPaged(GetCustomerDetailsInput input)
		{
			var query = _customerdetailRepository.GetAll()
                            //模糊搜索 字段CustomerCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerCode.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Contact
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Contact.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段TEL
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TEL.Contains(input.FilterText))                                                                                      
                            //模糊搜索 字段Creator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.FilterText))                                                                                      
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			var entityListDtos = ObjectMapper.Map<List<CustomerDetailListDto>>(entityList);

			return new PagedResultDto<CustomerDetailListDto>(count,entityListDtos);
		}

		/// <summary>
		///【CustomerDetail】通过指定id获取MemberListDto信息
		/// </summary>
		[AbpAuthorize(CustomerDetailPermissions.Node)]
		public async Task<CustomerDetailListDto> GetById(EntityDto<long> input)
		{
			var entity = await _customerdetailRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<CustomerDetailListDto>(entity);
			return dto;
 		}

		/// <summary>
		///【CustomerDetail】 获取编辑
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CustomerDetailPermissions.Node)]
		public async Task<GetCustomerDetailForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetCustomerDetailForEditOutput();
			CustomerDetailEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _customerdetailRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<CustomerDetailEditDto>(entity);
			}
			else
			{
				editDto = new CustomerDetailEditDto();
			}
            output.CustomerDetail = editDto;
			return output;
		}
		/// <summary>
		///【CustomerDetail】 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CustomerDetailPermissions.Node)]
		public async Task CreateOrUpdate(CreateOrUpdateCustomerDetailInput input)
		{
			
			if (input.CustomerDetail.Id.HasValue)
			{
				await Update(input.CustomerDetail);
			}
			else
			{
				await Create(input.CustomerDetail);
			}
		}
		/// <summary>
		///【CustomerDetail】新增
		/// </summary>
		[AbpAuthorize(CustomerDetailPermissions.Node)]
		protected virtual async Task<CustomerDetailEditDto> Create(CustomerDetailEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<CustomerDetail>(input);
            //调用领域服务
            entity = await _customerdetailManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<CustomerDetailEditDto>(entity);
            return dto;
		}

		/// <summary>
		///【CustomerDetail】编辑
		/// </summary>
		[AbpAuthorize(CustomerDetailPermissions.Node)]
		protected virtual async Task Update(CustomerDetailEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
			var key =  input.Id.Value;
			var entity = await _customerdetailRepository.GetAsync(key);
			//  input.MapTo(entity);
			//将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _customerdetailManager.UpdateAsync(entity);
		}

		/// <summary>
		///【CustomerDetail】删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CustomerDetailPermissions.Node)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _customerdetailManager.DeleteAsync(input.Id);
		}

		/// <summary>
		///【CustomerDetail】 批量删除Member的方法
		/// </summary>
		[AbpAuthorize(CustomerDetailPermissions.Node)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _customerdetailManager.BatchDelete(input);
		}

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展应用服务实现*/
		#endregion
	}
}
