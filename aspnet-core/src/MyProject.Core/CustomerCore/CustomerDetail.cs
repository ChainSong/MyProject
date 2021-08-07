using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.CustomerCore
{
    public class CustomerDetail : Entity<long>, IHasCreationTime
    {
        //[ForeignKey("CustomerId")]
        public long CustomerId { get; set; }
        public long ProjectId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string TEL { get; set; }
        public string Creator { get; set; }
        public DateTime CreationTime { get; set; } = new DateTime();
        public virtual Customer Customer { get; set; }
        
        //DateTime IHasCreationTime.CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
