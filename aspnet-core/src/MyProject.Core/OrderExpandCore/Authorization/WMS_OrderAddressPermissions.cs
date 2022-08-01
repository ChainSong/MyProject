
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_OrderAddressAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_OrderAddressPermissions
	{
		/// <summary>
		/// 【WMS_OrderAddress】权限节点
		///</summary>
		public const string Node = "Pages.WMS_OrderAddress";

		/// <summary>
		/// 【WMS_OrderAddress】查询授权
		///</summary>
		public const string Query = "Pages.WMS_OrderAddress.Query";

		/// <summary>
		/// 【WMS_OrderAddress】创建权限
		///</summary>
		public const string Create = "Pages.WMS_OrderAddress.Create";

		/// <summary>
		/// 【WMS_OrderAddress】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_OrderAddress.Edit";

		/// <summary>
		/// 【WMS_OrderAddress】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_OrderAddress.Delete";

        /// <summary>
		/// 【WMS_OrderAddress】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_OrderAddress.BatchDelete";

		/// <summary>
		/// 【WMS_OrderAddress】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_OrderAddress.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

