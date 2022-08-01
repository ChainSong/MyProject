using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace MyProject.PackageCore.DomainService
{
	/// <summary>
    /// 领域服务接口定义
    ///</summary>
    public interface IWMS_PackageManager : IDomainService
    {
		#region -------------------------------------------------辅助工具生成----------------------------------------------
		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型(可选择部分字段)
		/// </summary>
		/// <returns>IQueryable</returns>
		IQueryable<WMS_Package> QueryEntityListAsNoTracking();
		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型
		/// </summary>
		/// <returns>IQueryable</returns>
		IQueryable<WMS_Package> Query();
		/// <summary>
		/// 返回性能更好的IQueryable类型，但不包含EF Core跟踪标记
		/// </summary>
		/// <returns>IQueryable</returns>
		IQueryable<WMS_Package> QueryAsNoTracking();
		/// <summary>
		/// 【WMS_Package】根据Id查询实体信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns>实体</returns>
		Task<WMS_Package> FindByIdAsync(long id);
		/// <summary>
		/// 【WMS_Package】检查实体是否存在
		/// </summary>
		/// <returns>是否成功</returns>
		Task<bool> IsExistAsync(long id);
		/// <summary>
		/// 【WMS_Package】添加实体
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task<WMS_Package> CreateAsync(WMS_Package entity);
		/// <summary>
		/// 【WMS_Package】修改实体
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task UpdateAsync(WMS_Package entity);
		/// <summary>
		/// 【WMS_Package】删除实体
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(long id);
		/// <summary>
		/// 【WMS_Package】批量删除
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
