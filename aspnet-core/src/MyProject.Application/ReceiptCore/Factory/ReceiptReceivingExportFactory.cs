using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using MyProject.ASNCore;
using MyProject.ASNCore.DomainService;
using MyProject.InventoryCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptCore.Enumerate;
using MyProject.ReceiptCore.Interface;
using MyProject.ReceiptCore.Strategy;
using MyProject.ReceiptReceivingCore;
using MyProject.TableColumns.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptCore.Factory
{
    public class ReceiptReceivingExportFactory
    {
        public static IReceiptReceivingExportInterface GetReceiptReceiving(IRepository<WMS_Receipt, long> wms_receiptRepository,
            IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
            IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
              IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
                 ICacheManager cacheManage, ITable_ColumnsManager table_ColumnsManager
                  )
        {
            //string RoleName = Enum.GetName(typeof(ReceiptEnum), ReceiptEnum.ReceiptExportDefault);

            return new ReceiptReceivingExportDefaultStrategy(wms_receiptRepository, wms_receiptdetailRepository, wms_receiptreceivingRepository, wms_inventory_usableRepository, cacheManage, table_ColumnsManager);

            //return new ASNDefaultStrategy();
        }

    }
}
