
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_OrderAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_OrderPermissions
	{
		/// <summary>
		/// 【WMS_Order】权限节点
		///</summary>
		public const string Node = "Pages.Order";

		/// <summary>
		/// 【WMS_Order】查询授权
		///</summary>
		public const string Query = "Pages.Order.Query";

		/// <summary>
		/// 【WMS_Order】创建权限
		///</summary>
		public const string Create = "Pages.Order.Create";

		/// <summary>
		/// 【WMS_Order】修改权限
		///</summary>
		public const string Edit = "Pages.Order.Edit";

		/// <summary>
		/// 【WMS_Order】删除权限
		///</summary>
		public const string Delete = "Pages.Order.Delete";

        /// <summary>
		/// 【WMS_Order】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Order.BatchDelete";

		/// <summary>
		/// 【WMS_Order】自动分配权限
		///</summary>
		public const string AutomatedAllocation = "Pages.Order.AutomatedAllocation";
		
		/// <summary>
		/// 【WMS_Order】导出Excel
		///</summary>
		public const string ExportExcel="Pages.Order.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

