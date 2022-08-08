
using Abp.Runtime.Validation;
using MyProject;
using MyProject.ProductCore;
using MyProject.Dtos;
using System;

namespace MyProject.ProductCore.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetWMS_ProductsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

        //// 自定义编码开始
        public long CustomerId { get; set; }

        
        public string CustomerName { get; set; }

        
        
        public string SKU { get; set; }

        public int ProductStatus { get; set; }

        
       
        public string GoodsName { get; set; }

        
        public string GoodsType { get; set; }

        
        public string SKUClassification { get; set; }

        
        public string SKULevel { get; set; }

        public long SuperId { get; set; }

        
        public string SKUGroup { get; set; }

        
        public string ManufacturerSKU { get; set; }

        
        public string RetailSKU { get; set; }

        
        public string ReplaceSKU { get; set; }

        
        public string BoxGroup { get; set; }

        
        public string Country { get; set; }

        
        public string Manufacturer { get; set; }

        
        public string DangerCode { get; set; }

        
        public double Volume { get; set; }

        
        public double StandardVolume { get; set; }

        
        public double Weight { get; set; }

        
        public double StandardWeight { get; set; }

        
        public double NetWeight { get; set; }

        
        public double StandardNetWeight { get; set; }

        public double Price { get; set; }

        public double ActualPrice { get; set; }

        
        public string Cost { get; set; }

        
        public string Color { get; set; }

        public double Length { get; set; }

        public double Wide { get; set; }

        public double High { get; set; }

        public int ExpirationDate { get; set; }

        
        public string Remark { get; set; }

        
        public string Creator { get; set; }

        public DateTime[] CreationTime { get; set; }

        
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

        public int Int1 { get; set; }

        public int Int2 { get; set; }

        public int Int3 { get; set; }
        //// 自定义编码结束
    }
}
