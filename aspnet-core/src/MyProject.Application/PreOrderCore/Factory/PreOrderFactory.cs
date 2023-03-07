using Abp.Domain.Repositories;
using MyProject.ASNCore.Interface;
using MyProject.CustomerCore.DomainService;
using MyProject.PreOrderCore.Enumerate;
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
   public  class PreOrderFactory
    {
        public static IPreOrderInterface GePreOrder(
             IRepository<WMS_PreOrder, long> wms_preorderRepository,
            IRepository<WMS_PreOrderDetail, long> wms_preorderdetailRepository,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager, long CustomerId)
        {
            //string aaa = Enum.GetName(typeof(ASNEnum), ASNEnum.ASNExportDefault);
            switch (CustomerId)
            {
                case (long)PreOrderEnum.PreOrderExportDefault:
                    return new PreOrderDefaultStrategy(wms_preorderRepository, wms_preorderdetailRepository, warehouseusermappingManager, customerusermappingManager);
                default:
                    return new PreOrderDefaultStrategy(wms_preorderRepository, wms_preorderdetailRepository, warehouseusermappingManager, customerusermappingManager);
            }
        }

    }
}
