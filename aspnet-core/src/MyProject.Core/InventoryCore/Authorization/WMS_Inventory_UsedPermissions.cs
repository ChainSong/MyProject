
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_Inventory_UsedAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_Inventory_UsedPermissions
	{
		/// <summary>
		/// 【WMS_Inventory_Used】权限节点
		///</summary>
		public const string Node = "Pages.WMS_Inventory_Used";

		/// <summary>
		/// 【WMS_Inventory_Used】查询授权
		///</summary>
		public const string Query = "Pages.WMS_Inventory_Used.Query";

		/// <summary>
		/// 【WMS_Inventory_Used】创建权限
		///</summary>
		public const string Create = "Pages.WMS_Inventory_Used.Create";

		/// <summary>
		/// 【WMS_Inventory_Used】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_Inventory_Used.Edit";

		/// <summary>
		/// 【WMS_Inventory_Used】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_Inventory_Used.Delete";

        /// <summary>
		/// 【WMS_Inventory_Used】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_Inventory_Used.BatchDelete";

		/// <summary>
		/// 【WMS_Inventory_Used】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_Inventory_Used.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

