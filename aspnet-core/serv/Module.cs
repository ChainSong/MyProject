
using System;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyProject;
using MyProject.Authorization;


namespace serv
{

	[DependsOn(
        typeof(CoreModule),
        typeof(AbpAutoMapperModule))]
    public class ${ClassName}Module: AbpModule
    {
        public override void PreInitialize()
        {
            // 配置授权
            //Configuration.Authorization.Providers.Add<SolutionAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(${ClassName}Module).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

        }
    }
}