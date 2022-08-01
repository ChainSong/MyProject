using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.CustomerCore
{
    //[AutoMapFrom(typeof(CustomerInfo))]

    public class Customer : Entity<long>, IHasCreationTime
    {
      
        public long ProjectId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string CustomerType { get; set; }
        public int CustomerStatus { get; set; }
        public string CreditLine { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LawPerson { get; set; }
        public string PostCode { get; set; }
        public string Bank { get; set; }
        public string Account { get; set; }
        public string TaxId { get; set; }
        public string InvoiceTitle { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string Creator { get; set; }
        public DateTime? CreateTime { get; set; }


        public string Updator { get; set; }
        public DateTime? UpdateTime { get; set; }

        //public DateTime CreationTime { get ; set => DateTime() }==> new DateTime();
        public DateTime CreationTime { get; set; } = new DateTime();
        //DateTime IHasCreationTime.CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<CustomerDetail> CustomerDetails { get; set; }
    }
}
