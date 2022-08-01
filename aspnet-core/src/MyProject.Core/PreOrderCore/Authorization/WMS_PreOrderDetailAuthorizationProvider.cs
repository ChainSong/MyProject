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
    /// See <see cref="WMS_PreOrderDetailPermissions" /> for all permission names. WMS_PreOrderDetail
    ///</summary>
    public class WMS_PreOrderDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_PreOrderDetailAuthorizationProvider()
		{

		}

        public WMS_PreOrderDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_PreOrderDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_PreOrderDetailPermissions.Node , L("WMS_PreOrderDetail"));
			permission.CreateChildPermission(WMS_PreOrderDetailPermissions.Query, L("QueryWMS_PreOrderDetail"));
			permission.CreateChildPermission(WMS_PreOrderDetailPermissions.Create, L("CreateWMS_PreOrderDetail"));
			permission.CreateChildPermission(WMS_PreOrderDetailPermissions.Edit, L("EditWMS_PreOrderDetail"));
			permission.CreateChildPermission(WMS_PreOrderDetailPermissions.Delete, L("DeleteWMS_PreOrderDetail"));
			permission.CreateChildPermission(WMS_PreOrderDetailPermissions.BatchDelete, L("BatchDeleteWMS_PreOrderDetail"));
			permission.CreateChildPermission(WMS_PreOrderDetailPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
