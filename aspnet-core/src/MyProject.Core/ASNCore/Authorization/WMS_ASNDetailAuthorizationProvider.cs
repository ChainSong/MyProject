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
    /// See <see cref="WMS_ASNDetailPermissions" /> for all permission names. WMS_ASNDetail
    ///</summary>
    public class WMS_ASNDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_ASNDetailAuthorizationProvider()
		{

		}

        public WMS_ASNDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ASNDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_ASNDetailPermissions.Node , L("WMS_ASNDetail"));
			permission.CreateChildPermission(WMS_ASNDetailPermissions.Query, L("QueryWMS_ASNDetail"));
			permission.CreateChildPermission(WMS_ASNDetailPermissions.Create, L("CreateWMS_ASNDetail"));
			permission.CreateChildPermission(WMS_ASNDetailPermissions.Edit, L("EditWMS_ASNDetail"));
			permission.CreateChildPermission(WMS_ASNDetailPermissions.Delete, L("DeleteWMS_ASNDetail"));
			permission.CreateChildPermission(WMS_ASNDetailPermissions.BatchDelete, L("BatchDeleteWMS_ASNDetail"));
			permission.CreateChildPermission(WMS_ASNDetailPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
