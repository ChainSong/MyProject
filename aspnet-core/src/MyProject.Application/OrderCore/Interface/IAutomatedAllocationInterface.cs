using MyProject.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.OrderCore.Interface
{
    public interface IAutomatedAllocationInterface
    {
        Task<Response<List<OrderStatusDto>>> Strategy(List<long> request, IAbpSessionExtension abpSession);
    }
}
