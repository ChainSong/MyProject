using MyProject.ASNCore.Dtos;
using MyProject.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ASNCore.Interface
{
   public interface IASNInterface
    {
        Response<List<OrderStatusDto>> Strategy(List<WMS_ASNEditDto> request, IAbpSessionExtension abpSession);
    }
}
