using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.OrderCore
{
    public class WMS_OrderAllocation : Entity<long> 
    {
 
        public long InventoryId { get; set; }
        public long OrderId { get; set; }
        public long OrderDetailId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string Area { get; set; }
        public string Location { get; set; }
        public string SKU { get; set; }
        public string UPC { get; set; }
        public string GoodsType { get; set; }
        public int InventoryStatus { get; set; }
        public long SuperId { get; set; }
        public long RelatedId { get; set; }
        public string GoodsName { get; set; }
        public string UnitCode { get; set; }
        public string Onwer { get; set; }
        public string BoxCode { get; set; }
        public string TrayCode { get; set; }
        public string BatchCode { get; set; }
        public double Qty { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Remark { get; set; }
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public string Str5 { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
 


    }
}
