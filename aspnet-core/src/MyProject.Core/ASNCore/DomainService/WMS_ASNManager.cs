

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.ASNCore.DomainService
{
    /// <summary>
    /// 的领域服务方法
    ///</summary>
    public class WMS_ASNManager : MyProjectDomainServiceBase, IWMS_ASNManager
    {


        private readonly IRepository<WMS_ASN, long> _wMS_ASNRepository;

        /// <summary>
        /// WMS_ASN的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WMS_ASNManager(IRepository<WMS_ASN, long> wMS_ASNDetailRepository)
        {
            _wMS_ASNRepository = wMS_ASNDetailRepository;
        }

        #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_ASN> QueryWMS_ASNs()
        {
            return _wMS_ASNRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_ASN> QueryWMS_ASNsAsNoTracking()
        {
            return _wMS_ASNRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_ASN> FindByIdAsync(long id)
        {
            var entity = await _wMS_ASNRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wMS_ASNRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion



        public async Task<WMS_ASN> CreateAsync(WMS_ASN entity)
        {
            entity.Id = await _wMS_ASNRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(WMS_ASN entity)
        {
            await _wMS_ASNRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ASNRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ASNRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        //// custom codes



        //// custom codes end







    }
}
