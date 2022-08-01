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
    /// See <see cref="WMS_PreOrderPermissions" /> for all permission names. WMS_PreOrder
    ///</summary>
    public class WMS_PreOrderAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_PreOrderAuthorizationProvider()
		{

		}

        public WMS_PreOrderAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_PreOrderAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_PreOrderPermissions.Node , L("WMS_PreOrder"));
			permission.CreateChildPermission(WMS_PreOrderPermissions.Query, L("QueryWMS_PreOrder"));
			permission.CreateChildPermission(WMS_PreOrderPermissions.Create, L("CreateWMS_PreOrder"));
			permission.CreateChildPermission(WMS_PreOrderPermissions.Edit, L("EditWMS_PreOrder"));
			permission.CreateChildPermission(WMS_PreOrderPermissions.Delete, L("DeleteWMS_PreOrder"));
			permission.CreateChildPermission(WMS_PreOrderPermissions.BatchDelete, L("BatchDeleteWMS_PreOrder"));
			permission.CreateChildPermission(WMS_PreOrderPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
