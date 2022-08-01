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
    /// See <see cref="WMS_WarehousePermissions" /> for all permission names. WMS_Warehouse
    ///</summary>
    public class WMS_WarehouseAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_WarehouseAuthorizationProvider()
		{

		}

        public WMS_WarehouseAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_WarehouseAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_WarehousePermissions.Node , L("WMS_Warehouse"));
			permission.CreateChildPermission(WMS_WarehousePermissions.Query, L("QueryWMS_Warehouse"));
			permission.CreateChildPermission(WMS_WarehousePermissions.Create, L("CreateWMS_Warehouse"));
			permission.CreateChildPermission(WMS_WarehousePermissions.Edit, L("EditWMS_Warehouse"));
			permission.CreateChildPermission(WMS_WarehousePermissions.Delete, L("DeleteWMS_Warehouse"));
			permission.CreateChildPermission(WMS_WarehousePermissions.BatchDelete, L("BatchDeleteWMS_Warehouse"));
			permission.CreateChildPermission(WMS_WarehousePermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
