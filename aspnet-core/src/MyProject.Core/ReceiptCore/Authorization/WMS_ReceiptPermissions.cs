
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ReceiptAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ReceiptPermissions
	{
		/// <summary>
		/// 【WMS_Receipt】权限节点
		///</summary>
		public const string Node = "Pages.WMS_Receipt";

		/// <summary>
		/// 【WMS_Receipt】查询授权
		///</summary>
		public const string Query = "Pages.WMS_Receipt.Query";

		/// <summary>
		/// 【WMS_Receipt】创建权限
		///</summary>
		public const string Create = "Pages.WMS_Receipt.Create";

		/// <summary>
		/// 【WMS_Receipt】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_Receipt.Edit";

		/// <summary>
		/// 【WMS_Receipt】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_Receipt.Delete";

        /// <summary>
		/// 【WMS_Receipt】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_Receipt.BatchDelete";

		/// <summary>
		/// 【WMS_Receipt】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_Receipt.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

