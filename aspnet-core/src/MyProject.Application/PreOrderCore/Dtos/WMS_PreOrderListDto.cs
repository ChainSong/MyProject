
using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace MyProject.PreOrderCore.Dtos
{
	/// <summary>
	/// WMS_PreOrder的列表DTO
	/// <see cref=""/>
	/// </summary>
	[AutoMap(typeof(WMS_PreOrder))]
	public class WMS_PreOrderListDto  
    {

        public long? Id { get; set; }
        public string PreOrderNumber { get; set; }

        public string ExternOrderNumber { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public long WarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public string OrderType { get; set; }

        public int PreOrderStatus { get; set; }

        public DateTime? OrderTime { get; set; }

        public DateTime? CompleteTime { get; set; }

        public double DetailCount { get; set; }

        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Remark { get; set; }

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

        public List<WMS_PreOrderDetailListDto> PreOrderDetails { get; set; }

        /* 这里创建自己的代码 */
    }
}