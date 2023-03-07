using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using MyProject.Authentication.JwtBearer;
using MyProject.Configuration;
using MyProject.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Abp.Runtime.Caching.Redis;
using System.Reflection;
using Abp.Configuration.Startup;

namespace MyProject
{
    [DependsOn(
         typeof(MyProjectApplicationModule),
         typeof(MyProjectEntityFrameworkModule),
         typeof(AbpAspNetCoreModule),
         //typeof(RebusRabbitMqConsumerModule),
         typeof(AbpRedisCacheModule)
        , typeof(AbpAspNetCoreSignalRModule)
     )]
    public class MyProjectWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyProjectWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MyProjectConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.MultiTenancy.IsEnabled = true;

            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(MyProjectApplicationModule).GetAssembly()
                 );

            //使用redis缓存(必须放在使用redis缓存之前)
            Configuration.Caching.UseRedis(options =>
            {
                options.ConnectionString = _appConfiguration["RedisCache:ConnectionString"];
                options.DatabaseId = _appConfiguration.GetValue<int>("RedisCache:DatabaseId");
            });

            //设置所有缓存的默认过期时间(必须放在使用redis缓存之前)
            Configuration.Caching.ConfigureAll(cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(20);
            });
            //设置某个缓存的默认过期时间 根据 "CacheName" 来区分(必须放在使用redis缓存之前)
            Configuration.Caching.Configure("caches", cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromSeconds(10);
            });

    
            //#region RabbitMq消费端配置
            //Configuration.Modules.UseAbplusRebusRabbitMqConsumer()
            //    //.UseLogging(c => c.Log4Net)
            //    .ConnectTo("amqp://admin:M5l4d4s3@192.168.10.233:5672")//连接
            //    .UseQueue("AutomatedOutbound")//队列名称
            //    .Prefetch(100)//用于控制每次拉取的资源消耗(内存,带宽),消费速度还要看消费端自己的消息处理速度
            //    .SetMaxParallelism(1)//最大并行数
            //    .SetNumberOfWorkers(10)//设置最大工作线程数
            //                           //配置其他选项
            //    .UseOptions(x => x.SimpleRetryStrategy(maxDeliveryAttempts: 50, secondLevelRetriesEnabled: true, errorDetailsHeaderMaxLength: 20))
            //    .RegisterHandlerInAssemblys(Assembly.GetExecutingAssembly());//注册包含Hander的处理程序??//(Assembly.Load("MLCDZ.Application"));
            //    #endregion RabbitMq消费端配置  Assembly.GetAssembly(typeof(PayHandler))
 

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyProjectWebCoreModule).Assembly);
        }
    }
}
