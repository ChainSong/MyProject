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
    /// See <see cref="WMS_PackagePermissions" /> for all permission names. WMS_Package
    ///</summary>
    public class WMS_PackageAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_PackageAuthorizationProvider()
		{

		}

        public WMS_PackageAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_PackageAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_PackagePermissions.Node , L("WMS_Package"));
			permission.CreateChildPermission(WMS_PackagePermissions.Query, L("QueryWMS_Package"));
			permission.CreateChildPermission(WMS_PackagePermissions.Create, L("CreateWMS_Package"));
			permission.CreateChildPermission(WMS_PackagePermissions.Edit, L("EditWMS_Package"));
			permission.CreateChildPermission(WMS_PackagePermissions.Delete, L("DeleteWMS_Package"));
			permission.CreateChildPermission(WMS_PackagePermissions.BatchDelete, L("BatchDeleteWMS_Package"));
			permission.CreateChildPermission(WMS_PackagePermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
