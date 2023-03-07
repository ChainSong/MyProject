
using MyProject.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PreOrderCore.Interface
{
    public interface IPreOrderExcelInterface
    {
        Response<DataTable>  Strategy(dynamic request, IAbpSessionExtension abpSession);
    }
}
