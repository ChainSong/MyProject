using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.OrderExpandCore
{
    public class WMS_OrderAddress : Entity<long>
    {
        [StringLength(10)]
        public string PreOrderId { get; set; }

        [StringLength(50)]
        public string PreOrderNumber { get; set; }

        [StringLength(50)]
        public string ExternReceiptNumber { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        [StringLength(20)]
        public string Province { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(20)]
        public string ExpressCompany { get; set; }

        [StringLength(50)]
        public string ExpressNumber { get; set; }
    }
}
