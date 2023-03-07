using MyProject.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptReceivingCore.Interface
{
   public interface IReceiptReceivingExcelInterface
    {
        Response<DataTable> Strategy(dynamic request, IAbpSessionExtension abpSession);
    }
}
