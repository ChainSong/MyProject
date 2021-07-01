
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using MyProject.ProductCore;


namespace  MyProject.ProductCore.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="WMS_Product"/>
	/// </summary>
    public class WMS_ProductEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// ProductID
		/// </summary>
		public long ProductID { get; set; }



		/// <summary>
		/// CustomerID
		/// </summary>
		public long CustomerID { get; set; }



		/// <summary>
		/// CustomerName
		/// </summary>
		public string CustomerName { get; set; }



		/// <summary>
		/// WarehouseID
		/// </summary>
		public long WarehouseID { get; set; }



		/// <summary>
		/// WarehouseName
		/// </summary>
		public string WarehouseName { get; set; }



		/// <summary>
		/// SKU
		/// </summary>
		public string SKU { get; set; }



		/// <summary>
		/// ProductStatus
		/// </summary>
		public int ProductStatus { get; set; }



		/// <summary>
		/// GoodsName
		/// </summary>
		public string GoodsName { get; set; }



		/// <summary>
		/// GoodsType
		/// </summary>
		public string GoodsType { get; set; }



		/// <summary>
		/// SKUClassification
		/// </summary>
		public string SKUClassification { get; set; }



		/// <summary>
		/// SKUGroup
		/// </summary>
		public string SKUGroup { get; set; }



		/// <summary>
		/// ManufacturerSKU
		/// </summary>
		public string ManufacturerSKU { get; set; }



		/// <summary>
		/// RetailSKU
		/// </summary>
		public string RetailSKU { get; set; }



		/// <summary>
		/// ReplaceSKU
		/// </summary>
		public string ReplaceSKU { get; set; }



		/// <summary>
		/// BoxGroup
		/// </summary>
		public string BoxGroup { get; set; }



		/// <summary>
		/// Packing
		/// </summary>
		public string Packing { get; set; }



		/// <summary>
		/// Grade
		/// </summary>
		public string Grade { get; set; }



		/// <summary>
		/// Country
		/// </summary>
		public string Country { get; set; }



		/// <summary>
		/// Manufacturer
		/// </summary>
		public string Manufacturer { get; set; }



		/// <summary>
		/// DangerCode
		/// </summary>
		public string DangerCode { get; set; }



		/// <summary>
		/// Vvolume
		/// </summary>
		public string Vvolume { get; set; }



		/// <summary>
		/// StandardVolume
		/// </summary>
		public string StandardVolume { get; set; }



		/// <summary>
		/// Weight
		/// </summary>
		public string Weight { get; set; }



		/// <summary>
		/// StandardWeight
		/// </summary>
		public string StandardWeight { get; set; }



		/// <summary>
		/// NetWeight
		/// </summary>
		public string NetWeight { get; set; }



		/// <summary>
		/// StandardNetWeight
		/// </summary>
		public string StandardNetWeight { get; set; }



		/// <summary>
		/// Price
		/// </summary>
		public string Price { get; set; }



		/// <summary>
		/// ActualPrice
		/// </summary>
		public decimal ActualPrice { get; set; }



		/// <summary>
		/// Cost
		/// </summary>
		public string Cost { get; set; }



		/// <summary>
		/// ActualCost
		/// </summary>
		public string ActualCost { get; set; }



		/// <summary>
		/// StandardOrderingCost
		/// </summary>
		public string StandardOrderingCost { get; set; }



		/// <summary>
		/// ShipmentCost
		/// </summary>
		public string ShipmentCost { get; set; }



		/// <summary>
		/// QcInSpectionLoc
		/// </summary>
		public string QcInSpectionLoc { get; set; }



		/// <summary>
		/// QcPercentage
		/// </summary>
		public string QcPercentage { get; set; }



		/// <summary>
		/// ReceiptQcUom
		/// </summary>
		public string ReceiptQcUom { get; set; }



		/// <summary>
		/// QcEligible
		/// </summary>
		public string QcEligible { get; set; }



		/// <summary>
		/// PutArea
		/// </summary>
		public string PutArea { get; set; }



		/// <summary>
		/// PutCode
		/// </summary>
		public string PutCode { get; set; }



		/// <summary>
		/// PutRule
		/// </summary>
		public string PutRule { get; set; }



		/// <summary>
		/// PutStrategy
		/// </summary>
		public string PutStrategy { get; set; }



		/// <summary>
		/// AllocateRule
		/// </summary>
		public string AllocateRule { get; set; }



		/// <summary>
		/// PickedCode
		/// </summary>
		public string PickedCode { get; set; }



		/// <summary>
		/// SKUType
		/// </summary>
		public string SKUType { get; set; }



		/// <summary>
		/// Color
		/// </summary>
		public string Color { get; set; }



		/// <summary>
		/// Size_L
		/// </summary>
		public string Size_L { get; set; }



		/// <summary>
		/// Size_W
		/// </summary>
		public string Size_W { get; set; }



		/// <summary>
		/// Size_H
		/// </summary>
		public string Size_H { get; set; }



		/// <summary>
		/// ExpirationDate
		/// </summary>
		public int ExpirationDate { get; set; }



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
		/// Bigint1
		/// </summary>
		public long Bigint1 { get; set; }



		/// <summary>
		/// Bigint2
		/// </summary>
		public long Bigint2 { get; set; }



		/// <summary>
		/// Bigint3
		/// </summary>
		public long Bigint3 { get; set; }



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
		/// Bit1
		/// </summary>
		public bool Bit1 { get; set; }



		/// <summary>
		/// Bit2
		/// </summary>
		public bool Bit2 { get; set; }



		/// <summary>
		/// Bit3
		/// </summary>
		public bool Bit3 { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime? CreationTime { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}