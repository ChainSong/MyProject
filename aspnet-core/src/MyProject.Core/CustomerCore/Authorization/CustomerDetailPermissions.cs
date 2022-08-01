
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CustomerDetailAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class CustomerDetailPermissions
	{
		/// <summary>
		/// 【CustomerDetail】权限节点
		///</summary>
		public const string Node = "Pages.CustomerDetail";

		/// <summary>
		/// 【CustomerDetail】查询授权
		///</summary>
		public const string Query = "Pages.CustomerDetail.Query";

		/// <summary>
		/// 【CustomerDetail】创建权限
		///</summary>
		public const string Create = "Pages.CustomerDetail.Create";

		/// <summary>
		/// 【CustomerDetail】修改权限
		///</summary>
		public const string Edit = "Pages.CustomerDetail.Edit";

		/// <summary>
		/// 【CustomerDetail】删除权限
		///</summary>
		public const string Delete = "Pages.CustomerDetail.Delete";

        /// <summary>
		/// 【CustomerDetail】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.CustomerDetail.BatchDelete";

		/// <summary>
		/// 【CustomerDetail】导出Excel
		///</summary>
		public const string ExportExcel="Pages.CustomerDetail.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

