using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyProject.ASNCore;
using MyProject.WebApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;

namespace MyProject.Web.Host.Startup
{
    public class MyProjectHttpsModule
    {
        public static IServiceCollection Register(IServiceCollection services, IConfigurationRoot appConfiguration)
        {
            

            return services;
        }
    }
}
