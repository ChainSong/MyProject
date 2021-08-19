

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MyProject.ReceiptReceivingCore;
using System.Collections.ObjectModel;


namespace MyProject.ReceiptReceivingCore.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="WMS_ReceiptReceiving"/>
	/// </summary>
    public class WMS_ReceiptReceivingListDto : EntityDto<long>,IHasCreationTime 
    {

        
		/// <summary>
		/// ReceiptDetailId
		/// </summary>
		public long ReceiptDetailId { get; set; }



		/// <summary>
		/// ReceiptId
		/// </summary>
		public long ReceiptId { get; set; }



		/// <summary>
		/// ASNId
		/// </summary>
		public long ASNId { get; set; }



		/// <summary>
		/// ASNDetailId
		/// </summary>
		public long ASNDetailId { get; set; }



		/// <summary>
		/// ExtensionDetailGUID
		/// </summary>
		public Guid? ExtensionDetailGUID { get; set; }



		/// <summary>
		/// ReceiptNumber
		/// </summary>
		public string ReceiptNumber { get; set; }



		/// <summary>
		/// ExternReceiptNumber
		/// </summary>
		public string ExternReceiptNumber { get; set; }



		/// <summary>
		/// ASNNumber
		/// </summary>
		public string ASNNumber { get; set; }



		/// <summary>
		/// CustomerId
		/// </summary>
		public long CustomerId { get; set; }



		/// <summary>
		/// CustomerName
		/// </summary>
		public string CustomerName { get; set; }



		/// <summary>
		/// WarehouseId
		/// </summary>
		public long WarehouseId { get; set; }



		/// <summary>
		/// WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }



		/// <summary>
		/// LineNumber
		/// </summary>
		public string LineNumber { get; set; }



		/// <summary>
		/// SKU
		/// </summary>
		public string SKU { get; set; }



		/// <summary>
		/// UPC
		/// </summary>
		public string UPC { get; set; }



		/// <summary>
		/// RRStatus
		/// </summary>
		public int RRStatus { get; set; }



		/// <summary>
		/// GoodsType
		/// </summary>
		public string GoodsType { get; set; }



		/// <summary>
		/// GoodsName
		/// </summary>
		public string GoodsName { get; set; }



		/// <summary>
		/// BoxNumber
		/// </summary>
		public string BoxNumber { get; set; }



		/// <summary>
		/// BatchNumber
		/// </summary>
		public string BatchNumber { get; set; }



		/// <summary>
		/// QtyReceived
		/// </summary>
		public decimal QtyReceived { get; set; }



		/// <summary>
		/// Unit
		/// </summary>
		public string Unit { get; set; }



		/// <summary>
		/// Specifications
		/// </summary>
		public string Specifications { get; set; }



		/// <summary>
		/// Area
		/// </summary>
		public string Area { get; set; }



		/// <summary>
		/// Location
		/// </summary>
		public string Location { get; set; }



		/// <summary>
		/// Price
		/// </summary>
		public decimal Price { get; set; }



		/// <summary>
		/// Weight
		/// </summary>
		public float Weight { get; set; }



		/// <summary>
		/// Volume
		/// </summary>
		public float Volume { get; set; }



		/// <summary>
		/// ProductionDate
		/// </summary>
		public DateTime? ProductionDate { get; set; }



		/// <summary>
		/// ExpirationDate
		/// </summary>
		public DateTime? ExpirationDate { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }



		/// <summary>
		/// Creator
		/// </summary>
		public string Creator { get; set; }



		/// <summary>
		/// CreateTime
		/// </summary>
		public DateTime? CreateTime { get; set; }



		/// <summary>
		/// Updator
		/// </summary>
		public string Updator { get; set; }



		/// <summary>
		/// UpdateTime
		/// </summary>
		public DateTime? UpdateTime { get; set; }



		/// <summary>
		/// Str1
		/// </summary>
		public string Str1 { get; set; }



		/// <summary>
		/// Str2
		/// </summary>
		public string Str2 { get; set; }



		/// <summary>
		/// Str3
		/// </summary>
		public string Str3 { get; set; }



		/// <summary>
		/// Str4
		/// </summary>
		public string Str4 { get; set; }



		/// <summary>
		/// Str5
		/// </summary>
		public string Str5 { get; set; }



		/// <summary>
		/// Str6
		/// </summary>
		public string Str6 { get; set; }



		/// <summary>
		/// Str7
		/// </summary>
		public string Str7 { get; set; }



		/// <summary>
		/// Str8
		/// </summary>
		public string Str8 { get; set; }



		/// <summary>
		/// Str9
		/// </summary>
		public string Str9 { get; set; }



		/// <summary>
		/// Str10
		/// </summary>
		public string Str10 { get; set; }



		/// <summary>
		/// Str11
		/// </summary>
		public string Str11 { get; set; }



		/// <summary>
		/// Str12
		/// </summary>
		public string Str12 { get; set; }



		/// <summary>
		/// Str13
		/// </summary>
		public string Str13 { get; set; }



		/// <summary>
		/// Str14
		/// </summary>
		public string Str14 { get; set; }



		/// <summary>
		/// Str15
		/// </summary>
		public string Str15 { get; set; }



		/// <summary>
		/// Str16
		/// </summary>
		public string Str16 { get; set; }



		/// <summary>
		/// Str17
		/// </summary>
		public string Str17 { get; set; }



		/// <summary>
		/// Str18
		/// </summary>
		public string Str18 { get; set; }



		/// <summary>
		/// Str19
		/// </summary>
		public string Str19 { get; set; }



		/// <summary>
		/// Str20
		/// </summary>
		public string Str20 { get; set; }



		/// <summary>
		/// DateTime1
		/// </summary>
		public DateTime? DateTime1 { get; set; }



		/// <summary>
		/// DateTime2
		/// </summary>
		public DateTime? DateTime2 { get; set; }



		/// <summary>
		/// DateTime3
		/// </summary>
		public DateTime? DateTime3 { get; set; }



		/// <summary>
		/// DateTime4
		/// </summary>
		public DateTime? DateTime4 { get; set; }



		/// <summary>
		/// DateTime5
		/// </summary>
		public DateTime? DateTime5 { get; set; }



		/// <summary>
		/// Int1
		/// </summary>
		public int Int1 { get; set; }



		/// <summary>
		/// Int2
		/// </summary>
		public int Int2 { get; set; }



		/// <summary>
		/// Int3
		/// </summary>
		public int Int3 { get; set; }



		/// <summary>
		/// Int4
		/// </summary>
		public int Int4 { get; set; }



		/// <summary>
		/// Int5
		/// </summary>
		public int Int5 { get; set; }
        public DateTime CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }




        //// custom codes



        //// custom codes end
    }
}