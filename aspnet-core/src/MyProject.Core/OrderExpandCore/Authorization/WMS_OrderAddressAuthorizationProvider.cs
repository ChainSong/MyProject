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
    /// See <see cref="WMS_OrderAddressPermissions" /> for all permission names. WMS_OrderAddress
    ///</summary>
    public class WMS_OrderAddressAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_OrderAddressAuthorizationProvider()
		{

		}

        public WMS_OrderAddressAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_OrderAddressAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_OrderAddressPermissions.Node , L("WMS_OrderAddress"));
			permission.CreateChildPermission(WMS_OrderAddressPermissions.Query, L("QueryWMS_OrderAddress"));
			permission.CreateChildPermission(WMS_OrderAddressPermissions.Create, L("CreateWMS_OrderAddress"));
			permission.CreateChildPermission(WMS_OrderAddressPermissions.Edit, L("EditWMS_OrderAddress"));
			permission.CreateChildPermission(WMS_OrderAddressPermissions.Delete, L("DeleteWMS_OrderAddress"));
			permission.CreateChildPermission(WMS_OrderAddressPermissions.BatchDelete, L("BatchDeleteWMS_OrderAddress"));
			permission.CreateChildPermission(WMS_OrderAddressPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
