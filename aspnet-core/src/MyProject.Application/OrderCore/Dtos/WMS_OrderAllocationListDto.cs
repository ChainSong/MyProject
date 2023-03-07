
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace MyProject.OrderCore.Dtos
{	
	/// <summary>
	/// WMS_OrderAllocation的列表DTO
	/// <see cref=""/>
	/// </summary>
    public class WMS_OrderAllocationListDto  : EntityDto<long>
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

		/// <summary>
		/// 字段InventoryId
		/// </summary>
		public long InventoryId { get; set; }

		/// <summary>
		/// 字段OrderId
		/// </summary>
		public long OrderId { get; set; }

		/// <summary>
		/// 字段OrderDetailId
		/// </summary>
		public long OrderDetailId { get; set; }

		/// <summary>
		/// 字段CustomerId
		/// </summary>
		public long CustomerId { get; set; }

		/// <summary>
		/// 字段CustomerName
		/// </summary>
		public string CustomerName { get; set; }

		/// <summary>
		/// 字段WarehouseId
		/// </summary>
		public long WarehouseId { get; set; }

		/// <summary>
		/// 字段WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }

		/// <summary>
		/// 字段Area
		/// </summary>
		public string Area { get; set; }

		/// <summary>
		/// 字段Location
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// 字段SKU
		/// </summary>
		public string SKU { get; set; }

		/// <summary>
		/// 字段UPC
		/// </summary>
		public string UPC { get; set; }

		/// <summary>
		/// 字段GoodsType
		/// </summary>
		public string GoodsType { get; set; }

		/// <summary>
		/// 字段InventoryStatus
		/// </summary>
		public int InventoryStatus { get; set; }

		/// <summary>
		/// 字段SuperId
		/// </summary>
		public long SuperId { get; set; }

		/// <summary>
		/// 字段RelatedId
		/// </summary>
		public long RelatedId { get; set; }

		/// <summary>
		/// 字段GoodsName
		/// </summary>
		public string GoodsName { get; set; }

		/// <summary>
		/// 字段UnitCode
		/// </summary>
		public string UnitCode { get; set; }

		/// <summary>
		/// 字段Onwer
		/// </summary>
		public string Onwer { get; set; }

		/// <summary>
		/// 字段BoxCode
		/// </summary>
		public string BoxCode { get; set; }

		/// <summary>
		/// 字段TrayCode
		/// </summary>
		public string TrayCode { get; set; }

		/// <summary>
		/// 字段BatchCode
		/// </summary>
		public string BatchCode { get; set; }

		/// <summary>
		/// 字段Qty
		/// </summary>
		public double Qty { get; set; }

		/// <summary>
		/// 字段Remark
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 字段Str1
		/// </summary>
		public string Str1 { get; set; }

		/// <summary>
		/// 字段Str2
		/// </summary>
		public string Str2 { get; set; }

		/// <summary>
		/// 字段Str3
		/// </summary>
		public string Str3 { get; set; }

		/// <summary>
		/// 字段Str4
		/// </summary>
		public string Str4 { get; set; }

		/// <summary>
		/// 字段Str5
		/// </summary>
		public string Str5 { get; set; }

		/// <summary>
		/// 字段Int1
		/// </summary>
		public int Int1 { get; set; }

		/// <summary>
		/// 字段Int2
		/// </summary>
		public int Int2 { get; set; }
		
		/* 这里创建自己的代码 */
	}
}