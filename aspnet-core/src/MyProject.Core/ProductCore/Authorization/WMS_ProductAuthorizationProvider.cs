

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
    /// See <see cref="WMS_ProductPermissions" /> for all permission names. WMS_Product
    ///</summary>
    public class WMS_ProductAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public WMS_ProductAuthorizationProvider()
        {

        }


        public WMS_ProductAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ProductAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了WMS_Product 的权限。
            //var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            //var wMS_Product = administration.CreateChildPermission(WMS_ProductPermissions.WMS_Product_Node, L("WMS_Product"));
            //wMS_Product.CreateChildPermission(WMS_ProductPermissions.WMS_Product_Query, L("QueryWMS_Product"));
            //wMS_Product.CreateChildPermission(WMS_ProductPermissions.WMS_Product_Create, L("CreateWMS_Product"));
            //wMS_Product.CreateChildPermission(WMS_ProductPermissions.WMS_Product_Edit, L("EditWMS_Product"));
            //wMS_Product.CreateChildPermission(WMS_ProductPermissions.WMS_Product_Delete, L("DeleteWMS_Product"));
            //wMS_Product.CreateChildPermission(WMS_ProductPermissions.WMS_Product_BatchDelete, L("BatchDeleteWMS_Product"));
            //wMS_Product.CreateChildPermission(WMS_ProductPermissions.WMS_Product_ExportExcel, L("ExportToExcel"));


            //// custom codes



            //// custom codes end
        }

        //    private static ILocalizableString L(string name)
        //    {
        //        return new LocalizableString(name, AppConsts.LocalizationSourceName);
        //    }
    }
}
