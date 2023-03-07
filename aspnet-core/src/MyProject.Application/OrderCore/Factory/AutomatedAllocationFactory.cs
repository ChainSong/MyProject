using Abp.Domain.Repositories;
using MyProject.CustomerCore.DomainService;
using MyProject.InventoryCore;
using MyProject.OrderCore.Interface;
using MyProject.OrderCore.Strategy;
using MyProject.PreOrderCore;
using MyProject.PreOrderCore.Enumerate;
using MyProject.WarehouseCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.OrderCore.Factory
{
    public class AutomatedAllocationFactory
    {
        public static IAutomatedAllocationInterface AutomatedAllocation(
          IRepository<WMS_Order, long> wms_orderRepository,
          IRepository<WMS_OrderDetail, long> wms_orderdetailRepository,
          IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
          IWarehouseUserMappingManager warehouseusermappingManager,
          ICustomerUserMappingManager customerusermappingManager, long CustomerId)
        {
            //string aaa = Enum.GetName(typeof(ASNEnum), ASNEnum.ASNExportDefault);
            switch (CustomerId)
            {
                case (long)OutboundEnum.OutboundDefault:
                    return new AutomatedAllocationDefaultStrategy(wms_orderRepository, wms_orderdetailRepository, wms_inventory_usableRepository, warehouseusermappingManager, customerusermappingManager);
                default:
                    return new AutomatedAllocationDefaultStrategy(wms_orderRepository, wms_orderdetailRepository, wms_inventory_usableRepository, warehouseusermappingManager, customerusermappingManager);
            }
        }
    }
}
