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
   public class WMS_Area : Entity<long>, IHasCreationTime
    {
        public long? WarehouseId { get; set; }

        [StringLength(50)]
        public string WarehouseName { get; set; }

        [StringLength(50)]
        public string AreaName { get; set; }

        public int? AreaStatus { get; set; }

        [StringLength(50)]
        public string AreaType { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        [StringLength(50)]
        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
