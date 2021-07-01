using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ProductCore
{
    public class WMS_Product : Entity<long>
    {
        public long ProductID { get; set; }
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public long WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public string SKU { get; set; }
        public int ProductStatus { get; set; }
        public string GoodsName { get; set; }
        public string GoodsType { get; set; }
        public string SKUClassification { get; set; }
        public string SKUGroup { get; set; }
        public string ManufacturerSKU { get; set; }
        public string RetailSKU { get; set; }
        public string ReplaceSKU { get; set; }
        public string BoxGroup { get; set; }
        public string Packing { get; set; }
        public string Grade { get; set; }
        public string Country { get; set; }
        public string Manufacturer { get; set; }
        public string DangerCode { get; set; }
        public string Vvolume { get; set; }
        public string StandardVolume { get; set; }
        public string Weight { get; set; }
        public string StandardWeight { get; set; }
        public string NetWeight { get; set; }
        public string StandardNetWeight { get; set; }
        public string Price { get; set; }
        public decimal ActualPrice { get; set; }
        public string Cost { get; set; }
        public string ActualCost { get; set; }
        public string StandardOrderingCost { get; set; }
        public string ShipmentCost { get; set; }
        public string QcInSpectionLoc { get; set; }
        public string QcPercentage { get; set; }
        public string ReceiptQcUom { get; set; }
        public string QcEligible { get; set; }
        public string PutArea { get; set; }
        public string PutCode { get; set; }
        public string PutRule { get; set; }
        public string PutStrategy { get; set; }
        public string AllocateRule { get; set; }
        public string PickedCode { get; set; }
        public string SKUType { get; set; }
        public string Color { get; set; }
        public string Size_L { get; set; }
        public string Size_W { get; set; }
        public string Size_H { get; set; }
        public int ExpirationDate { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime? CreateTime { get; set; }
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
        public long Bigint1 { get; set; }
        public long Bigint2 { get; set; }
        public long Bigint3 { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public int Int3 { get; set; }
        public bool Bit1 { get; set; }
        public bool Bit2 { get; set; }
        public bool Bit3 { get; set; }
        public DateTime? CreationTime { get; set; } 
    }
}
