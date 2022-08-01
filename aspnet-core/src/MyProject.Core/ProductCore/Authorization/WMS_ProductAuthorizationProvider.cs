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
    /// See <see cref="WMS_ProductPermissions" /> for all permission names. WMS_Product
    ///</summary>
    public class WMS_ProductAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_ProductAuthorizationProvider()
		{

		}

        public WMS_ProductAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ProductAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_ProductPermissions.Node , L("WMS_Product"));
			permission.CreateChildPermission(WMS_ProductPermissions.Query, L("QueryWMS_Product"));
			permission.CreateChildPermission(WMS_ProductPermissions.Create, L("CreateWMS_Product"));
			permission.CreateChildPermission(WMS_ProductPermissions.Edit, L("EditWMS_Product"));
			permission.CreateChildPermission(WMS_ProductPermissions.Delete, L("DeleteWMS_Product"));
			permission.CreateChildPermission(WMS_ProductPermissions.BatchDelete, L("BatchDeleteWMS_Product"));
			permission.CreateChildPermission(WMS_ProductPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
