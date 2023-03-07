
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_PreOrderAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_PreOrderPermissions
	{
		/// <summary>
		/// 【WMS_PreOrder】权限节点
		///</summary>
		public const string Node = "Pages.PreOrder";

		/// <summary>
		/// 【WMS_PreOrder】查询授权
		///</summary>
		public const string Query = "Pages.PreOrder.Query";

		/// <summary>
		/// 【WMS_PreOrder】创建权限
		///</summary>
		public const string Create = "Pages.PreOrder.Create";

		/// <summary>
		/// 【WMS_PreOrder】修改权限
		///</summary>
		public const string Edit = "Pages.PreOrder.Edit";

		/// <summary>
		/// 【WMS_PreOrder】删除权限
		///</summary>
		public const string Delete = "Pages.PreOrder.Delete";

        /// <summary>
		/// 【WMS_PreOrder】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.PreOrder.BatchDelete";

		/// <summary>
		/// 【WMS_PreOrder】批量自动分配权限
		///</summary>
		//public const string BatchAutomatedOutbound = "Pages.PreOrder.BatchAutomatedOutbound";

		/// <summary>
		/// 【WMS_PreOrder】预出库单转出库单
		///</summary>
		public const string PreOrderForOrder = "Pages.PreOrder.PreOrderForOrder";
		
		/// <summary>
		/// 【WMS_PreOrder】导出Excel
		///</summary>
		public const string ExportExcel="Pages.PreOrder.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

