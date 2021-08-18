

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
			// 在这里配置了WMS_ReceiptDetail 的权限。
//			var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

//			var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

//			var wMS_ReceiptDetail = administration.CreateChildPermission(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Node , L("WMS_ReceiptDetail"));
//wMS_ReceiptDetail.CreateChildPermission(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Query, L("QueryWMS_ReceiptDetail"));
//wMS_ReceiptDetail.CreateChildPermission(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Create, L("CreateWMS_ReceiptDetail"));
//wMS_ReceiptDetail.CreateChildPermission(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Edit, L("EditWMS_ReceiptDetail"));
//wMS_ReceiptDetail.CreateChildPermission(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Delete, L("DeleteWMS_ReceiptDetail"));
//wMS_ReceiptDetail.CreateChildPermission(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_BatchDelete, L("BatchDeleteWMS_ReceiptDetail"));
//wMS_ReceiptDetail.CreateChildPermission(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		//private static ILocalizableString L(string name)
		//{
		//	return new LocalizableString(name, AppConsts.LocalizationSourceName);
		//}
    }
}
