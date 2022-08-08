
using System;
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

		/// <summary>
		/// 字段ProjectId
		/// </summary>
		public long ProjectId { get; set; }

		/// <summary>
		/// 字段CustomerCode
		/// </summary>
		public string CustomerCode { get; set; }

		/// <summary>
		/// 字段CustomerName
		/// </summary>
		public string CustomerName { get; set; }

		/// <summary>
		/// 字段Description
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 字段CustomerType
		/// </summary>
		public string CustomerType { get; set; }

		/// <summary>
		/// 字段CustomerStatus
		/// </summary>
		public int CustomerStatus { get; set; }

		/// <summary>
		/// 字段CreditLine
		/// </summary>
		public string CreditLine { get; set; }

		/// <summary>
		/// 字段Province
		/// </summary>
		public string Province { get; set; }

		/// <summary>
		/// 字段City
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// 字段Address
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// 字段Remark
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 字段Email
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 字段Phone
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// 字段LawPerson
		/// </summary>
		public string LawPerson { get; set; }

		/// <summary>
		/// 字段PostCode
		/// </summary>
		public string PostCode { get; set; }

		/// <summary>
		/// 字段Bank
		/// </summary>
		public string Bank { get; set; }

		/// <summary>
		/// 字段Account
		/// </summary>
		public string Account { get; set; }

		/// <summary>
		/// 字段TaxId
		/// </summary>
		public string TaxId { get; set; }

		/// <summary>
		/// 字段InvoiceTitle
		/// </summary>
		public string InvoiceTitle { get; set; }

		/// <summary>
		/// 字段Fax
		/// </summary>
		public string Fax { get; set; }

		/// <summary>
		/// 字段WebSite
		/// </summary>
		public string WebSite { get; set; }

		/// <summary>
		/// 字段Creator
		/// </summary>
		public string Creator { get; set; }

		/// <summary>
		/// 字段Updator
		/// </summary>
		public string Updator { get; set; }

		/// <summary>
		/// 字段CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }

 
		
		/* 这里创建自己的代码 */
	}
}