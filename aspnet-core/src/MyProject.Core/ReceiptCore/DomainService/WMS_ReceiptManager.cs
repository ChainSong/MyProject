

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
    public class WMS_ReceiptManager : MyProjectDomainServiceBase, IWMS_ReceiptManager
    {


        /// <summary>
        /// WMS_Receipt的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        //   public WMS_ReceiptManager(IServiceProvider serviceProvider) : base(serviceProvider)	
        //      {

        //}
        private readonly IRepository<WMS_Receipt, long> _wMS_ReceiptRepository;

        /// <summary>
        /// WMS_Receipt的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WMS_ReceiptManager(IRepository<WMS_Receipt, long> wMS_ReceiptRepository)
        {
            _wMS_ReceiptRepository = wMS_ReceiptRepository;
        }



        public async Task<WMS_Receipt> CreateAsync(WMS_Receipt entity)
        {
            entity.Id = await _wMS_ReceiptRepository.InsertAndGetIdAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(WMS_Receipt entity)
        {
            await _wMS_ReceiptRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wMS_ReceiptRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        //// custom codes



        //// custom codes end







    }
}
