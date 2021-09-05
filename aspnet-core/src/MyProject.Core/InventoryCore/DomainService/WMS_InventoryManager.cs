

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.InventoryCore.DomainService
{
    /// <summary>
    /// 的领域服务方法
    ///</summary>
    public class WMS_InventoryManager : MyProjectDomainServiceBase, IWMS_InventoryManager
    {
        private readonly IRepository<WMS_Inventory, long> _wMS_InventoryRepository;

        /// <summary>
        /// CustomerDetail的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WMS_InventoryManager(IRepository<WMS_Inventory, long> wMS_InventoryRepository)
        {
            _wMS_InventoryRepository = wMS_InventoryRepository;
        }

        /// <summary>
        /// WMS_Inventory的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
  //      public WMS_InventoryManager(IServiceProvider serviceProvider) : base(serviceProvider)	
  //      {
			 
		//}

		 
		 
		 
        public async Task<WMS_Inventory> CreateAsync(WMS_Inventory entity)
        {
             entity.Id=   await _wMS_InventoryRepository.InsertAndGetIdAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(WMS_Inventory entity)
        {
            await _wMS_InventoryRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_InventoryRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_InventoryRepository.DeleteAsync(a => input.Contains(a.Id)); 
        }

	   public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wMS_InventoryRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
