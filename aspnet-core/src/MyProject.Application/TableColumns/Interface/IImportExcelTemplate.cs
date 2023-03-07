using MyProject.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TableColumns.Interface
{
    public interface IImportExcelTemplate
    {

        Response<DataTable> Strategy(long CustomerId,string RoleName);
    }
}
