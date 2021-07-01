

// ReSharper disable once CheckNamespace
namespace MyProject.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="WMS_ASNAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class WMS_ASNPermissions
	{
		/// <summary>
		/// WMS_ASN权限节点
		///</summary>
		public const string WMS_ASN_Node = "Pages.WMS_ASN";

		/// <summary>
		/// WMS_ASN查询授权
		///</summary>
		public const string WMS_ASN_Query = WMS_ASN_Node+".Query";

		/// <summary>
		/// WMS_ASN创建权限
		///</summary>
		public const string WMS_ASN_Create = WMS_ASN_Node+".Create";

		/// <summary>
		/// WMS_ASN修改权限
		///</summary>
		public const string WMS_ASN_Edit = WMS_ASN_Node+".Edit";

		/// <summary>
		/// WMS_ASN删除权限
		///</summary>
		public const string WMS_ASN_Delete = WMS_ASN_Node+".Delete";

        /// <summary>
		/// WMS_ASN批量删除权限
		///</summary>
		public const string WMS_ASN_BatchDelete = WMS_ASN_Node+".BatchDelete";

		/// <summary>
		/// WMS_ASN导出Excel
		///</summary>
		public const string WMS_ASN_ExportExcel=WMS_ASN_Node+".ExportExcel";

		 
		 
							//// custom codes
									
							

							//// custom codes end
         
    }

}

