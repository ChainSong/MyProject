
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_PackageDetailAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_PackageDetailPermissions
	{
		/// <summary>
		/// 【WMS_PackageDetail】权限节点
		///</summary>
		public const string Node = "Pages.WMS_PackageDetail";

		/// <summary>
		/// 【WMS_PackageDetail】查询授权
		///</summary>
		public const string Query = "Pages.WMS_PackageDetail.Query";

		/// <summary>
		/// 【WMS_PackageDetail】创建权限
		///</summary>
		public const string Create = "Pages.WMS_PackageDetail.Create";

		/// <summary>
		/// 【WMS_PackageDetail】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_PackageDetail.Edit";

		/// <summary>
		/// 【WMS_PackageDetail】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_PackageDetail.Delete";

        /// <summary>
		/// 【WMS_PackageDetail】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_PackageDetail.BatchDelete";

		/// <summary>
		/// 【WMS_PackageDetail】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_PackageDetail.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

