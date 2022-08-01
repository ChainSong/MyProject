
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
    public class CustomerDetailManager :DomainServiceBase, ICustomerDetailManager
    {
		
		private readonly IRepository<CustomerDetail,long> _customerdetailRepository;

		/// <summary>
		/// 【CustomerDetail】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public CustomerDetailManager(IRepository<CustomerDetail, long> customerdetailRepository)	{
			_customerdetailRepository =  customerdetailRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<CustomerDetail> QueryEntityListAsNoTracking() { 

            var query = _customerdetailRepository.GetAll().AsNoTracking()
                        .Select(x => new CustomerDetail
                        {
                           
                            CustomerId = x.CustomerId,
                            ProjectId = x.ProjectId,
                            CustomerCode = x.CustomerCode,
                            CustomerName = x.CustomerName,
                            Contact = x.Contact,
                            TEL = x.TEL,
                            Creator = x.Creator,
                            CreationTime = x.CreationTime,
                            Customer = x.Customer,
                        });
            return query;
        }

        /// <summary>
        /// 【CustomerDetail】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<CustomerDetail> Query()
        {
            return _customerdetailRepository.GetAll();
        }
        /// <summary>
        /// 【CustomerDetail】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<CustomerDetail> QueryAsNoTracking()
        {
            return _customerdetailRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【CustomerDetail】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<CustomerDetail> FindByIdAsync(long id)
        {
            var entity = await _customerdetailRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【CustomerDetail】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _customerdetailRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【CustomerDetail】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CustomerDetail> CreateAsync(CustomerDetail entity)
        {
            entity.Id = await _customerdetailRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【CustomerDetail】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(CustomerDetail entity)
        {
            await _customerdetailRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【CustomerDetail】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerdetailRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【CustomerDetail】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerdetailRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
