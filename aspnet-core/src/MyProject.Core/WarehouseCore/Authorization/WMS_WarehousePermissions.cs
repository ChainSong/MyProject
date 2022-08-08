
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
		public const string Node = "Pages.Warehouse";

		/// <summary>
		/// 【WMS_Warehouse】查询授权
		///</summary>
		public const string Query = "Pages.Warehouse.Query";

		/// <summary>
		/// 【WMS_Warehouse】创建权限
		///</summary>
		public const string Create = "Pages.Warehouse.Create";

		/// <summary>
		/// 【WMS_Warehouse】修改权限
		///</summary>
		public const string Edit = "Pages.Warehouse.Edit";

		/// <summary>
		/// 【WMS_Warehouse】删除权限
		///</summary>
		public const string Delete = "Pages.Warehouse.Delete";

        /// <summary>
		/// 【WMS_Warehouse】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Warehouse.BatchDelete";

		/// <summary>
		/// 【WMS_Warehouse】导出Excel
		///</summary>
		public const string ExportExcelWarehouse = "Pages.Warehouse.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

