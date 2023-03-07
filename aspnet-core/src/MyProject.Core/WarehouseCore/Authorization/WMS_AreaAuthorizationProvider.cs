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
    /// See <see cref="WMS_AreaPermissions" /> for all permission names. WMS_Area
    ///</summary>
    public class WMS_AreaAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_AreaAuthorizationProvider()
		{

		}

        public WMS_AreaAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_AreaAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_AreaPermissions.Node , L("WMS_Area"));
			permission.CreateChildPermission(WMS_AreaPermissions.Query, L("QueryWMS_Area"));
			permission.CreateChildPermission(WMS_AreaPermissions.Create, L("CreateWMS_Area"));
			permission.CreateChildPermission(WMS_AreaPermissions.Edit, L("EditWMS_Area"));
			permission.CreateChildPermission(WMS_AreaPermissions.Delete, L("DeleteWMS_Area"));
			permission.CreateChildPermission(WMS_AreaPermissions.BatchDelete, L("BatchDeleteWMS_Area"));
			//permission.CreateChildPermission(WMS_AreaPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
