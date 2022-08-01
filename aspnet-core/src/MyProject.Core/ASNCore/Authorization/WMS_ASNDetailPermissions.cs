
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ASNDetailAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ASNDetailPermissions
	{
		/// <summary>
		/// 【WMS_ASNDetail】权限节点
		///</summary>
		public const string Node = "Pages.WMS_ASNDetail";

		/// <summary>
		/// 【WMS_ASNDetail】查询授权
		///</summary>
		public const string Query = "Pages.WMS_ASNDetail.Query";

		/// <summary>
		/// 【WMS_ASNDetail】创建权限
		///</summary>
		public const string Create = "Pages.WMS_ASNDetail.Create";

		/// <summary>
		/// 【WMS_ASNDetail】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_ASNDetail.Edit";

		/// <summary>
		/// 【WMS_ASNDetail】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_ASNDetail.Delete";

        /// <summary>
		/// 【WMS_ASNDetail】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_ASNDetail.BatchDelete";

		/// <summary>
		/// 【WMS_ASNDetail】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_ASNDetail.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

