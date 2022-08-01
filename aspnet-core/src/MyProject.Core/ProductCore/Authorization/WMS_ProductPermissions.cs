
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ProductAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ProductPermissions
	{
		/// <summary>
		/// 【WMS_Product】权限节点
		///</summary>
		public const string Node = "Pages.WMS_Product";

		/// <summary>
		/// 【WMS_Product】查询授权
		///</summary>
		public const string Query = "Pages.WMS_Product.Query";

		/// <summary>
		/// 【WMS_Product】创建权限
		///</summary>
		public const string Create = "Pages.WMS_Product.Create";

		/// <summary>
		/// 【WMS_Product】修改权限
		///</summary>
		public const string Edit = "Pages.WMS_Product.Edit";

		/// <summary>
		/// 【WMS_Product】删除权限
		///</summary>
		public const string Delete = "Pages.WMS_Product.Delete";

        /// <summary>
		/// 【WMS_Product】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.WMS_Product.BatchDelete";

		/// <summary>
		/// 【WMS_Product】导出Excel
		///</summary>
		public const string ExportExcel="Pages.WMS_Product.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

