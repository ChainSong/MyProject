
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using MyProject;
namespace MyProject.PackageCore.Dtos
{	
	/// <summary>
	/// WMS_PackageDetail的列表DTO
	/// <see cref="WMS_PackageDetail"/>
	/// </summary>
    public class WMS_PackageDetailEditDto
    {
		/// <summary>
        /// Id 
        /// </summary>
        public long? Id { get; set; }

		/// <summary>
		/// 字段PackageId
		/// </summary>
		public long PackageId { get; set; }
		/// <summary>
		/// 字段OrderNumber
		/// </summary>
		public string OrderNumber { get; set; }
		/// <summary>
		/// 字段ExternOrderNumber
		/// </summary>
		public string ExternOrderNumber { get; set; }
		/// <summary>
		/// 字段PackageNumber
		/// </summary>
		public string PackageNumber { get; set; }
		/// <summary>
		/// 字段CustomerId
		/// </summary>
		public long CustomerId { get; set; }
		/// <summary>
		/// 字段CustomerName
		/// </summary>
		public string CustomerName { get; set; }
		/// <summary>
		/// 字段WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }
		/// <summary>
		/// 字段SKU
		/// </summary>
		public string SKU { get; set; }
		/// <summary>
		/// 字段GoodsName
		/// </summary>
		public string GoodsName { get; set; }
		/// <summary>
		/// 字段GoodsType
		/// </summary>
		public string GoodsType { get; set; }
		/// <summary>
		/// 字段Qty
		/// </summary>
		public double Qty { get; set; }
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
		/// 字段Str6
		/// </summary>
		public string Str6 { get; set; }
		/// <summary>
		/// 字段Str7
		/// </summary>
		public string Str7 { get; set; }
		/// <summary>
		/// 字段Str8
		/// </summary>
		public string Str8 { get; set; }
		/// <summary>
		/// 字段Str9
		/// </summary>
		public string Str9 { get; set; }
		/// <summary>
		/// 字段Str10
		/// </summary>
		public string Str10 { get; set; }
		/// <summary>
		/// 字段Str11
		/// </summary>
		public string Str11 { get; set; }
		/// <summary>
		/// 字段Str12
		/// </summary>
		public string Str12 { get; set; }
		/// <summary>
		/// 字段Str13
		/// </summary>
		public string Str13 { get; set; }
		/// <summary>
		/// 字段Str14
		/// </summary>
		public string Str14 { get; set; }
		/// <summary>
		/// 字段Str15
		/// </summary>
		public string Str15 { get; set; }
		/// <summary>
		/// 字段Str16
		/// </summary>
		public string Str16 { get; set; }
		/// <summary>
		/// 字段Str17
		/// </summary>
		public string Str17 { get; set; }
		/// <summary>
		/// 字段Str18
		/// </summary>
		public string Str18 { get; set; }
		/// <summary>
		/// 字段Str19
		/// </summary>
		public string Str19 { get; set; }
		/// <summary>
		/// 字段Str20
		/// </summary>
		public string Str20 { get; set; }
		/// <summary>
		/// 字段UPC
		/// </summary>
		public string UPC { get; set; }
 
		
		/* 这里创建自己的代码 */
	}
}