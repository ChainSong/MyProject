
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
    public class WMS_LocationManager :DomainServiceBase, IWMS_LocationManager
    {
		
		private readonly IRepository<WMS_Location,long> _wms_locationRepository;

		/// <summary>
		/// 【WMS_Location】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_LocationManager(IRepository<WMS_Location, long> wms_locationRepository)	{
			_wms_locationRepository =  wms_locationRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_Location> QueryEntityListAsNoTracking() { 

            var query = _wms_locationRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_Location
                        {
                           
                            WarehouseId = x.WarehouseId,
                            WarehouseName = x.WarehouseName,
                            AreaId = x.AreaId,
                            AreaName = x.AreaName,
                            Location = x.Location,
                            LocationType = x.LocationType,
                            Classification = x.Classification,
                            Category = x.Category,
                            ABCClassification = x.ABCClassification,
                            IsMultiLot = x.IsMultiLot,
                            IsMultiSKU = x.IsMultiSKU,
                            LocationLevel = x.LocationLevel,
                            GoodsPutOrder = x.GoodsPutOrder,
                            GoodsPickOrder = x.GoodsPickOrder,
                            SKU = x.SKU,
                            Creator = x.Creator,
                            CreationTime = x.CreationTime,
                            Updator = x.Updator,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_Location】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Location> Query()
        {
            return _wms_locationRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_Location】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Location> QueryAsNoTracking()
        {
            return _wms_locationRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_Location】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_Location> FindByIdAsync(long id)
        {
            var entity = await _wms_locationRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_Location】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_locationRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_Location】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_Location> CreateAsync(WMS_Location entity)
        {
            entity.Id = await _wms_locationRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_Location】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_Location entity)
        {
            await _wms_locationRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_Location】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_locationRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_Location】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_locationRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
