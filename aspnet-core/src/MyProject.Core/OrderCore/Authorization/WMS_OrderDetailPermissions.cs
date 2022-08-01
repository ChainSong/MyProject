
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_OrderDetailAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_OrderDetailPermissions
	{
		/// <summary>
		/// 【WMS_OrderDetail】权限节点
		///</summary>
		public const string Node = "Pages.WMS_OrderDetail";

		/// <summary>
		/// 【WMS_OrderDetail】查询授权
		///</summary>
		public const string Query = "Pages.WMS_OrderDetail.Query";

		/// <summary>
		/// 【WMS_OrderDetail】创建权限
		///</summary>
		public const string Create = "Pages.WMS_OrderDetail.Create";

		/// <summary>
		/// 【WMS_OrderDetail】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_OrderDetail.Edit";

		/// <summary>
		/// 【WMS_OrderDetail】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_OrderDetail.Delete";

        /// <summary>
		/// 【WMS_OrderDetail】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_OrderDetail.BatchDelete";

		/// <summary>
		/// 【WMS_OrderDetail】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_OrderDetail.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

