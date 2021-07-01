
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
//using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Customers.Dtos;
using MyProject.Customers;



namespace MyProject.Customers
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface ICustomerAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerListDto>> GetPaged(GetCustomersInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<CustomerListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCustomerForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateCustomerInput input);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);

		
        /// <summary>
        /// 批量删除
        /// </summary>
        Task BatchDelete(List<long> input);


		
							//// custom codes
									
							

							//// custom codes end
    }
}
