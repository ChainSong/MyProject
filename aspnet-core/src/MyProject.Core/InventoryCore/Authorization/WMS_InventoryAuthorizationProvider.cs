

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
    /// See <see cref="WMS_InventoryPermissions" /> for all permission names. WMS_Inventory
    ///</summary>
    public class WMS_InventoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_InventoryAuthorizationProvider()
		{

		}

       
        public WMS_InventoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_InventoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了WMS_Inventory 的权限。
//			var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

//			var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

//			var wMS_Inventory = administration.CreateChildPermission(WMS_InventoryPermissions.WMS_Inventory_Node , L("WMS_Inventory"));
//wMS_Inventory.CreateChildPermission(WMS_InventoryPermissions.WMS_Inventory_Query, L("QueryWMS_Inventory"));
//wMS_Inventory.CreateChildPermission(WMS_InventoryPermissions.WMS_Inventory_Create, L("CreateWMS_Inventory"));
//wMS_Inventory.CreateChildPermission(WMS_InventoryPermissions.WMS_Inventory_Edit, L("EditWMS_Inventory"));
//wMS_Inventory.CreateChildPermission(WMS_InventoryPermissions.WMS_Inventory_Delete, L("DeleteWMS_Inventory"));
//wMS_Inventory.CreateChildPermission(WMS_InventoryPermissions.WMS_Inventory_BatchDelete, L("BatchDeleteWMS_Inventory"));
//wMS_Inventory.CreateChildPermission(WMS_InventoryPermissions.WMS_Inventory_ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		//private static ILocalizableString L(string name)
		//{
		//	return new LocalizableString(name, AppConsts.LocalizationSourceName);
		//}
    }
}
