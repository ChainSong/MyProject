
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace MyProject.CustomerCore.Dtos
{	
	/// <summary>
	/// CustomerDetail的列表DTO
	/// <see cref=""/>
	/// </summary>
    public class CustomerDetailListDto  
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

		/// <summary>
		/// 字段CustomerId
		/// </summary>
		public long CustomerId { get; set; }

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
		/// 字段Contact
		/// </summary>
		public string Contact { get; set; }

		/// <summary>
		/// 字段TEL
		/// </summary>
		public string TEL { get; set; }

		/// <summary>
		/// 字段Creator
		/// </summary>
		public string Creator { get; set; }

		/// <summary>
		/// 字段CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }

		 
		
		/* 这里创建自己的代码 */
	}
}