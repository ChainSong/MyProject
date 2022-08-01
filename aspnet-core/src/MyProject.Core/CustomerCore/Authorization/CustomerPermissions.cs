
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CustomerAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class CustomerPermissions
	{
		/// <summary>
		/// 【Customer】权限节点
		///</summary>
		public const string Node = "Pages.Customer";

		/// <summary>
		/// 【Customer】查询授权
		///</summary>
		public const string Query = "Pages.Customer.Query";

		/// <summary>
		/// 【Customer】创建权限
		///</summary>
		public const string Create = "Pages.Customer.Create";

		/// <summary>
		/// 【Customer】修改权限
		///</summary>
		public const string Edit = "Pages.Customer.Edit";

		/// <summary>
		/// 【Customer】删除权限
		///</summary>
		public const string Delete = "Pages.Customer.Delete";

        /// <summary>
		/// 【Customer】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Customer.BatchDelete";

		/// <summary>
		/// 【Customer】导出Excel
		///</summary>
		public const string ExportExcel="Pages.Customer.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

