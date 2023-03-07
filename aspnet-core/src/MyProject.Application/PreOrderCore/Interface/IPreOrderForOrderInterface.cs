
using MyProject.Dtos;
using MyProject.PreOrderCore.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PreOrderCore.Interface
{
    public interface IPreOrderForOrderInterface
    {
       Task<Response<List<OrderStatusDto>>> Strategy(List<long> request, IAbpSessionExtension abpSession);
    }
}
