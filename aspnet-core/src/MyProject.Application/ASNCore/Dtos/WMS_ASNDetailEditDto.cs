
using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using MyProject;
using Abp.AutoMapper;

namespace MyProject.ASNCore.Dtos
{
	/// <summary>
	/// WMS_ASNDetail的列表DTO
	/// <see cref="WMS_ASNDetail"/>
	/// </summary>
	[AutoMap(typeof(WMS_ASNDetail))]
	public class WMS_ASNDetailEditDto
    {
        public long Id { get; set; }
        public long ASNId { get; set; }

        public string ASNNumber { get; set; }

        public string ExternReceiptNumber { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public long WarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public string LineNumber { get; set; }

        public string SKU { get; set; }

        public string UPC { get; set; }

        public string GoodsType { get; set; }

        public string GoodsName { get; set; }

        public string BoxCode { get; set; }

        public string TrayCode { get; set; }

        public string BatchCode { get; set; }

        public double ExpectedQty { get; set; }

        public double ReceivedQty { get; set; }

        public double ReceiptQty { get; set; }

        public string UnitCode { get; set; }

        public string Onwer { get; set; }

        public DateTime? ProductionDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string Remark { get; set; }

        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Str1 { get; set; }

        public string Str2 { get; set; }

        public string Str3 { get; set; }

        public string Str4 { get; set; }

        public string Str5 { get; set; }

        public string Str6 { get; set; }

        public string Str7 { get; set; }

        public string Str8 { get; set; }

        public string Str9 { get; set; }

        public string Str10 { get; set; }

        public string Str11 { get; set; }

        public string Str12 { get; set; }

        public string Str13 { get; set; }

        public string Str14 { get; set; }

        public string Str15 { get; set; }

        public string Str16 { get; set; }

        public string Str17 { get; set; }

        public string Str18 { get; set; }

        public string Str19 { get; set; }

        public string Str20 { get; set; }

        public DateTime? DateTime1 { get; set; }

        public DateTime? DateTime2 { get; set; }

        public DateTime? DateTime3 { get; set; }

        public DateTime? DateTime4 { get; set; }

        public DateTime? DateTime5 { get; set; }

        public int? Int1 { get; set; }

        public int? Int2 { get; set; }

        public int? Int3 { get; set; }

        public int? Int4 { get; set; }

        public int? Int5 { get; set; }



        /* 这里创建自己的代码 */
    }
}