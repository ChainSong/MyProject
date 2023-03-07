
using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace MyProject.CustomerCore.Dtos
{
	/// <summary>
	/// CustomerUserMapping的列表DTO
	/// <see cref=""/>
	/// </summary>
	[AutoMap(typeof(CustomerUserMapping))]
	public class CustomerUserMappingListDto  
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

		/// <summary>
		/// 字段UserId
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 字段UserName
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// 字段CustomerId
		/// </summary>
		public long CustomerId { get; set; }

		/// <summary>
		/// 字段CustomerName
		/// </summary>
		public string CustomerName { get; set; }

		/// <summary>
		/// 字段Status
		/// </summary>
		public int Status { get; set; }

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