using Abp.Domain.Repositories;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptReceivingCore.Interface;
using MyProject.ReceiptReceivingCore.Strategy;
using MyProject.TableColumns.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptReceivingCore.Factory
{
    public static class ReceiptReceivingExcelFactory
    {
        public static IReceiptReceivingExcelInterface GetReceipt(
               ITable_ColumnsManager table_ColumnsManager)
        {
            //string RoleName = Enum.GetName(typeof(ReceiptEnum), ReceiptEnum.ReceiptExportDefault);

            return new ReceiptReceivingExcelDefaultStrategy(table_ColumnsManager);
            //return new ASNDefaultStrategy();
        }
    }
}
