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
    /// See <see cref="WMS_ASNPermissions" /> for all permission names. WMS_ASN
    ///</summary>
    public class WMS_ASNAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_ASNAuthorizationProvider()
		{

		}

        public WMS_ASNAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ASNAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_ASNPermissions.Node , L("WMS_ASN"));
			permission.CreateChildPermission(WMS_ASNPermissions.Query, L("QueryWMS_ASN"));
			permission.CreateChildPermission(WMS_ASNPermissions.Create, L("CreateWMS_ASN"));
			permission.CreateChildPermission(WMS_ASNPermissions.Edit, L("EditWMS_ASN"));
			permission.CreateChildPermission(WMS_ASNPermissions.Delete, L("DeleteWMS_ASN"));
			permission.CreateChildPermission(WMS_ASNPermissions.BatchDelete, L("BatchDeleteWMS_ASN"));
			permission.CreateChildPermission(WMS_ASNPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
