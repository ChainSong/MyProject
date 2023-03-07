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
    /// See <see cref="WMS_OrderPermissions" /> for all permission names. WMS_Order
    ///</summary>
    public class WMS_OrderAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_OrderAuthorizationProvider()
		{

		}

        public WMS_OrderAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_OrderAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_OrderPermissions.Node , L("Order"));
			permission.CreateChildPermission(WMS_OrderPermissions.Query, L("QueryOrder"));
			permission.CreateChildPermission(WMS_OrderPermissions.Create, L("CreateOrder"));
			permission.CreateChildPermission(WMS_OrderPermissions.Edit, L("EditOrder"));
			permission.CreateChildPermission(WMS_OrderPermissions.Delete, L("DeleteOrder"));
			permission.CreateChildPermission(WMS_OrderPermissions.BatchDelete, L("BatchDeleteOrder")); 
			permission.CreateChildPermission(WMS_OrderPermissions.AutomatedAllocation, L("AutomatedAllocation")); 
			//permission.CreateChildPermission(WMS_OrderPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始


			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
