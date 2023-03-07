using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.CustomerCore
{
    public class CustomerUserMapping : Entity<long>, IHasCreationTime
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Status { get; set; }
        public string Creator { get; set; }
        //public DateTime? CreateTime { get; set; }
        public string Updator { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
