using Abp.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyProject.Web.Host.Startup
{
    public class MyCustomContractResolver : DefaultContractResolver
    {
        protected  override string ResolvePropertyName(string propertyName)
        {
            return propertyName;
        } 
    }
}