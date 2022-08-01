
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_LocationAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_LocationPermissions
	{
		/// <summary>
		/// 【WMS_Location】权限节点
		///</summary>
		public const string Node = "Pages.WMS_Location";

		/// <summary>
		/// 【WMS_Location】查询授权
		///</summary>
		public const string Query = "Pages.WMS_Location.Query";

		/// <summary>
		/// 【WMS_Location】创建权限
		///</summary>
		public const string Create = "Pages.WMS_Location.Create";

		/// <summary>
		/// 【WMS_Location】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_Location.Edit";

		/// <summary>
		/// 【WMS_Location】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_Location.Delete";

        /// <summary>
		/// 【WMS_Location】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_Location.BatchDelete";

		/// <summary>
		/// 【WMS_Location】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_Location.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

