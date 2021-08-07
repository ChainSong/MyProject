

// ReSharper disable once CheckNamespace
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WarehouseUserMappingAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WarehouseUserMappingPermissions
	{
		/// <summary>
		/// WarehouseUserMapping权限节点
		///</summary>
		public const string WarehouseUserMapping_Node = "Pages.WarehouseUserMapping";

		/// <summary>
		/// WarehouseUserMapping查询授权
		///</summary>
		public const string WarehouseUserMapping_Query = WarehouseUserMapping_Node+".Query";

		/// <summary>
		/// WarehouseUserMapping创建权限
		///</summary>
		public const string WarehouseUserMapping_Create = WarehouseUserMapping_Node+".Create";

		/// <summary>
		/// WarehouseUserMapping修改权限
		///</summary>
		public const string WarehouseUserMapping_Edit = WarehouseUserMapping_Node+".Edit";

		/// <summary>
		/// WarehouseUserMapping删除权限
		///</summary>
		public const string WarehouseUserMapping_Delete = WarehouseUserMapping_Node+".Delete";

        /// <summary>
		/// WarehouseUserMapping批量删除权限
		///</summary>
		public const string WarehouseUserMapping_BatchDelete = WarehouseUserMapping_Node+".BatchDelete";

		/// <summary>
		/// WarehouseUserMapping导出Excel
		///</summary>
		public const string WarehouseUserMapping_ExportExcel=WarehouseUserMapping_Node+".ExportExcel";

		 
		 
							//// custom codes
									
							

							//// custom codes end
         
    }

}

