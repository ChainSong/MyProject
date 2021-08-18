
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace MyProject.ReceiptCore.DomainService
{
    public interface IWMS_ReceiptDetailManager : IDomainService
	{


		 
		  
	
		/// <summary>
		/// 检查实体是否存在
		/// </summary>
		/// <returns></returns>
		Task<bool> IsExistAsync(long id);


		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task<WMS_ReceiptDetail> CreateAsync(WMS_ReceiptDetail entity);

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task UpdateAsync(WMS_ReceiptDetail entity);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(long id);
		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input">Id的集合</param>
		/// <returns></returns>
		Task BatchDelete(List<long> input);


		
							//// custom codes
									
							

							//// custom codes end

		 
      
         

    }
}
