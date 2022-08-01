
using Abp.Domain.Repositories;
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
    public class WMS_AreaManager :DomainServiceBase, IWMS_AreaManager
    {
		
		private readonly IRepository<WMS_Area,long> _wms_areaRepository;

		/// <summary>
		/// 【WMS_Area】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_AreaManager(IRepository<WMS_Area, long> wms_areaRepository)	{
			_wms_areaRepository =  wms_areaRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_Area> QueryEntityListAsNoTracking() { 

            var query = _wms_areaRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_Area
                        {
                           
                            WarehouseName = x.WarehouseName,
                            AreaName = x.AreaName,
                            AreaType = x.AreaType,
                            Remark = x.Remark,
                            Creator = x.Creator,
                            CreationTime = x.CreationTime,
                            Updator = x.Updator,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_Area】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Area> Query()
        {
            return _wms_areaRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_Area】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Area> QueryAsNoTracking()
        {
            return _wms_areaRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_Area】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_Area> FindByIdAsync(long id)
        {
            var entity = await _wms_areaRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_Area】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_areaRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_Area】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_Area> CreateAsync(WMS_Area entity)
        {
            entity.Id = await _wms_areaRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_Area】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_Area entity)
        {
            await _wms_areaRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_Area】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_areaRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_Area】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_areaRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
