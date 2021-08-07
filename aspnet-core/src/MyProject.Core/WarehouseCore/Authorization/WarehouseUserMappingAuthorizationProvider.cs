

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
    /// See <see cref="WarehouseUserMappingPermissions" /> for all permission names. WarehouseUserMapping
    ///</summary>
    public class WarehouseUserMappingAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public WarehouseUserMappingAuthorizationProvider()
        {

        }


        public WarehouseUserMappingAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WarehouseUserMappingAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了WarehouseUserMapping 的权限。
            //var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            //var warehouseUserMapping = administration.CreateChildPermission(WarehouseUserMappingPermissions.WarehouseUserMapping_Node, L("WarehouseUserMapping"));
            //warehouseUserMapping.CreateChildPermission(WarehouseUserMappingPermissions.WarehouseUserMapping_Query, L("QueryWarehouseUserMapping"));
            //warehouseUserMapping.CreateChildPermission(WarehouseUserMappingPermissions.WarehouseUserMapping_Create, L("CreateWarehouseUserMapping"));
            //warehouseUserMapping.CreateChildPermission(WarehouseUserMappingPermissions.WarehouseUserMapping_Edit, L("EditWarehouseUserMapping"));
            //warehouseUserMapping.CreateChildPermission(WarehouseUserMappingPermissions.WarehouseUserMapping_Delete, L("DeleteWarehouseUserMapping"));
            //warehouseUserMapping.CreateChildPermission(WarehouseUserMappingPermissions.WarehouseUserMapping_BatchDelete, L("BatchDeleteWarehouseUserMapping"));
            //warehouseUserMapping.CreateChildPermission(WarehouseUserMappingPermissions.WarehouseUserMapping_ExportExcel, L("ExportToExcel"));


            //// custom codes



            //// custom codes end
        }

        //private static ILocalizableString L(string name)
        //{
        //    return new LocalizableString(name, AppConsts.LocalizationSourceName);
        //}
    }
}
