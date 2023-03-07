using MyProject.ASNCore.Interface;
using MyProject.ASNCore.Strategy;
using MyProject.TableColumns.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ASNCore.Factory
{
    public class ASNExcelFactory
    {
        public static IASNExcelInterface GetReceipt(
             ITable_ColumnsManager table_ColumnsManager)
        {
          
                    return new ASNExcelDefaultStrategy(table_ColumnsManager);
       
            //return new ASNDefaultStrategy();
        }
    }
}
