using Abp.Application.Services.Dto;
using Abp.Dependency;
using MyProject.ASNCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace MyProject.WebApiClient
{
    //[HttpHost("http://localhost:5000")]
    public interface IService : IHttpApi,ITransientDependency
    {
 
        [HttpPatch("WMS_ASN/GetPaged")]
    
        Task<PagedResultDto<WMS_ASNListDto>> PatchAsync(GetWMS_ASNsInput input);
    }
}
