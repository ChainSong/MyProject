
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CustomerUserMappingAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class CustomerUserMappingPermissions
	{
		/// <summary>
		/// 【CustomerUserMapping】权限节点
		///</summary>
		public const string Node = "Pages.CustomerUserMapping";

		/// <summary>
		/// 【CustomerUserMapping】查询授权
		///</summary>
		public const string Query = "Pages.CustomerUserMapping.Query";

		/// <summary>
		/// 【CustomerUserMapping】创建权限
		///</summary>
		public const string Create = "Pages.CustomerUserMapping.Create";

		/// <summary>
		/// 【CustomerUserMapping】修改权限
		///</summary>
		public const string Edit = "Pages.CustomerUserMapping.Edit";

		/// <summary>
		/// 【CustomerUserMapping】删除权限
		///</summary>
		public const string Delete = "Pages.CustomerUserMapping.Delete";

        /// <summary>
		/// 【CustomerUserMapping】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.CustomerUserMapping.BatchDelete";

		/// <summary>
		/// 【CustomerUserMapping】导出Excel
		///</summary>
		public const string ExportExcel="Pages.CustomerUserMapping.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

