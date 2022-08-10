
using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace MyProject.CustomerCore.Dtos
{
	/// <summary>
	/// Customer的列表DTO
	/// <see cref=""/>
	/// </summary>
	[AutoMap(typeof(Customer))]
	public class CustomerListDto  
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

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
        public DateTime? CreationTime { get; set; }


        public List<CustomerDetailListDto> CustomerDetails { get; set; }
        /* 这里创建自己的代码 */
    }
}