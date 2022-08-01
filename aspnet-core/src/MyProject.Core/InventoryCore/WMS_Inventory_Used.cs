using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.InventoryCore
{
    public class WMS_Inventory_Used : Entity<long>, IHasCreationTime
    {

        public long? ASNDetailId { get; set; }

        public long? ReceiptDetailId { get; set; }

        public long? ReceiptReceivingId { get; set; }

        public long CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        public long? WarehouseId { get; set; }

        [StringLength(50)]
        public string WarehouseName { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(50)]
        public string GoodsType { get; set; }

        public int? InventoryType { get; set; }

        public long? SuperId { get; set; }

        public long? RelatedId { get; set; }

        [StringLength(100)]
        public string GoodsName { get; set; }

        [StringLength(100)]
        public string UnitCode { get; set; }

        [StringLength(50)]
        public string Onwer { get; set; }

        [StringLength(100)]
        public string BoxCode { get; set; }

        [StringLength(100)]
        public string TrayCode { get; set; }

        [StringLength(100)]
        public string BatchCode { get; set; }

        public double Qty { get; set; }

        public DateTime? ProductionDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public DateTime InventoryTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        [StringLength(50)]
        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(50)]
        public string Str1 { get; set; }

        [StringLength(50)]
        public string Str2 { get; set; }

        [StringLength(100)]
        public string Str3 { get; set; }

        [StringLength(100)]
        public string Str4 { get; set; }

        [StringLength(500)]
        public string Str5 { get; set; }

        public DateTime? DateTime1 { get; set; }

        public DateTime? DateTime2 { get; set; }

        public int? Int1 { get; set; }

        public int? Int2 { get; set; }
    }
}
