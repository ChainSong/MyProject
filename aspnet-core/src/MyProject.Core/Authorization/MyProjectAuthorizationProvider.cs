using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyProject.Authorization
{
    public class MyProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Table_Columns, L("TableColumns"));
            context.CreatePermission(PermissionNames.Pages_Customers, L("Customers"));
            context.CreatePermission(PermissionNames.Pages_ASN, L("ASN"));
            context.CreatePermission(PermissionNames.Pages_ASN_Add, L("Add"));
            context.CreatePermission(PermissionNames.Pages_ASN_Delete, L("Delete"));
            context.CreatePermission(PermissionNames.Pages_ASN_Edit, L("Edit"));
            context.CreatePermission(PermissionNames.Pages_ASN_Query, L("Query"));
            context.CreatePermission(PermissionNames.Pages_ASN_Import, L("Import"));

            context.CreatePermission(PermissionNames.Pages_ASN_Export, L("Export"));
            context.CreatePermission(PermissionNames.Pages_Receipt, L("Receipt"));
            context.CreatePermission(PermissionNames.Pages_Receipt_Add, L("Add"));
            context.CreatePermission(PermissionNames.Pages_Receipt_Delete, L("Delete"));
            context.CreatePermission(PermissionNames.Pages_Receipt_Edit, L("Edit"));
            context.CreatePermission(PermissionNames.Pages_Receipt_Query, L("Query"));
            context.CreatePermission(PermissionNames.Pages_Receipt_Import, L("Import"));
            context.CreatePermission(PermissionNames.Pages_Receipt_Export, L("Export"));

    }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
        }
    }
}
