using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyProject.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="WMS_Inventory_UsedPermissions" /> for all permission names. WMS_Inventory_Used
    ///</summary>
    public class WMS_Inventory_UsedAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_Inventory_UsedAuthorizationProvider()
		{

		}

        public WMS_Inventory_UsedAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_Inventory_UsedAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_Inventory_UsedPermissions.Node , L("WMS_Inventory_Used"));
			permission.CreateChildPermission(WMS_Inventory_UsedPermissions.Query, L("QueryWMS_Inventory_Used"));
			permission.CreateChildPermission(WMS_Inventory_UsedPermissions.Create, L("CreateWMS_Inventory_Used"));
			permission.CreateChildPermission(WMS_Inventory_UsedPermissions.Edit, L("EditWMS_Inventory_Used"));
			permission.CreateChildPermission(WMS_Inventory_UsedPermissions.Delete, L("DeleteWMS_Inventory_Used"));
			permission.CreateChildPermission(WMS_Inventory_UsedPermissions.BatchDelete, L("BatchDeleteWMS_Inventory_Used"));
			permission.CreateChildPermission(WMS_Inventory_UsedPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
