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
    /// See <see cref="CustomerPermissions" /> for all permission names. Customer
    ///</summary>
    public class CustomerAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CustomerAuthorizationProvider()
		{

		}

        public CustomerAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CustomerAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(CustomerPermissions.Node , L("Customer"));
			permission.CreateChildPermission(CustomerPermissions.Query, L("QueryCustomer"));
			permission.CreateChildPermission(CustomerPermissions.Create, L("CreateCustomer"));
			permission.CreateChildPermission(CustomerPermissions.Edit, L("EditCustomer"));
			permission.CreateChildPermission(CustomerPermissions.Delete, L("DeleteCustomer"));
			permission.CreateChildPermission(CustomerPermissions.BatchDelete, L("BatchDeleteCustomer"));
			permission.CreateChildPermission(CustomerPermissions.ExportExcel, L("ExportToExcelCustomer"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
