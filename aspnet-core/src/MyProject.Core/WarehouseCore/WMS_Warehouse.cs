using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.WarehouseCore
{
    public class WMS_Warehouse : Entity<long>, IHasCreationTime
    {
 

        public long ProjectId { get; set; }

        [StringLength(50)]
        public string WarehouseName { get; set; }

        public int WarehouseStatus { get; set; }

        [StringLength(50)]
        public string WarehouseType { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Contractor { get; set; }

        [StringLength(50)]
        public string ContractorAddress { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        [StringLength(50)]
        public string Updator { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }
    }
}
