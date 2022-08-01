
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_PackageAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_PackagePermissions
	{
		/// <summary>
		/// 【WMS_Package】权限节点
		///</summary>
		public const string Node = "Pages.WMS_Package";

		/// <summary>
		/// 【WMS_Package】查询授权
		///</summary>
		public const string Query = "Pages.WMS_Package.Query";

		/// <summary>
		/// 【WMS_Package】创建权限
		///</summary>
		public const string Create = "Pages.WMS_Package.Create";

		/// <summary>
		/// 【WMS_Package】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_Package.Edit";

		/// <summary>
		/// 【WMS_Package】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_Package.Delete";

        /// <summary>
		/// 【WMS_Package】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_Package.BatchDelete";

		/// <summary>
		/// 【WMS_Package】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_Package.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

