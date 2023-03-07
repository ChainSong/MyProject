
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_AreaAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_AreaPermissions
	{
		/// <summary>
		/// 【WMS_Area】权限节点
		///</summary>
		public const string Node = "Pages.Area";

		/// <summary>
		/// 【WMS_Area】查询授权
		///</summary>
		public const string Query = "Pages.Area.Query";

		/// <summary>
		/// 【WMS_Area】创建权限
		///</summary>
		public const string Create = "Pages.Area.Create";

		/// <summary>
		/// 【WMS_Area】修改权限
		///</summary>
		public const string Edit = "Pages.Area.Edit";

		/// <summary>
		/// 【WMS_Area】删除权限
		///</summary>
		public const string Delete = "Pages.Area.Delete";

        /// <summary>
		/// 【WMS_Area】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Area.BatchDelete";

		/// <summary>
		/// 【WMS_Area】导出Excel
		///</summary>
		public const string ExportExcel="Pages.Area.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

