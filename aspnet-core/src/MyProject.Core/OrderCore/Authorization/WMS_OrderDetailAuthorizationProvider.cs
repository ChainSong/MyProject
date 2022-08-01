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
    /// See <see cref="WMS_OrderDetailPermissions" /> for all permission names. WMS_OrderDetail
    ///</summary>
    public class WMS_OrderDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_OrderDetailAuthorizationProvider()
		{

		}

        public WMS_OrderDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_OrderDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_OrderDetailPermissions.Node , L("WMS_OrderDetail"));
			permission.CreateChildPermission(WMS_OrderDetailPermissions.Query, L("QueryWMS_OrderDetail"));
			permission.CreateChildPermission(WMS_OrderDetailPermissions.Create, L("CreateWMS_OrderDetail"));
			permission.CreateChildPermission(WMS_OrderDetailPermissions.Edit, L("EditWMS_OrderDetail"));
			permission.CreateChildPermission(WMS_OrderDetailPermissions.Delete, L("DeleteWMS_OrderDetail"));
			permission.CreateChildPermission(WMS_OrderDetailPermissions.BatchDelete, L("BatchDeleteWMS_OrderDetail"));
			permission.CreateChildPermission(WMS_OrderDetailPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
