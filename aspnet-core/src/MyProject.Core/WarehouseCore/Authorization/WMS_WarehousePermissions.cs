
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_WarehouseAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_WarehousePermissions
	{
		/// <summary>
		/// 【WMS_Warehouse】权限节点
		///</summary>
		public const string Node = "Pages.WMS_Warehouse";

		/// <summary>
		/// 【WMS_Warehouse】查询授权
		///</summary>
		public const string Query = "Pages.WMS_Warehouse.Query";

		/// <summary>
		/// 【WMS_Warehouse】创建权限
		///</summary>
		public const string Create = "Pages.WMS_Warehouse.Create";

		/// <summary>
		/// 【WMS_Warehouse】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_Warehouse.Edit";

		/// <summary>
		/// 【WMS_Warehouse】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_Warehouse.Delete";

        /// <summary>
		/// 【WMS_Warehouse】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_Warehouse.BatchDelete";

		/// <summary>
		/// 【WMS_Warehouse】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_Warehouse.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

