using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyProject.Authorization;
using MyProject.CustomDtoAutoMapper;

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

            Configuration.Authorization.Providers.Add<MyProjectAuthorizationProvider>();
            //产品接口的权限
            Configuration.Authorization.Providers.Add<WMS_ProductAuthorizationProvider>();
            //客户接口权限
            Configuration.Authorization.Providers.Add<CustomerAuthorizationProvider>();
            //仓库权限
            Configuration.Authorization.Providers.Add<WMS_WarehouseAuthorizationProvider>();
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

                // ....其他代码
            });

        }
    }
}
