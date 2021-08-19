

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.ReceiptReceivingCore.DomainService
{
    /// <summary>
    /// 的领域服务方法
    ///</summary>
    public class WMS_ReceiptReceivingManager : MyProjectDomainServiceBase, IWMS_ReceiptReceivingManager
    {


        /// <summary>
        /// WMS_ReceiptReceiving的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        //   public WMS_ReceiptReceivingManager(IServiceProvider serviceProvider) : base(serviceProvider)	
        //      {

        //}

        private readonly IRepository<WMS_ReceiptReceiving, long> _wMS_ReceiptReceivingRepository;

        /// <summary>
        /// WMS_Receipt的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WMS_ReceiptReceivingManager(IRepository<WMS_ReceiptReceiving, long> wMS_ReceiptReceivingRepository)
        {
            _wMS_ReceiptReceivingRepository = wMS_ReceiptReceivingRepository;
        }



        public async Task<WMS_ReceiptReceiving> CreateAsync(WMS_ReceiptReceiving entity)
        {
            entity.Id = await _wMS_ReceiptReceivingRepository.InsertAndGetIdAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(WMS_ReceiptReceiving entity)
        {
            await _wMS_ReceiptReceivingRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptReceivingRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptReceivingRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wMS_ReceiptReceivingRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        //// custom codes



        //// custom codes end







    }
}
