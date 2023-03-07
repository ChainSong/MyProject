
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using MyProject;
using Abp.AutoMapper;

namespace MyProject.WarehouseCore.Dtos
{
	/// <summary>
	/// WarehouseUserMapping的列表DTO
	/// <see cref="WarehouseUserMapping"/>
	/// </summary>
	[AutoMap(typeof(WarehouseUserMapping))]
	public class WarehouseUserMappingEditDto
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
		/// 字段WarehouseId
		/// </summary>
		public long WarehouseId { get; set; }
		/// <summary>
		/// 字段WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }
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