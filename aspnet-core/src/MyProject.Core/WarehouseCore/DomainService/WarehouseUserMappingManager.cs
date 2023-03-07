
using Abp.Domain.Repositories;
using Abp.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.WarehouseCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WarehouseUserMappingManager : DomainServiceBase, IWarehouseUserMappingManager
    {

        private readonly IRepository<WarehouseUserMapping, long> _warehouseusermappingRepository;

        /// <summary>
        /// 【WarehouseUserMapping】的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public WarehouseUserMappingManager(IRepository<WarehouseUserMapping, long> warehouseusermappingRepository)
        {
            _warehouseusermappingRepository = warehouseusermappingRepository;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WarehouseUserMapping> QueryEntityListAsNoTracking()
        {

            var query = _warehouseusermappingRepository.GetAll().AsNoTracking()
                        .Select(x => new WarehouseUserMapping
                        {

                            UserId = x.UserId,
                            UserName = x.UserName,
                            WarehouseId = x.WarehouseId,
                            WarehouseName = x.WarehouseName,
                            Status = x.Status,
                            Creator = x.Creator,
                            Updator = x.Updator,
                            CreationTime = x.CreationTime,
                        });
            return query;
        }

        /// <summary>
        /// 【WarehouseUserMapping】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WarehouseUserMapping> Query()
        {
            return _warehouseusermappingRepository.GetAll();
        }
        /// <summary>
        /// 【WarehouseUserMapping】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WarehouseUserMapping> QueryAsNoTracking()
        {
            return _warehouseusermappingRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WarehouseUserMapping】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WarehouseUserMapping> FindByIdAsync(long id)
        {
            var entity = await _warehouseusermappingRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WarehouseUserMapping】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _warehouseusermappingRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
        /// <summary>
        /// 【WarehouseUserMapping】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WarehouseUserMapping> CreateAsync(WarehouseUserMapping entity)
        {

            entity.Id = await _warehouseusermappingRepository.InsertAndGetIdAsync(entity);
            return entity;


        }
        /// <summary>
        /// 【WarehouseUserMapping】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WarehouseUserMapping entity)
        {
            await _warehouseusermappingRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WarehouseUserMapping】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _warehouseusermappingRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WarehouseUserMapping】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _warehouseusermappingRepository.DeleteAsync(a => input.Contains(a.Id));
        }
        #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展领域服务接口*/
        public async Task UserIdDelete(long input)
        {
            await _warehouseusermappingRepository.DeleteAsync(b => b.UserId == input);
        }

        #endregion









    }
}
