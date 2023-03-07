
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using MyProject;
using Abp.AutoMapper;

namespace MyProject.WarehouseCore.Dtos
{	
	/// <summary>
	/// WMS_Location的列表DTO
	/// <see cref="WMS_Location"/>
	/// </summary>
	[AutoMap(typeof(WMS_Location))]

	public class WMS_LocationEditDto
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

		/// <summary>
		/// 字段WarehouseId
		/// </summary>
		public long WarehouseId { get; set; }
		/// <summary>
		/// 字段WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }
		/// <summary>
		/// 字段AreaId
		/// </summary>
		public string AreaId { get; set; }
		/// <summary>
		/// 字段AreaName
		/// </summary>
		public string AreaName { get; set; }
		/// <summary>
		/// 字段Location
		/// </summary>
		public string Location { get; set; }
		
		/// <summary>
		/// 字段LocationType
		/// </summary>
		public int LocationStatus { get; set; }
		/// <summary>
		/// 字段LocationType
		/// </summary>
		public string LocationType { get; set; }
		/// <summary>
		/// 字段Classification
		/// </summary>
		public int Classification { get; set; }
		/// <summary>
		/// 字段Category
		/// </summary>
		public int Category { get; set; }
		/// <summary>
		/// 字段ABCClassification
		/// </summary>
		public string ABCClassification { get; set; }
		/// <summary>
		/// 字段IsMultiLot
		/// </summary>
		public int IsMultiLot { get; set; }
		/// <summary>
		/// 字段IsMultiSKU
		/// </summary>
		public int IsMultiSKU { get; set; }
		/// <summary>
		/// 字段LocationLevel
		/// </summary>
		public string LocationLevel { get; set; }
		/// <summary>
		/// 字段GoodsPutOrder
		/// </summary>
		public string GoodsPutOrder { get; set; }
		/// <summary>
		/// 字段GoodsPickOrder
		/// </summary>
		public string GoodsPickOrder { get; set; }
		/// <summary>
		/// 字段SKU
		/// </summary>
		public string SKU { get; set; }
		/// <summary>
		/// 字段Creator
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		/// 字段CreationTime
		/// </summary>
		public DateTime? CreationTime { get; set; }
		/// <summary>
		/// 字段Updator
		/// </summary>
		public string Updator { get; set; }

		public DateTime? UpdateTime { get; set; }

		/* 这里创建自己的代码 */
	}
}