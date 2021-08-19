

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using MyProject.Authorization;

// ReSharper disable once CheckNamespace
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
            // 在这里配置了WMS_ReceiptReceiving 的权限。
            //var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            //var wMS_ReceiptReceiving = administration.CreateChildPermission(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Node , L("WMS_ReceiptReceiving"));
            //wMS_ReceiptReceiving.CreateChildPermission(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Query, L("QueryWMS_ReceiptReceiving"));
            //wMS_ReceiptReceiving.CreateChildPermission(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Create, L("CreateWMS_ReceiptReceiving"));
            //wMS_ReceiptReceiving.CreateChildPermission(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Edit, L("EditWMS_ReceiptReceiving"));
            //wMS_ReceiptReceiving.CreateChildPermission(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Delete, L("DeleteWMS_ReceiptReceiving"));
            //wMS_ReceiptReceiving.CreateChildPermission(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_BatchDelete, L("BatchDeleteWMS_ReceiptReceiving"));
            //wMS_ReceiptReceiving.CreateChildPermission(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_ExportExcel, L("ExportToExcel"));
            //// custom codes
            //// custom codes end
        }

        //private static ILocalizableString L(string name)
        //{
        //	return new LocalizableString(name, AppConsts.LocalizationSourceName);
        //}
    }
}
