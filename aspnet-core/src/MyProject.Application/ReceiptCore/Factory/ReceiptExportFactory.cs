using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.Runtime.Caching;
using MyProject.ASNCore.DomainService;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptCore.Enumerate;
using MyProject.ReceiptCore.Interface;
using MyProject.ReceiptCore.Strategy;
using MyProject.TableColumns;
using MyProject.TableColumns.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptCore.Factory
{
    public class ReceiptExportFactory
    {
        public static IReceiptExportInterface ExportReceipt(IWMS_ReceiptManager wms_receiptManager,
                   ICacheManager cacheManage, IObjectMapper _mapper, ITable_ColumnsManager table_ColumnsManager,
                   ITable_ColumnsDetailManager table_ColumnsDetailManager)
        {


           return new ReceiptExportDefaultStrategy(wms_receiptManager, cacheManage,  table_ColumnsManager, table_ColumnsDetailManager);

            //return new ASNDefaultStrategy();
        }

    }
}
