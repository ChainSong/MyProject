

// ReSharper disable once CheckNamespace
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ReceiptDetailAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ReceiptDetailPermissions
	{
		/// <summary>
		/// WMS_ReceiptDetail权限节点
		///</summary>
		public const string WMS_ReceiptDetail_Node = "Pages.WMS_ReceiptDetail";

		/// <summary>
		/// WMS_ReceiptDetail查询授权
		///</summary>
		public const string WMS_ReceiptDetail_Query = WMS_ReceiptDetail_Node+".Query";

		/// <summary>
		/// WMS_ReceiptDetail创建权限
		///</summary>
		public const string WMS_ReceiptDetail_Create = WMS_ReceiptDetail_Node+".Create";

		/// <summary>
		/// WMS_ReceiptDetail修改权限
		///</summary>
		public const string WMS_ReceiptDetail_Edit = WMS_ReceiptDetail_Node+".Edit";

		/// <summary>
		/// WMS_ReceiptDetail删除权限
		///</summary>
		public const string WMS_ReceiptDetail_Delete = WMS_ReceiptDetail_Node+".Delete";

        /// <summary>
		/// WMS_ReceiptDetail批量删除权限
		///</summary>
		public const string WMS_ReceiptDetail_BatchDelete = WMS_ReceiptDetail_Node+".BatchDelete";

		/// <summary>
		/// WMS_ReceiptDetail导出Excel
		///</summary>
		public const string WMS_ReceiptDetail_ExportExcel=WMS_ReceiptDetail_Node+".ExportExcel";

		 
		 
							//// custom codes
									
							

							//// custom codes end
         
    }

}

