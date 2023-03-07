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
    /// See <see cref="WMS_ReceiptPermissions" /> for all permission names. WMS_Receipt
    ///</summary>
    public class WMS_ReceiptAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public WMS_ReceiptAuthorizationProvider()
        {

        }

        public WMS_ReceiptAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ReceiptAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了Member 的权限。
            var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

            var permission = administration.CreateChildPermission(WMS_ReceiptPermissions.Node, L("WMS_Receipt"));
            permission.CreateChildPermission(WMS_ReceiptPermissions.Query, L("QueryWMS_Receipt"));
            permission.CreateChildPermission(WMS_ReceiptPermissions.Create, L("CreateWMS_Receipt"));
            permission.CreateChildPermission(WMS_ReceiptPermissions.Edit, L("EditWMS_Receipt"));
            permission.CreateChildPermission(WMS_ReceiptPermissions.Delete, L("DeleteWMS_Receipt")); 
            permission.CreateChildPermission(WMS_ReceiptPermissions.BatchDelete, L("BatchDeleteWMS_Receipt"));
            permission.CreateChildPermission(WMS_ReceiptPermissions.AddInventory, L("AddInventory"));
            //permission.CreateChildPermission(WMS_ReceiptPermissions.ExportExcel, L("ExportToExcel"));

            //// 添加自定义代码开始


            //// 添加自定义代码 结束
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
        }
    }
}
