using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MyProject.Authorization;
using MyProject.CustomDtoAutoMapper;
using System.Reflection;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyProjectApplicationModule : AbpModule 
    {

        public override void PreInitialize()
        {
            Configuration.MultiTenancy.IsEnabled = true;
            //系统基础权限
            Configuration.Authorization.Providers.Add<MyProjectAuthorizationProvider>();
            //产品接口的权限
            Configuration.Authorization.Providers.Add<WMS_ProductAuthorizationProvider>();
            //客户接口权限
            Configuration.Authorization.Providers.Add<CustomerAuthorizationProvider>();
            //仓库权限
            Configuration.Authorization.Providers.Add<WMS_WarehouseAuthorizationProvider>();
            //库区权限
            Configuration.Authorization.Providers.Add<WMS_AreaAuthorizationProvider>();
            //库位权限
            Configuration.Authorization.Providers.Add<WMS_LocationAuthorizationProvider>();
            //ASN权限
            Configuration.Authorization.Providers.Add<WMS_ASNAuthorizationProvider>();
            //入库权限
            Configuration.Authorization.Providers.Add<WMS_ReceiptAuthorizationProvider>();
            //上架权限
            Configuration.Authorization.Providers.Add<WMS_ReceiptReceivingAuthorizationProvider>();
            //可用库存权限
            Configuration.Authorization.Providers.Add<WMS_Inventory_UsableAuthorizationProvider>();
            //预出库单权限
            Configuration.Authorization.Providers.Add<WMS_PreOrderAuthorizationProvider>();
            //出库单权限
            Configuration.Authorization.Providers.Add<WMS_OrderAuthorizationProvider>();

            //Configuration.EventBus.UseDefaultEventBus.

            //Configuration.Modules.UseAbplusRebusRabbitMqConsumer()
            //    .AddDbContext<MyProjectDbContext>(options =>
            //{
            //    if (options.ExistingConnection != null)
            //    {
            //        MyProjectDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
            //    }
            //    else
            //    {
            //        MyProjectDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            //    }
            //});
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)

            );
 
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // ....其他代码
                // 只需要复制这一段
                WMS_ProductDtoAutoMapper.CreateMappings(configuration);
                CustomerDtoAutoMapper.CreateMappings(configuration);
                WMS_WarehouseDtoAutoMapper.CreateMappings(configuration);
                WMS_AreaDtoAutoMapper.CreateMappings(configuration);
                WMS_LocationDtoAutoMapper.CreateMappings(configuration);
                WMS_ASNDtoAutoMapper.CreateMappings(configuration);
                WMS_ReceiptDtoAutoMapper.CreateMappings(configuration);
                WMS_ReceiptReceivingDtoAutoMapper.CreateMappings(configuration);
                WMS_Inventory_UsableDtoAutoMapper.CreateMappings(configuration);
                WMS_PreOrderDtoAutoMapper.CreateMappings(configuration);
                WMS_OrderDtoAutoMapper.CreateMappings(configuration);

                // ....其他代码
            });

        }


    }
}
