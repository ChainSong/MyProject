

// ReSharper disable once CheckNamespace
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_InventoryAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_InventoryPermissions
	{
		/// <summary>
		/// WMS_Inventory权限节点
		///</summary>
		public const string WMS_Inventory_Node = "Pages.WMS_Inventory";

		/// <summary>
		/// WMS_Inventory查询授权
		///</summary>
		public const string WMS_Inventory_Query = WMS_Inventory_Node+".Query";

		/// <summary>
		/// WMS_Inventory创建权限
		///</summary>
		public const string WMS_Inventory_Create = WMS_Inventory_Node+".Create";

		/// <summary>
		/// WMS_Inventory修改权限
		///</summary>
		public const string WMS_Inventory_Edit = WMS_Inventory_Node+".Edit";

		/// <summary>
		/// WMS_Inventory删除权限
		///</summary>
		public const string WMS_Inventory_Delete = WMS_Inventory_Node+".Delete";

        /// <summary>
		/// WMS_Inventory批量删除权限
		///</summary>
		public const string WMS_Inventory_BatchDelete = WMS_Inventory_Node+".BatchDelete";

		/// <summary>
		/// WMS_Inventory导出Excel
		///</summary>
		public const string WMS_Inventory_ExportExcel=WMS_Inventory_Node+".ExportExcel";

		 
		 
							//// custom codes
									
							

							//// custom codes end
         
    }

}

