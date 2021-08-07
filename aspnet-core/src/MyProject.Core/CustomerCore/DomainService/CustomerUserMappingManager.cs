

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.CustomerCore.DomainService
{
    /// <summary>
    /// 的领域服务方法
    ///</summary>
    public class CustomerUserMappingManager : MyProjectDomainServiceBase, ICustomerUserMappingManager
    {

        private readonly IRepository<CustomerUserMapping, long> EntityRepo;
        public CustomerUserMappingManager(IRepository<CustomerUserMapping, long> customerUserMappingManagerRepository)
        {
            EntityRepo = customerUserMappingManagerRepository;
        }


        /// <summary>
        /// CustomerUserMapping的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        //      public CustomerUserMappingManager(IServiceProvider serviceProvider) : base(serviceProvider)	
        //      {

        //}




        public async Task<CustomerUserMapping> CreateAsync(CustomerUserMapping entity)
        {
            entity.Id = await EntityRepo.InsertAndGetIdAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(CustomerUserMapping entity)
        {
            await EntityRepo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await EntityRepo.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await EntityRepo.DeleteAsync(a => input.Contains(a.Id));
        }

        public async Task<bool> IsExistAsync(long id)
        {
            var result = await EntityRepo.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        //// custom codes



        //// custom codes end







    }
}
