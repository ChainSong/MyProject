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
    public static class ReceiptReceivingReturnFactory
    {
        public static IReceiptReceivingReturnInterface ReturnReceiptReceiving(IRepository<WMS_Receipt, long> wms_receiptManager,    
               IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
              IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
              long CustomerId)
        {
            //string RoleName = Enum.GetName(typeof(ReceiptEnum), ReceiptEnum.ReceiptExportDefault);
            switch (CustomerId)
            {
                default:
                    return new ReceiptReceivingReturnDefaultStrategy(wms_receiptManager, wms_receiptdetailRepository, wms_receiptreceivingRepository);
            }
            //return new ASNDefaultStrategy();
        }
    }
}
