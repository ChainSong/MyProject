
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace MyProject.OrderExpandCore.Dtos
{	
	/// <summary>
	/// WMS_OrderAddress的列表DTO
	/// <see cref=""/>
	/// </summary>
    public class WMS_OrderAddressListDto  : EntityDto<long>
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

		/// <summary>
		/// 字段PreOrderId
		/// </summary>
		public string PreOrderId { get; set; }

		/// <summary>
		/// 字段PreOrderNumber
		/// </summary>
		public string PreOrderNumber { get; set; }

		/// <summary>
		/// 字段ExternReceiptNumber
		/// </summary>
		public string ExternReceiptNumber { get; set; }

		/// <summary>
		/// 字段Name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 字段Phone
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// 字段ZipCode
		/// </summary>
		public string ZipCode { get; set; }

		/// <summary>
		/// 字段Province
		/// </summary>
		public string Province { get; set; }

		/// <summary>
		/// 字段City
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// 字段Country
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// 字段Address
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// 字段ExpressCompany
		/// </summary>
		public string ExpressCompany { get; set; }

		/// <summary>
		/// 字段ExpressNumber
		/// </summary>
		public string ExpressNumber { get; set; }
		
		/* 这里创建自己的代码 */
	}
}