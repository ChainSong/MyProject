

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using MyProject.Authorization;

// ReSharper disable once CheckNamespace
namespace MyProject.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="Table_ColumnsPermissions" /> for all permission names. Table_Columns
    ///</summary>
    public class Table_ColumnsAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public Table_ColumnsAuthorizationProvider()
        {

        }


        public Table_ColumnsAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public Table_ColumnsAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {

            //// 在这里配置了Table_Columns 的权限。
            //var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(Table_ColumnsPermissions.Pages_Administration, L("Administration"));
            //var table_Columns = administration.CreateChildPermission(Table_ColumnsPermissions.Table_Columns_Node, L("Table_Columns"));
            //table_Columns.CreateChildPermission(Table_ColumnsPermissions.Table_Columns_Query, L("QueryTable_Columns"));
            //table_Columns.CreateChildPermission(Table_ColumnsPermissions.Table_Columns_Create, L("CreateTable_Columns"));
            //table_Columns.CreateChildPermission(Table_ColumnsPermissions.Table_Columns_Edit, L("EditTable_Columns"));
            //table_Columns.CreateChildPermission(Table_ColumnsPermissions.Table_Columns_Delete, L("DeleteTable_Columns"));
            //table_Columns.CreateChildPermission(Table_ColumnsPermissions.Table_Columns_BatchDelete, L("BatchDeleteTable_Columns"));
            //table_Columns.CreateChildPermission(Table_ColumnsPermissions.Table_Columns_ExportExcel, L("ExportToExcel"));


            //// custom codes



            //// custom codes end
        }

        //private static ILocalizableString L(string name)
        //{
        //    return new LocalizableString(name, AppConsts.LocalizationSourceName);
        //}

        //public override void SetPermissions(IPermissionDefinitionContext context)
        //{
        //    context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
        //    context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
        //    context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
        //    context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        //}

        //private static ILocalizableString L(string name)
        //{
        //    return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
        //}
    }
}
