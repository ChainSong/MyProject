
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ASNAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ASNPermissions
	{
		/// <summary>
		/// 【WMS_ASN】权限节点
		///</summary>
		public const string Node = "Pages.ASN";

		/// <summary>
		/// 【WMS_ASN】查询授权
		///</summary>
		public const string Query = "Pages.ASN.Query";

		/// <summary>
		/// 【WMS_ASN】创建权限
		///</summary>
		public const string Create = "Pages.ASN.Create";

		/// <summary>
		/// 【WMS_ASN】修改权限
		///</summary>
		public const string Edit = "Pages.ASN.Edit";

		/// <summary>
		/// 【WMS_ASN】删除权限
		///</summary>
		public const string Delete = "Pages.ASN.Delete";

        /// <summary>
		/// 【WMS_ASN】批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.ASN.BatchDelete";

		/// <summary>
		/// 【WMS_ASN】导出Excel
		///</summary>
		public const string ExportExcel="Pages.ASN.ExportExcel";

		/* 以下可以自定义权限 */ 
		
         
    }

}

