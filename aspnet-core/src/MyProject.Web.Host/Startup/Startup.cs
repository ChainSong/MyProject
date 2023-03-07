using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.Castle.Logging.Log4Net;
using Abp.Extensions;
using MyProject.Configuration;
using MyProject.Identity;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Dependency;
using Abp.Json;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Web.Host.WebSocketCommon;
using Nacos;
using Nacos.V2.DependencyInjection;
using Nacos.AspNetCore.V2;
using MyProject.EntityFrameworkCore;
using static DotNetCore.CAP.RabbitMQOptions;
using System.Collections.Generic;
using DotNetCore.CAP.Messages;
using WebApiClient;
using MyProject.ASNCore;
using MyProject.WebApiClient;

namespace MyProject.Web.Host.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        private const string _apiVersion = "v1";

        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _appConfiguration = env.GetAppConfiguration();
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddNacosAspNet(Configuration);
            //services.AddNacosAspNetCore(Configuration);
            //使用微服务 将接口注册到 Nacos
            services.AddNacosAspNet(Configuration);
            //services.AddNacosV2Config(x =>
            //{
            //    //http://101.43.58.29:8848/
            //    x.ServerAddresses = new System.Collections.Generic.List<string> { "http://101.43.58.29:8848/" };
            //    x.EndPoint = "";
            //    x.Namespace = "public";

            //    /*x.UserName = "nacos";
            //   x.Password = "nacos";*/

            //    // swich to use http or rpc
            //    x.ConfigUseRpc = true;
            //});

            //services.AddNacosV2Naming(x =>
            //{
            //    x.ServerAddresses = new System.Collections.Generic.List<string> { "http://101.43.58.29:8848/" };
            //    x.EndPoint = "";
            //    x.Namespace = "public";
            //    /*x.UserName = "nacos";
            //   x.Password = "nacos";*/
            //    // swich to use http or rpc
            //    x.NamingUseRpc = true;
            //});
            //services.AddHttpApi<IService>();
         
            //services.AddSingleton<IHttpApiFactory<IService>, HttpApiFactory<IService>>(p =>
            //{
            //    return new HttpApiFactory<IService>().ConfigureHttpApiConfig(c =>
            //    {
            //        //c.HttpHost = new Uri("http://localhost:9999/");
            //        //c.LoggerFactory = p.GetRequiredService<ILoggerFactory>();
            //        c.GlobalFilters.Add(new DefaultHeaderAttribute("Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBhc3BuZXRib2lsZXJwbGF0ZS5jb20iLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6ImRkMWJiZGM2LTQ3MzEtYWE1My0wM2E3LTNhMDU1NWRlODIwMCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiUm9sZU5hbWUiOiJBZG1pbiIsIlVzZXJOYW1lIjoiYWRtaW4iLCJzdWIiOiIxIiwianRpIjoiNzA2YzEzNjktZmJkMy00NDJkLWE1NDktYmY2ZmIzYjA2NjZkIiwiaWF0IjoxNjc3NzUxOTEzLCJuYmYiOjE2Nzc3NTE5MTMsImV4cCI6MTY3NzgzODMxMywiaXNzIjoiTXlQcm9qZWN0IiwiYXVkIjoiTXlQcm9qZWN0In0.Rjamwmn0Gan3fhIDkjp2FqDoXm5fATYA5dLJO39e8jg"));//添加Hearder
            //    });
            //});

            //services.AddTransient<IService>(p =>
            //{
            //    var factory = p.GetRequiredService<IHttpApiFactory<IService>>();
            //    return factory.CreateHttpApi();
            //});

            //MVC
            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
                }
            ).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new AbpMvcContractResolver(IocManager.Instance)
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });


            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddSignalR();

            // Configure CORS for angular2 UI
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()

                )

            );

            services.AddCap(options =>
            {
                //配置数据库连接
                //options.UseEntityFramework<MyProjectDbContext>();
                options.UseSqlServer(_appConfiguration["ConnectionStrings:Default"]);
                //options.UseRabbitMQ("amqp://admin:M5l4d4s3@192.168.10.233:5672");
                options.UseRabbitMQ(mq =>
                 {

                     mq.HostName = _appConfiguration["RabbitMQ:Connections:Default:HostName"];
                     mq.Port = Convert.ToInt32(_appConfiguration["RabbitMQ:Connections:Default:Port"]);
                     mq.UserName = _appConfiguration["RabbitMQ:Connections:Default:UserName"];
                     mq.Password = _appConfiguration["RabbitMQ:Connections:Default:Password"];
                     //mq.ConnectionFactoryOptions = opt => {
                     //    opt.
                     //    //rabbitmq client ConnectionFactory config
                     //};
                     //mq.ExchangeType = "direct"; 
                     //mq.VirtualHost = "/";
                     //mq.ExchangeName = "AutomatedOutbound";
                     //mq.ExchangeName = "POC";
                     //mq.CustomHeaders = e => new List<KeyValuePair<string, string>>
                     //{
                     //    // new KeyValuePair<string, string>(Headers.MessageId, SnowflakeId.Default().NextId().ToString()),
                     //    new KeyValuePair<string, string>(Headers.MessageName, e.RoutingKey),
                     //    //new KeyValuePair<string, string>(Headers.MessageId, MessageIdChecker.CheckMessageIdHeader(e)),
                     //};
                 });
                //options.UseDashboard();
                options.FailedRetryCount = 2;
                options.FailedThresholdCallback = failed =>
                {
                    var logger = failed.ServiceProvider.GetService<ILogger<Startup>>();
                    logger.LogError($@"A message of type {failed.MessageType} failed after executing {options.FailedRetryCount} several times, 
                        requiring manual troubleshooting. Message name: {failed.Message.GetName()}");
                };
                //options.UseDashboard();//使用Cap可视化面板
                // 设置处理成功的数据在数据库中保存的时间（秒）,为了保证系统性能，数据会定期清理
                //mq.SucceedMessageExpiredAfter = Convert.ToInt32(configuration["CAPRabbitMQ:SucceedMessageExpiredAfter"]);
                // 重试次数
                //mq.FailedRetryCount = Convert.ToInt32(configuration["CAPRabbitMQ:FailedRetryCount"]);
                // 间隔时间 单位：秒
                //mq.FailedRetryInterval = Convert.ToInt32(configuration["CAPRabbitMQ:FailedRetryInterval"]);
                //发送消息失败后的回调
                //options.FailedThresholdCallback = (failedInfo) =>
                //{
                //    Console.WriteLine(failedInfo.Message);

                //};
                //options.UseDashboard();
            });
            //services.AddMassTransitHostedService();
            //services.AddTransient<ISubscribeAppService, SubscribeAppService>();
            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_apiVersion, new OpenApiInfo
                {
                    Version = _apiVersion,
                    Title = "MyProject API",
                    Description = "MyProject",
                    // uncomment if needed TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "MyProject",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/aspboilerplate"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://github.com/aspnetboilerplate/aspnetboilerplate/blob/dev/LICENSE"),
                    }
                });
                options.DocInclusionPredicate((docName, description) => true);
                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

            });

            // Configure Abp and Dependency Injection
            return services.AddAbp<MyProjectWebHostModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }


        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            app.UseStaticFiles();

            //添加WebSockets
            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(60),
                ReceiveBufferSize = 1 * 1024
            });
            app.UseMiddleware<WebsocketHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAbpRequestLocalization();
            //启用cap中间件
            //app.UseCap();
            //启用cap中间件
            //app.UseCap();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AbpCommonHub>("/signalr");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                // specifying the Swagger JSON endpoint.
                options.SwaggerEndpoint($"/swagger/{_apiVersion}/swagger.json", $"MyProject API {_apiVersion}");
                options.IndexStream = () => Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("MyProject.Web.Host.wwwroot.swagger.ui.index.html");
                options.DisplayRequestDuration(); // Controls the display of the request duration (in milliseconds) for "Try it out" requests.  
            }); // URL: /swagger
        }
    }
}
