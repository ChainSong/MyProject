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
    /// See <see cref="CustomerUserMappingPermissions" /> for all permission names. CustomerUserMapping
    ///</summary>
    public class CustomerUserMappingAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CustomerUserMappingAuthorizationProvider()
		{

		}

        public CustomerUserMappingAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CustomerUserMappingAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(CustomerUserMappingPermissions.Node , L("CustomerUserMapping"));
			permission.CreateChildPermission(CustomerUserMappingPermissions.Query, L("QueryCustomerUserMapping"));
			permission.CreateChildPermission(CustomerUserMappingPermissions.Create, L("CreateCustomerUserMapping"));
			permission.CreateChildPermission(CustomerUserMappingPermissions.Edit, L("EditCustomerUserMapping"));
			permission.CreateChildPermission(CustomerUserMappingPermissions.Delete, L("DeleteCustomerUserMapping"));
			permission.CreateChildPermission(CustomerUserMappingPermissions.BatchDelete, L("BatchDeleteCustomerUserMapping"));
			permission.CreateChildPermission(CustomerUserMappingPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
