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
    /// See <see cref="WMS_ReceiptDetailPermissions" /> for all permission names. WMS_ReceiptDetail
    ///</summary>
    public class WMS_ReceiptDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_ReceiptDetailAuthorizationProvider()
		{

		}

        public WMS_ReceiptDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ReceiptDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_ReceiptDetailPermissions.Node , L("WMS_ReceiptDetail"));
			permission.CreateChildPermission(WMS_ReceiptDetailPermissions.Query, L("QueryWMS_ReceiptDetail"));
			permission.CreateChildPermission(WMS_ReceiptDetailPermissions.Create, L("CreateWMS_ReceiptDetail"));
			permission.CreateChildPermission(WMS_ReceiptDetailPermissions.Edit, L("EditWMS_ReceiptDetail"));
			permission.CreateChildPermission(WMS_ReceiptDetailPermissions.Delete, L("DeleteWMS_ReceiptDetail"));
			permission.CreateChildPermission(WMS_ReceiptDetailPermissions.BatchDelete, L("BatchDeleteWMS_ReceiptDetail"));
			permission.CreateChildPermission(WMS_ReceiptDetailPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
