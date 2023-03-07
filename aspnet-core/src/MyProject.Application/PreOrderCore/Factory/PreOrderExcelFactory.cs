using MyProject.ASNCore.Interface;
using MyProject.CustomerCore.DomainService;
using MyProject.PreOrderCore.Interface;
using MyProject.PreOrderCore.Strategy;
using MyProject.TableColumns.DomainService;
using MyProject.WarehouseCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PreOrderCore.Factory
{
    public class PreOrderExcelFactory
    {
        public static IPreOrderExcelInterface GePreOrder(
          ITable_ColumnsManager table_ColumnsManager)
        {

            return new PreOrderExcelDefaultStrategy(table_ColumnsManager);

            //return new ASNDefaultStrategy();
        }



    }
}
