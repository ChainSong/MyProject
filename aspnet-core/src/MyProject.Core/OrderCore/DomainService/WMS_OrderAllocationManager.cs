
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.OrderCore.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class WMS_OrderAllocationManager :DomainServiceBase, IWMS_OrderAllocationManager
    {
		
		private readonly IRepository<WMS_OrderAllocation,long> _wms_orderallocationRepository;

		/// <summary>
		/// 【WMS_OrderAllocation】的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	    public WMS_OrderAllocationManager(IRepository<WMS_OrderAllocation, long> wms_orderallocationRepository)	{
			_wms_orderallocationRepository =  wms_orderallocationRepository;
		}

		#region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 返回列表查询用
        /// </summary>
        /// <returns></returns>
        public IQueryable<WMS_OrderAllocation> QueryEntityListAsNoTracking() { 

            var query = _wms_orderallocationRepository.GetAll().AsNoTracking()
                        .Select(x => new WMS_OrderAllocation
                        {
                           
                            InventoryId = x.InventoryId,
                            OrderId = x.OrderId,
                            OrderDetailId = x.OrderDetailId,
                            CustomerId = x.CustomerId,
                            CustomerName = x.CustomerName,
                            WarehouseId = x.WarehouseId,
                            WarehouseName = x.WarehouseName,
                            Area = x.Area,
                            Location = x.Location,
                            SKU = x.SKU,
                            UPC = x.UPC,
                            GoodsType = x.GoodsType,
                            InventoryStatus = x.InventoryStatus,
                            SuperId = x.SuperId,
                            RelatedId = x.RelatedId,
                            GoodsName = x.GoodsName,
                            UnitCode = x.UnitCode,
                            Onwer = x.Onwer,
                            BoxCode = x.BoxCode,
                            TrayCode = x.TrayCode,
                            BatchCode = x.BatchCode,
                            Qty = x.Qty,
                            Remark = x.Remark,
                            Str1 = x.Str1,
                            Str2 = x.Str2,
                            Str3 = x.Str3,
                            Str4 = x.Str4,
                            Str5 = x.Str5,
                            Int1 = x.Int1,
                            Int2 = x.Int2,
                        });
            return query;
        }

        /// <summary>
        /// 【WMS_OrderAllocation】返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_OrderAllocation> Query()
        {
            return _wms_orderallocationRepository.GetAll();
        }
        /// <summary>
        /// 【WMS_OrderAllocation】返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<WMS_OrderAllocation> QueryAsNoTracking()
        {
            return _wms_orderallocationRepository.GetAll().AsNoTracking();
        }
        /// <summary>
        /// 【WMS_OrderAllocation】根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>实体</returns>
        public async Task<WMS_OrderAllocation> FindByIdAsync(long id)
        {
            var entity = await _wms_orderallocationRepository.GetAsync(id);
            return entity;
        }
        /// <summary>
        /// 【WMS_OrderAllocation】检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _wms_orderallocationRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }
		/// <summary>
        /// 【WMS_OrderAllocation】创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WMS_OrderAllocation> CreateAsync(WMS_OrderAllocation entity)
        {
            entity.Id = await _wms_orderallocationRepository.InsertAndGetIdAsync(entity);
            return entity;
        }
        /// <summary>
        /// 【WMS_OrderAllocation】更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateAsync(WMS_OrderAllocation entity)
        {
            await _wms_orderallocationRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 【WMS_OrderAllocation】删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_orderallocationRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 【WMS_OrderAllocation】批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_orderallocationRepository.DeleteAsync(a => input.Contains(a.Id));
        }
	    #endregion


        #region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
			
		



		 
		  
		 

	}
}
