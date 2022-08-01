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
    /// See <see cref="CustomerDetailPermissions" /> for all permission names. CustomerDetail
    ///</summary>
    public class CustomerDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CustomerDetailAuthorizationProvider()
		{

		}

        public CustomerDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CustomerDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(CustomerDetailPermissions.Node , L("CustomerDetail"));
			permission.CreateChildPermission(CustomerDetailPermissions.Query, L("QueryCustomerDetail"));
			permission.CreateChildPermission(CustomerDetailPermissions.Create, L("CreateCustomerDetail"));
			permission.CreateChildPermission(CustomerDetailPermissions.Edit, L("EditCustomerDetail"));
			permission.CreateChildPermission(CustomerDetailPermissions.Delete, L("DeleteCustomerDetail"));
			permission.CreateChildPermission(CustomerDetailPermissions.BatchDelete, L("BatchDeleteCustomerDetail"));
			permission.CreateChildPermission(CustomerDetailPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
