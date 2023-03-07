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
    /// See <see cref="WMS_LocationPermissions" /> for all permission names. WMS_Location
    ///</summary>
    public class WMS_LocationAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_LocationAuthorizationProvider()
		{

		}

        public WMS_LocationAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_LocationAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_LocationPermissions.Node , L("WMS_Location"));
			permission.CreateChildPermission(WMS_LocationPermissions.Query, L("QueryWMS_Location"));
			permission.CreateChildPermission(WMS_LocationPermissions.Create, L("CreateWMS_Location"));
			permission.CreateChildPermission(WMS_LocationPermissions.Edit, L("EditWMS_Location"));
			permission.CreateChildPermission(WMS_LocationPermissions.Delete, L("DeleteWMS_Location"));
			permission.CreateChildPermission(WMS_LocationPermissions.BatchDelete, L("BatchDeleteWMS_Location"));
			//permission.CreateChildPermission(WMS_LocationPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
