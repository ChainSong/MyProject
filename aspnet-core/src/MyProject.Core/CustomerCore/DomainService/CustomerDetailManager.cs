

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.CustomerCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class CustomerDetailManager :MyProjectDomainServiceBase, ICustomerDetailManager
    {
		
		private readonly IRepository<CustomerDetail,long> _customerDetailRepository;

		/// <summary>
		/// CustomerDetail的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	public CustomerDetailManager(IRepository<CustomerDetail, long> customerDetailRepository)	{
			_customerDetailRepository =  customerDetailRepository;
		}

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<CustomerDetail> QueryCustomerDetails()
        {
            return _customerDetailRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<CustomerDetail> QueryCustomerDetailsAsNoTracking()
        {
            return _customerDetailRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CustomerDetail> FindByIdAsync(long id)
        {
            var entity = await _customerDetailRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _customerDetailRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<CustomerDetail> CreateAsync(CustomerDetail entity)
        {
            entity.Id = await _customerDetailRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(CustomerDetail entity)
        {
            await _customerDetailRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerDetailRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerDetailRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	 
			
							//// custom codes
									
							

							//// custom codes end



		 
		  
		 

	}
}
