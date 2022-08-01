
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
    public class CustomerManager :DomainServiceBase, ICustomerManager
    {
		
		private readonly IRepository<Customer,long> _customerRepository;

		/// <summary>
		/// 【Customer】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public CustomerManager(IRepository<Customer, long> customerRepository)	{
			_customerRepository =  customerRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<Customer> QueryEntityListAsNoTracking() { 

            var query = _customerRepository.GetAll().AsNoTracking()
                        .Select(x => new Customer
                        {
                           
                            ProjectId = x.ProjectId,
                            CustomerCode = x.CustomerCode,
                            CustomerName = x.CustomerName,
                            Description = x.Description,
                            CustomerType = x.CustomerType,
                            CustomerStatus = x.CustomerStatus,
                            CreditLine = x.CreditLine,
                            Province = x.Province,
                            City = x.City,
                            Address = x.Address,
                            Remark = x.Remark,
                            Email = x.Email,
                            Phone = x.Phone,
                            LawPerson = x.LawPerson,
                            PostCode = x.PostCode,
                            Bank = x.Bank,
                            Account = x.Account,
                            TaxId = x.TaxId,
                            InvoiceTitle = x.InvoiceTitle,
                            Fax = x.Fax,
                            WebSite = x.WebSite,
                            Creator = x.Creator,
                            Updator = x.Updator,
                            CreationTime = x.CreationTime,
                        });
            return query;
        }

        /// <summary>
        /// 【Customer】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<Customer> Query()
        {
            return _customerRepository.GetAll();
        }
        /// <summary>
        /// 【Customer】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<Customer> QueryAsNoTracking()
        {
            return _customerRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【Customer】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<Customer> FindByIdAsync(long id)
        {
            var entity = await _customerRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【Customer】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _customerRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【Customer】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> CreateAsync(Customer entity)
        {
            entity.Id = await _customerRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【Customer】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Customer entity)
        {
            await _customerRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【Customer】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【Customer】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
