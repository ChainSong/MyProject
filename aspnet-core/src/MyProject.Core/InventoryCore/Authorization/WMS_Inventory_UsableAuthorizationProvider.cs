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
    /// See <see cref="WMS_Inventory_UsablePermissions" /> for all permission names. WMS_Inventory_Usable
    ///</summary>
    public class WMS_Inventory_UsableAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_Inventory_UsableAuthorizationProvider()
		{

		}

        public WMS_Inventory_UsableAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_Inventory_UsableAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_Inventory_UsablePermissions.Node , L("WMS_Inventory_Usable"));
			permission.CreateChildPermission(WMS_Inventory_UsablePermissions.Query, L("QueryWMS_Inventory_Usable"));
			permission.CreateChildPermission(WMS_Inventory_UsablePermissions.Create, L("CreateWMS_Inventory_Usable"));
			permission.CreateChildPermission(WMS_Inventory_UsablePermissions.Edit, L("EditWMS_Inventory_Usable"));
			permission.CreateChildPermission(WMS_Inventory_UsablePermissions.Delete, L("DeleteWMS_Inventory_Usable"));
			permission.CreateChildPermission(WMS_Inventory_UsablePermissions.BatchDelete, L("BatchDeleteWMS_Inventory_Usable"));
			permission.CreateChildPermission(WMS_Inventory_UsablePermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
