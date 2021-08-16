

// ReSharper disable once CheckNamespace
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ReceiptAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ReceiptPermissions
	{
		/// <summary>
		/// WMS_Receipt权限节点
		///</summary>
		public const string WMS_Receipt_Node = "Pages.WMS_Receipt";

		/// <summary>
		/// WMS_Receipt查询授权
		///</summary>
		public const string WMS_Receipt_Query = WMS_Receipt_Node+".Query";

		/// <summary>
		/// WMS_Receipt创建权限
		///</summary>
		public const string WMS_Receipt_Create = WMS_Receipt_Node+".Create";

		/// <summary>
		/// WMS_Receipt修改权限
		///</summary>
		public const string WMS_Receipt_Edit = WMS_Receipt_Node+".Edit";

		/// <summary>
		/// WMS_Receipt删除权限
		///</summary>
		public const string WMS_Receipt_Delete = WMS_Receipt_Node+".Delete";

        /// <summary>
		/// WMS_Receipt批量删除权限
		///</summary>
		public const string WMS_Receipt_BatchDelete = WMS_Receipt_Node+".BatchDelete";

		/// <summary>
		/// WMS_Receipt导出Excel
		///</summary>
		public const string WMS_Receipt_ExportExcel=WMS_Receipt_Node+".ExportExcel";

		 
		 
							//// custom codes
									
							

							//// custom codes end
         
    }

}

