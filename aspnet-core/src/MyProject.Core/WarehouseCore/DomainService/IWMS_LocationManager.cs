using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace MyProject.WarehouseCore.DomainService
{
	/// <summary>
    /// 领域服务接口定义
    ///</summary>
    public interface IWMS_LocationManager : IDomainService
    {
		#region -------------------------------------------------辅助工具生成----------------------------------------------
		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型(可选择部分字段)
		/// </summary>
		/// <returns>IQueryable</returns>
		IQueryable<WMS_Location> QueryEntityListAsNoTracking();
		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型
		/// </summary>
		/// <returns>IQueryable</returns>
		IQueryable<WMS_Location> Query();
		/// <summary>
		/// 返回性能更好的IQueryable类型，但不包含EF Core跟踪标记
		/// </summary>
		/// <returns>IQueryable</returns>
		IQueryable<WMS_Location> QueryAsNoTracking();
		/// <summary>
		/// 【WMS_Location】根据Id查询实体信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns>实体</returns>
		Task<WMS_Location> FindByIdAsync(long id);
		/// <summary>
		/// 【WMS_Location】检查实体是否存在
		/// </summary>
		/// <returns>是否成功</returns>
		Task<bool> IsExistAsync(long id);
		/// <summary>
		/// 【WMS_Location】添加实体
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task<WMS_Location> CreateAsync(WMS_Location entity);
		/// <summary>
		/// 【WMS_Location】修改实体
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task UpdateAsync(WMS_Location entity);
		/// <summary>
		/// 【WMS_Location】删除实体
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(long id);
		/// <summary>
		/// 【WMS_Location】批量删除
		/// </summary>
		/// <param name="input">Id的集合</param>
		/// <returns></returns>
		Task BatchDelete(List<long> input);
		#endregion

		#region -------------------------------------------------用户自定义------------------------------------------------
		/*请在此扩展领域服务接口*/
		#endregion
    }
}
