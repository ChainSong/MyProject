

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.ReceiptCore.DomainService
{
    /// <summary>
    /// 的领域服务方法
    ///</summary>
    public class WMS_ReceiptDetailManager : MyProjectDomainServiceBase, IWMS_ReceiptDetailManager
    {
		
 
		/// <summary>
		/// WMS_ReceiptDetail的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	 //   public WMS_ReceiptDetailManager(IServiceProvider serviceProvider) : base(serviceProvider)	
  //      {
			 
		//}

        private readonly IRepository<WMS_ReceiptDetail, long> _wMS_ReceiptDetailRepository;

        /// <summary>
        /// WMS_Receipt的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WMS_ReceiptDetailManager(IRepository<WMS_ReceiptDetail, long> wMS_ReceiptDetailRepository)
        {
            _wMS_ReceiptDetailRepository = wMS_ReceiptDetailRepository;
        }                                   





        public async Task<WMS_ReceiptDetail> CreateAsync(WMS_ReceiptDetail entity)
        {
             entity.Id=   await _wMS_ReceiptDetailRepository.InsertAndGetIdAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(WMS_ReceiptDetail entity)
        {
            await _wMS_ReceiptDetailRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptDetailRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptDetailRepository.DeleteAsync(a => input.Contains(a.Id)); 
        }

	   public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wMS_ReceiptDetailRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
