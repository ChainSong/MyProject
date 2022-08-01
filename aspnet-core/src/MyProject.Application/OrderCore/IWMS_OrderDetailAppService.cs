
using System;
using Abp.Runtime.Validation;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyProject.Dtos;
using MyProject.OrderCore;
using MyProject.OrderCore.Dtos;

namespace MyProject.OrderCore
{
	public interface IWMS_OrderDetailAppService : IApplicationService
	{
        #region -------------------------------------------------辅助工具生成---------------------------------------------- 
		/// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<WMS_OrderDetailListDto>> GetPaged(GetWMS_OrderDetailsInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<WMS_OrderDetailListDto> GetById(EntityDto<long> input);

        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetWMS_OrderDetailForEditOutput> GetForEdit(NullableIdDto<long> input);

        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateWMS_OrderDetailInput input);


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

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展应用服务接口*/
		#endregion
	}
}
