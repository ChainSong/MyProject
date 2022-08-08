using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ProductCore
{
    public class WMS_Product : Entity<long>, IHasCreationTime
    {
        public long CustomerId { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        public int ProductStatus { get; set; }

        [Required]
        [StringLength(100)]
        public string GoodsName { get; set; }

        [StringLength(50)]
        public string GoodsType { get; set; }

        [StringLength(50)]
        public string SKUClassification { get; set; }

        [StringLength(50)]
        public string SKULevel { get; set; }

        public long SuperId { get; set; }

        [StringLength(50)]
        public string SKUGroup { get; set; }

        [StringLength(50)]
        public string ManufacturerSKU { get; set; }

        [StringLength(50)]
        public string RetailSKU { get; set; }

        [StringLength(50)]
        public string ReplaceSKU { get; set; }

        [StringLength(50)]
        public string BoxGroup { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        public string DangerCode { get; set; }

        [StringLength(50)]
        public double Volume { get; set; }

        [StringLength(50)]
        public double StandardVolume { get; set; }

        [StringLength(50)]
        public double Weight { get; set; }

        [StringLength(50)]
        public double StandardWeight { get; set; }

        [StringLength(50)]
        public double NetWeight { get; set; }

        [StringLength(50)]
        public double StandardNetWeight { get; set; }

        public double Price { get; set; }

        public double ActualPrice { get; set; }

        [StringLength(50)]
        public string Cost { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public double Length { get; set; }

        public double Wide { get; set; }

        public double High { get; set; }

        public int ExpirationDate { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        [StringLength(50)]
        public string Str1 { get; set; }

        [StringLength(50)]
        public string Str2 { get; set; }

        [StringLength(50)]
        public string Str3 { get; set; }

        [StringLength(50)]
        public string Str4 { get; set; }

        [StringLength(50)]
        public string Str5 { get; set; }

        [StringLength(50)]
        public string Str6 { get; set; }

        [StringLength(50)]
        public string Str7 { get; set; }

        [StringLength(50)]
        public string Str8 { get; set; }

        [StringLength(50)]
        public string Str9 { get; set; }

        [StringLength(50)]
        public string Str10 { get; set; }

        [StringLength(100)]
        public string Str11 { get; set; }

        [StringLength(100)]
        public string Str12 { get; set; }

        [StringLength(100)]
        public string Str13 { get; set; }

        [StringLength(100)]
        public string Str14 { get; set; }

        [StringLength(100)]
        public string Str15 { get; set; }

        [StringLength(200)]
        public string Str16 { get; set; }

        [StringLength(200)]
        public string Str17 { get; set; }

        [StringLength(200)]
        public string Str18 { get; set; }

        [StringLength(500)]
        public string Str19 { get; set; }

        [StringLength(500)]
        public string Str20 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateTime1 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateTime2 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateTime3 { get; set; } 

        public int Int1 { get; set; }

        public int Int2 { get; set; }

        public int Int3 { get; set; }
    }
} 
