using Abp.Domain.Repositories;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.ReceiptReceivingCore.Interface;
using MyProject.ReceiptReceivingCore.Strategy;
using MyProject.TableColumns.DomainService;
using MyProject.WarehouseCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyProject.ReceiptReceivingCore.Factory
{
    public static class ReceiptReceivingFactory
    {
        public static IReceiptReceivingInterface GetReceiptReceiving(IWMS_ReceiptManager wms_receiptManager,
              IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
              ITable_ColumnsManager table_ColumnsManager,
              IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
              IRepository<WMS_Location, long> wms_locationRepository,
              long CustomerId)
        {
            //string RoleName = Enum.GetName(typeof(ReceiptEnum), ReceiptEnum.ReceiptExportDefault);
            switch (CustomerId)
            {
                default:
                    return new ReceiptReceivingDefaultStrategy(wms_receiptManager, wms_receiptreceivingRepository, table_ColumnsManager, wms_receiptdetailRepository, wms_locationRepository);
            }
            //return new ASNDefaultStrategy();
        }
    }
}
