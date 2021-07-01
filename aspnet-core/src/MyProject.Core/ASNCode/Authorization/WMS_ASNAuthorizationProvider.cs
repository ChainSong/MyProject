

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
    /// See <see cref="WMS_ASNPermissions" /> for all permission names. WMS_ASN
    ///</summary>
    public class WMS_ASNAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public WMS_ASNAuthorizationProvider()
		{

		}

       
        public WMS_ASNAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public WMS_ASNAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了WMS_ASN 的权限。
//			var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

//			var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

//			var wMS_ASN = administration.CreateChildPermission(WMS_ASNPermissions.WMS_ASN_Node , L("WMS_ASN"));
//wMS_ASN.CreateChildPermission(WMS_ASNPermissions.WMS_ASN_Query, L("QueryWMS_ASN"));
//wMS_ASN.CreateChildPermission(WMS_ASNPermissions.WMS_ASN_Create, L("CreateWMS_ASN"));
//wMS_ASN.CreateChildPermission(WMS_ASNPermissions.WMS_ASN_Edit, L("EditWMS_ASN"));
//wMS_ASN.CreateChildPermission(WMS_ASNPermissions.WMS_ASN_Delete, L("DeleteWMS_ASN"));
//wMS_ASN.CreateChildPermission(WMS_ASNPermissions.WMS_ASN_BatchDelete, L("BatchDeleteWMS_ASN"));
//wMS_ASN.CreateChildPermission(WMS_ASNPermissions.WMS_ASN_ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		//private static ILocalizableString L(string name)
		//{
		//	return new LocalizableString(name, AppConsts.LocalizationSourceName);
		//}
    }
}
