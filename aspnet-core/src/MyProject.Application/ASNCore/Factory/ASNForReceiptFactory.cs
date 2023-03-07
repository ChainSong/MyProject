using Abp.Domain.Repositories;
using MyProject.ASNCore.Enumerate;
using MyProject.ASNCore.Interface;
using MyProject.ASNCore.Strategy;
using MyProject.ReceiptCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ASNCore.Factory
{
    public class ASNForReceiptFactory
    {
        public static IASNForReceiptInterface ASNForReceipt(IRepository<WMS_ASN, long> wms_asnRepository, IRepository<WMS_ASNDetail, long> wms_asndetailRepository, IRepository<WMS_Receipt, long> wms_receiptRepository, long CustomerId)
        {
            //string RoleName = Enum.GetName(typeof(ReceiptEnum), ReceiptEnum.ReceiptExportDefault);
            switch (CustomerId)
            {
                case (long)ASNEnum.ASNForReceiptDefault:
                    return new ASNForReceiptDefaultStrategy(wms_asnRepository, wms_asndetailRepository, wms_receiptRepository);
                default:
                    return new ASNForReceiptDefaultStrategy(wms_asnRepository, wms_asndetailRepository, wms_receiptRepository);
            }
            //return new ASNDefaultStrategy();
        }
    }
}
