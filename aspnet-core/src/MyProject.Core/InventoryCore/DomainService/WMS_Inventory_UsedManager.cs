
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
    public class WMS_Inventory_UsedManager :DomainServiceBase, IWMS_Inventory_UsedManager
    {
		
		private readonly IRepository<WMS_Inventory_Used,long> _wms_inventory_usedRepository;

		/// <summary>
		/// 【WMS_Inventory_Used】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_Inventory_UsedManager(IRepository<WMS_Inventory_Used, long> wms_inventory_usedRepository)	{
			_wms_inventory_usedRepository =  wms_inventory_usedRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_Inventory_Used> QueryEntityListAsNoTracking() { 

            var query = _wms_inventory_usedRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_Inventory_Used
                        {
                           
                            CustomerId = x.CustomerId,
                            CustomerName = x.CustomerName,
                            WarehouseName = x.WarehouseName,
                            Area = x.Area,
                            Location = x.Location,
                            SKU = x.SKU,
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
        /// 【WMS_Inventory_Used】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Inventory_Used> Query()
        {
            return _wms_inventory_usedRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_Inventory_Used】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_Inventory_Used> QueryAsNoTracking()
        {
            return _wms_inventory_usedRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_Inventory_Used】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_Inventory_Used> FindByIdAsync(long id)
        {
            var entity = await _wms_inventory_usedRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_Inventory_Used】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_inventory_usedRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_Inventory_Used】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_Inventory_Used> CreateAsync(WMS_Inventory_Used entity)
        {
            entity.Id = await _wms_inventory_usedRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_Inventory_Used】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_Inventory_Used entity)
        {
            await _wms_inventory_usedRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_Inventory_Used】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_inventory_usedRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_Inventory_Used】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_inventory_usedRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
