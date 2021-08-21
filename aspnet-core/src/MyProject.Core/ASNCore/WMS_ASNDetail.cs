using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ASNCore
{
   public class WMS_ASNDetail : Entity<long>, IHasCreationTime
    {
        public long ASNDetailId { get; set; }
        public long ASNId { get; set; }

        public Guid? ExtensionDetailGUID { get; set; }
        public string ASNNumber { get; set; }
        public string ExternReceiptNumber { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string LineNumber { get; set; }
        public string SKU { get; set; }
        public string UPC { get; set; }
        public string GoodsType { get; set; }
        public string GoodsName { get; set; }
        public string BoxNumber { get; set; }
        public string BatchNumber { get; set; }
        public decimal QtyExpected { get; set; }
        public decimal QtyReceived { get; set; }
        public decimal QtyReceipt { get; set; }
        public string Unit { get; set; }
        public string Specifications { get; set; }
        public decimal Price { get; set; } 
        public float Weight { get; set; }
        public float Volume { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Creator { get; set; }
        public DateTime CreationTime { get; set; } = new DateTime();
        public string Updator { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public string Str5 { get; set; }
        public string Str6 { get; set; }
        public string Str7 { get; set; }
        public string Str8 { get; set; }
        public string Str9 { get; set; }
        public string Str10 { get; set; }
        public string Str11 { get; set; }
        public string Str12 { get; set; }
        public string Str13 { get; set; }
        public string Str14 { get; set; }
        public string Str15 { get; set; }
        public string Str16 { get; set; }
        public string Str17 { get; set; }
        public string Str18 { get; set; }
        public string Str19 { get; set; }
        public string Str20 { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public DateTime? DateTime3 { get; set; }
        public DateTime? DateTime4 { get; set; }
        public DateTime? DateTime5 { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public int Int3 { get; set; }
        public int Int4 { get; set; }
        public int Int5 { get; set; }

        public virtual WMS_ASN WMS_ASN { get; set; }

    }                 
}                     
                      
                      
                      
                      
                      
                      
                      
                      