using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.WarehouseCore
{
   public class WMS_Location : Entity<long>, IHasCreationTime
    {
        public long WarehouseId { get; set; }

        [Required]
        [StringLength(50)]
        public string WarehouseName { get; set; }

        [StringLength(50)]
        public string AreaId { get; set; }

        [StringLength(50)]
        public string AreaName { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? LocationStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string LocationType { get; set; }

        public int Classification { get; set; }

        public int Category { get; set; }

        [StringLength(50)]
        public string ABCClassification { get; set; }

        public bool IsMultiLot { get; set; }

        public bool IsMultiSKU { get; set; }

        [StringLength(50)]
        public string LocationLevel { get; set; }

        [StringLength(50)]
        public string GoodsPutOrder { get; set; }

        [StringLength(50)]
        public string GoodsPickOrder { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime  CreationTime { get; set; }

        [StringLength(50)]
        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
