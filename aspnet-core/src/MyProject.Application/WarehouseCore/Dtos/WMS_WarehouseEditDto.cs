
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using MyProject;
namespace MyProject.WarehouseCore.Dtos
{	
	/// <summary>
	/// WMS_Warehouse的列表DTO
	/// <see cref="WMS_Warehouse"/>
	/// </summary>
    public class WMS_WarehouseEditDto
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
		/// 字段WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }
		/// <summary>
		/// 字段WarehouseStatus
		/// </summary>
		public int WarehouseStatus { get; set; }
		/// <summary>
		/// 字段WarehouseType
		/// </summary>
		public string WarehouseType { get; set; }
		/// <summary>
		/// 字段Description
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// 字段Company
		/// </summary>
		public string Company { get; set; }
		/// <summary>
		/// 字段Address
		/// </summary>
		public string Address { get; set; }
		/// <summary>
		/// 字段Province
		/// </summary>
		public string Province { get; set; }
		/// <summary>
		/// 字段City
		/// </summary>
		public string City { get; set; }
		/// <summary>
		/// 字段Contractor
		/// </summary>
		public string Contractor { get; set; }
		/// <summary>
		/// 字段ContractorAddress
		/// </summary>
		public string ContractorAddress { get; set; }
		/// <summary>
		/// 字段Mobile
		/// </summary>
		public string Mobile { get; set; }
		/// <summary>
		/// 字段Phone
		/// </summary>
		public string Phone { get; set; }
		/// <summary>
		/// 字段Fax
		/// </summary>
		public string Fax { get; set; }
		/// <summary>
		/// 字段Email
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// 字段Remark
		/// </summary>
		public string Remark { get; set; }
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