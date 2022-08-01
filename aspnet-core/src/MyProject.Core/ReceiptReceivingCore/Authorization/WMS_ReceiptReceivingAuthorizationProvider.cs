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
    /// See <see cref="WMS_ReceiptReceivingPermissions" /> for all permission names. WMS_ReceiptReceiving
    ///</summary>
    public class WMS_ReceiptReceivingAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_ReceiptReceivingAuthorizationProvider()
		{

		}

        public WMS_ReceiptReceivingAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ReceiptReceivingAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Member 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var permission = administration.CreateChildPermission(WMS_ReceiptReceivingPermissions.Node , L("WMS_ReceiptReceiving"));
			permission.CreateChildPermission(WMS_ReceiptReceivingPermissions.Query, L("QueryWMS_ReceiptReceiving"));
			permission.CreateChildPermission(WMS_ReceiptReceivingPermissions.Create, L("CreateWMS_ReceiptReceiving"));
			permission.CreateChildPermission(WMS_ReceiptReceivingPermissions.Edit, L("EditWMS_ReceiptReceiving"));
			permission.CreateChildPermission(WMS_ReceiptReceivingPermissions.Delete, L("DeleteWMS_ReceiptReceiving"));
			permission.CreateChildPermission(WMS_ReceiptReceivingPermissions.BatchDelete, L("BatchDeleteWMS_ReceiptReceiving"));
			permission.CreateChildPermission(WMS_ReceiptReceivingPermissions.ExportExcel, L("ExportToExcel"));

			//// 添加自定义代码开始
									
			
			//// 添加自定义代码 结束
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
		}
    }
}
