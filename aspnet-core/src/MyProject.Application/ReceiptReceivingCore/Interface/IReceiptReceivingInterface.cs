using MyProject.Dtos;
using MyProject.ReceiptReceivingCore.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptReceivingCore.Interface
{
   public interface IReceiptReceivingInterface
    {
        Response Strategy(dynamic request, IAbpSessionExtension abpSession);
    }
}
