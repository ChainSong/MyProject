
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
    public class CustomerUserMappingManager : DomainServiceBase, ICustomerUserMappingManager
    {

        private readonly IRepository<CustomerUserMapping, long> _customerusermappingRepository;

        /// <summary>
        /// 【CustomerUserMapping】的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public CustomerUserMappingManager(IRepository<CustomerUserMapping, long> customerusermappingRepository)
        {
            _customerusermappingRepository = customerusermappingRepository;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<CustomerUserMapping> QueryEntityListAsNoTracking()
        {

            var query = _customerusermappingRepository.GetAll().AsNoTracking()
                        .Select(x => new CustomerUserMapping
                        {

                            UserId = x.UserId,
                            UserName = x.UserName,
                            CustomerId = x.CustomerId,
                            CustomerName = x.CustomerName,
                            Status = x.Status,
                            Creator = x.Creator,
                            Updator = x.Updator,
                            CreationTime = x.CreationTime,
                        });
            return query;
        }

        /// <summary>
        /// 【CustomerUserMapping】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<CustomerUserMapping> Query()
        {
            return _customerusermappingRepository.GetAll();
        }
        /// <summary>
        /// 【CustomerUserMapping】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<CustomerUserMapping> QueryAsNoTracking()
        {
            return _customerusermappingRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【CustomerUserMapping】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<CustomerUserMapping> FindByIdAsync(long id)
        {
            var entity = await _customerusermappingRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【CustomerUserMapping】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _customerusermappingRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
        /// <summary>
        /// 【CustomerUserMapping】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CustomerUserMapping> CreateAsync(CustomerUserMapping entity)
        {
            entity.Id = await _customerusermappingRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【CustomerUserMapping】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(CustomerUserMapping entity)
        {
            await _customerusermappingRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【CustomerUserMapping】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerusermappingRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【CustomerUserMapping】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerusermappingRepository.DeleteAsync(a => input.Contains(a.Id));
        }
        #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展领域服务接口*/

        /// <summary>
        /// 【CustomerUserMapping】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UserIdDelete(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerusermappingRepository.DeleteAsync(a => a.UserId == id);
        }

        public IQueryable<CustomerUserMapping> QueryWhere()
        {
            return _customerusermappingRepository.GetAll();
        }
        #endregion









    }
}
