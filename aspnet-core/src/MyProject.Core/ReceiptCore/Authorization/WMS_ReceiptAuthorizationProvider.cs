

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
            // 在这里配置了WMS_Receipt 的权限。
            //			var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            //			var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            //			var wMS_Receipt = administration.CreateChildPermission(WMS_ReceiptPermissions.WMS_Receipt_Node , L("WMS_Receipt"));
            //wMS_Receipt.CreateChildPermission(WMS_ReceiptPermissions.WMS_Receipt_Query, L("QueryWMS_Receipt"));
            //wMS_Receipt.CreateChildPermission(WMS_ReceiptPermissions.WMS_Receipt_Create, L("CreateWMS_Receipt"));
            //wMS_Receipt.CreateChildPermission(WMS_ReceiptPermissions.WMS_Receipt_Edit, L("EditWMS_Receipt"));
            //wMS_Receipt.CreateChildPermission(WMS_ReceiptPermissions.WMS_Receipt_Delete, L("DeleteWMS_Receipt"));
            //wMS_Receipt.CreateChildPermission(WMS_ReceiptPermissions.WMS_Receipt_BatchDelete, L("BatchDeleteWMS_Receipt"));
            //wMS_Receipt.CreateChildPermission(WMS_ReceiptPermissions.WMS_Receipt_ExportExcel, L("ExportToExcel"));


            //// custom codes



            //// custom codes end
        }

        //private static ILocalizableString L(string name)
        //{
        //	//return new LocalizableString(name, AppConsts.LocalizationSourceName);
        //}
    }
}
