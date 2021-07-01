

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.ASNCode.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_ASNDetailManager : MyProjectDomainServiceBase, IWMS_ASNDetailManager
    {

        private readonly IRepository<WMS_ASNDetail, long> _wMS_ASNDetailRepository;

        /// <summary>
        /// WMS_ASNDetail的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WMS_ASNDetailManager(IRepository<WMS_ASNDetail, long> wMS_ASNDetailRepository)
        {
            _wMS_ASNDetailRepository = wMS_ASNDetailRepository;
        }

        #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_ASNDetail> QueryWMS_ASNDetails()
        {
            return _wMS_ASNDetailRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_ASNDetail> QueryWMS_ASNDetailsAsNoTracking()
        {
            return _wMS_ASNDetailRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_ASNDetail> FindByIdAsync(long id)
        {
            var entity = await _wMS_ASNDetailRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wMS_ASNDetailRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion



        public async Task<WMS_ASNDetail> CreateAsync(WMS_ASNDetail entity)
        {
            entity.Id = await _wMS_ASNDetailRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(WMS_ASNDetail entity)
        {
            await _wMS_ASNDetailRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ASNDetailRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ASNDetailRepository.DeleteAsync(a => input.Contains(a.Id));
        }


        //// custom codes



        //// custom codes end







    }
}
