
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ReceiptDetailAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ReceiptDetailPermissions
	{
		/// <summary>
		/// 【WMS_ReceiptDetail】权限节点
		///</summary>
		public const string Node = "Pages.WMS_ReceiptDetail";

		/// <summary>
		/// 【WMS_ReceiptDetail】查询授权
		///</summary>
		public const string Query = "Pages.WMS_ReceiptDetail.Query";

		/// <summary>
		/// 【WMS_ReceiptDetail】创建权限
		///</summary>
		public const string Create = "Pages.WMS_ReceiptDetail.Create";

		/// <summary>
		/// 【WMS_ReceiptDetail】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_ReceiptDetail.Edit";

		/// <summary>
		/// 【WMS_ReceiptDetail】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_ReceiptDetail.Delete";

        /// <summary>
		/// 【WMS_ReceiptDetail】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_ReceiptDetail.BatchDelete";

		/// <summary>
		/// 【WMS_ReceiptDetail】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_ReceiptDetail.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

