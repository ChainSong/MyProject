
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.InventoryCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_Inventory_UsableManager :DomainServiceBase, IWMS_Inventory_UsableManager
    {
		
		private readonly IRepository<WMS_Inventory_Usable,long> _wms_inventory_usableRepository;

		/// <summary>
		/// 【WMS_Inventory_Usable】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_Inventory_UsableManager(IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository)	{
			_wms_inventory_usableRepository =  wms_inventory_usableRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_Inventory_Usable> QueryEntityListAsNoTracking() { 

            var query = _wms_inventory_usableRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_Inventory_Usable
                        {
                           
                            CustomerId = x.CustomerId,
                            CustomerName = x.CustomerName,
                            WarehouseName = x.WarehouseName,
                            Area = x.Area,
                            Location = x.Location,
                            SKU = x.SKU,
                            UPC = x.UPC,
                            GoodsType = x.GoodsType,
                            GoodsName = x.GoodsName,
                            UnitCode = x.UnitCode,
                            Onwer = x.Onwer,
                            BoxCode = x.BoxCode,
                            TrayCode = x.TrayCode,
                            BatchCode = x.BatchCode,
                            Qty = x.Qty,
                            Remark = x.Remark,
                            InventoryTime = x.InventoryTime,
                            Creator = x.Creator,
                            CreationTime = x.CreationTime,
                            Updator = x.Updator,
                            Str1 = x.Str1,
                            Str2 = x.Str2,
                            Str3 = x.Str3,
                            Str4 = x.Str4,
                            Str5 = x.Str5,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_Inventory_Usable】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Inventory_Usable> Query()
        {
            return _wms_inventory_usableRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_Inventory_Usable】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Inventory_Usable> QueryAsNoTracking()
        {
            return _wms_inventory_usableRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_Inventory_Usable】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_Inventory_Usable> FindByIdAsync(long id)
        {
            var entity = await _wms_inventory_usableRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_Inventory_Usable】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_inventory_usableRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_Inventory_Usable】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_Inventory_Usable> CreateAsync(WMS_Inventory_Usable entity)
        {
            entity.Id = await _wms_inventory_usableRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_Inventory_Usable】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_Inventory_Usable entity)
        {
            await _wms_inventory_usableRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_Inventory_Usable】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_inventory_usableRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_Inventory_Usable】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_inventory_usableRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
