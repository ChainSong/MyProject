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
    /// See <see cref="WMS_PackageDetailPermissions" /> for all permission names. WMS_PackageDetail
    ///</summary>
    public class WMS_PackageDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_PackageDetailAuthorizationProvider()
		{

		}

        public WMS_PackageDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_PackageDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_PackageDetailPermissions.Node , L("WMS_PackageDetail"));
			permission.CreateChildPermission(WMS_PackageDetailPermissions.Query, L("QueryWMS_PackageDetail"));
			permission.CreateChildPermission(WMS_PackageDetailPermissions.Create, L("CreateWMS_PackageDetail"));
			permission.CreateChildPermission(WMS_PackageDetailPermissions.Edit, L("EditWMS_PackageDetail"));
			permission.CreateChildPermission(WMS_PackageDetailPermissions.Delete, L("DeleteWMS_PackageDetail"));
			permission.CreateChildPermission(WMS_PackageDetailPermissions.BatchDelete, L("BatchDeleteWMS_PackageDetail"));
			permission.CreateChildPermission(WMS_PackageDetailPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
