
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_Inventory_UsableAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_Inventory_UsablePermissions
	{
		/// <summary>
		/// 【WMS_Inventory_Usable】权限节点
		///</summary>
		public const string Node = "Pages.InventoryUsable";

		/// <summary>
		/// 【WMS_Inventory_Usable】查询授权
		///</summary>
		public const string Query = "Pages.InventoryUsable.Query";

		/// <summary>
		/// 【WMS_Inventory_Usable】创建权限
		///</summary>
		public const string Create = "Pages.InventoryUsable.Create";

		/// <summary>
		/// 【WMS_Inventory_Usable】修改权限
		///</summary>
		public const string Edit = "Pages.InventoryUsable.Edit";

		/// <summary>
		/// 【WMS_Inventory_Usable】删除权限
		///</summary>
		public const string Delete = "Pages.InventoryUsable.Delete";

        /// <summary>
		/// 【WMS_Inventory_Usable】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.InventoryUsable.BatchDelete";

		/// <summary>
		/// 【WMS_Inventory_Usable】导出Excel
		///</summary>
		//public const string ExportExcel="Pages.Inventory_Usable.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

