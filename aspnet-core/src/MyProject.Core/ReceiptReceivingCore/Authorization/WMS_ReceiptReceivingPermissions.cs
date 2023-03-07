
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ReceiptReceivingAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ReceiptReceivingPermissions
	{
		/// <summary>
		/// 【WMS_ReceiptReceiving】权限节点
		///</summary>
		public const string Node = "Pages.ReceiptReceiving";

		/// <summary>
		/// 【WMS_ReceiptReceiving】查询授权
		///</summary>
		public const string Query = "Pages.ReceiptReceiving.Query";

		/// <summary>
		/// 【WMS_ReceiptReceiving】创建权限
		///</summary>
		public const string Create = "Pages.ReceiptReceiving.Create";

		/// <summary>
		/// 【WMS_ReceiptReceiving】修改权限
		///</summary>
		public const string Edit = "Pages.ReceiptReceiving.Edit";

		/// <summary>
		/// 【WMS_ReceiptReceiving】删除权限
		///</summary>
		public const string Delete = "Pages.ReceiptReceiving.Delete";

        /// <summary>
		/// 【WMS_ReceiptReceiving】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.ReceiptReceiving.BatchDelete";

		/// <summary>
		/// 【WMS_ReceiptReceiving】导出Excel
		///</summary>
		public const string ExportExcel="Pages.ReceiptReceiving.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

