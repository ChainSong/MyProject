using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PackageCore
{
    public class WMS_Package  : Entity<long>, IHasCreationTime
    {
        [Required]
        [StringLength(50)]
        public string PackageNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string ExternOrderNumber { get; set; }

        public long CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        public long? WarehouseId { get; set; }

        [StringLength(50)]
        public string WarehouseName { get; set; }

        [StringLength(50)]
        public string PackageType { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        public double? NetWeight { get; set; }

        public double? GrossWeight { get; set; }

        [StringLength(50)]
        public string ExpressCompany { get; set; }

        [StringLength(50)]
        public string ExpressNumber { get; set; }

        public int? IsComposited { get; set; }

        public int? IsHandovered { get; set; }

        [StringLength(50)]
        public string Handoveror { get; set; }

        public DateTime? HandoverTime { get; set; }

        public int PackageStatus { get; set; }

        public DateTime? PackageTime { get; set; }

        public int? DetailCount { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        [StringLength(50)]
        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

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

        [StringLength(50)]
        public string Str11 { get; set; }

        [StringLength(50)]
        public string Str12 { get; set; }

        [StringLength(50)]
        public string Str13 { get; set; }

        [StringLength(50)]
        public string Str14 { get; set; }

        [StringLength(50)]
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

        public DateTime? DateTime1 { get; set; }

        public DateTime? DateTime2 { get; set; }

        public DateTime? DateTime3 { get; set; }

        public DateTime? DateTime4 { get; set; }

        public DateTime? DateTime5 { get; set; }

        public int? Int1 { get; set; }

        public int? Int2 { get; set; }

        public int? Int3 { get; set; }

        public int? Int4 { get; set; }

        public int? Int5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WMS_PackageDetail> WMS_PackageDetail { get; set; }
    }
}
