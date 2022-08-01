
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace MyProject.WarehouseCore.Dtos
{	
	/// <summary>
	/// WMS_Area的列表DTO
	/// <see cref=""/>
	/// </summary>
    public class WMS_AreaListDto  
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

		/// <summary>
		/// 字段WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }

		/// <summary>
		/// 字段AreaName
		/// </summary>
		public string AreaName { get; set; }

		/// <summary>
		/// 字段AreaType
		/// </summary>
		public string AreaType { get; set; }

		/// <summary>
		/// 字段Remark
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 字段Creator
		/// </summary>
		public string Creator { get; set; }

		/// <summary>
		/// 字段CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }

		/// <summary>
		/// 字段Updator
		/// </summary>
		public string Updator { get; set; }
		
		/* 这里创建自己的代码 */
	}
}