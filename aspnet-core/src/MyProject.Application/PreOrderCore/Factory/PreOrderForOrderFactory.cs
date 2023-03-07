using Abp.Domain.Repositories;
using MyProject.ASNCore.Interface;
using MyProject.CustomerCore.DomainService;
using MyProject.InventoryCore;
using MyProject.OrderCore;
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
    public class PreOrderForOrderFactory
    {
        public static IPreOrderForOrderInterface PreOrderForOrder(
            IRepository<WMS_PreOrder, long> wms_preorderRepository,
            IRepository<WMS_PreOrderDetail, long> wms_preorderdetailRepository,
            IRepository<WMS_Order, long> wms_orderRepository,
            IRepository<WMS_OrderDetail, long> wms_orderdetailRepository, 
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager, long CustomerId)
        {
            //string aaa = Enum.GetName(typeof(ASNEnum), ASNEnum.ASNExportDefault);
            switch (CustomerId)
            {
                case (long)OutboundEnum.OutboundDefault:
                    return new PreOrderForOrderDefaultStrategy(wms_preorderRepository, wms_preorderdetailRepository, wms_orderRepository, wms_orderdetailRepository, warehouseusermappingManager, customerusermappingManager);
                default:
                    return new PreOrderForOrderDefaultStrategy(wms_preorderRepository, wms_preorderdetailRepository, wms_orderRepository, wms_orderdetailRepository, warehouseusermappingManager, customerusermappingManager);
            }
        }

    }
}
