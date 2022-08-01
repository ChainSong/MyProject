

// ReSharper disable once CheckNamespace
namespace MyProject.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="Table_ColumnsAuthorizationProvider" />中对权限的定义.
    ///</summary>
    public static class Table_ColumnsPermissions
    {
        /// <summary>
        /// Table_Columns权限节点
        ///</summary>
        public const string Table_Columns_Node = "Pages.Table_Columns";

        /// <summary>
        /// Table_Columns查询授权
        ///</summary>
        public const string Table_Columns_Query = Table_Columns_Node + ".Query";

        /// <summary>
        /// Table_Columns创建权限
        ///</summary>
        public const string Table_Columns_Create = Table_Columns_Node + ".Create";

        /// <summary>
        /// Table_Columns修改权限
        ///</summary>
        public const string Table_Columns_Edit = Table_Columns_Node + ".Edit";

        /// <summary>
        /// Table_Columns删除权限
        ///</summary>
        public const string Table_Columns_Delete = Table_Columns_Node + ".Delete";

        /// <summary>
		/// Table_Columns批量删除权限
		///</summary>
		public const string Table_Columns_BatchDelete = Table_Columns_Node + ".BatchDelete";

        /// <summary>
        /// Table_Columns导出Excel
        ///</summary>
        public const string Table_Columns_ExportExcel = Table_Columns_Node + ".ExportExcel";



        //// custom codes



        //// custom codes end

    }

}

