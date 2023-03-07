
using Abp.Runtime.Validation;
using MyProject;
using MyProject.InventoryCore;
using MyProject.Dtos;
using System;

namespace MyProject.InventoryCore.Dtos
{
    /// <summary>
    /// 获取的传入参数Dto
    /// </summary>
    public class GetWMS_Inventory_UsablesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
        public long ASNDetailId { get; set; }

        public long ReceiptDetailId { get; set; }

        public long ReceiptReceivingId { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public long WarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public string Area { get; set; }

        public string Location { get; set; }

        public string SKU { get; set; }

        public string UPC { get; set; }

        public string GoodsType { get; set; }

        public int InventoryStatus { get; set; }

        public long SuperId { get; set; }

        public long RelatedId { get; set; }

        public string GoodsName { get; set; }

        public string UnitCode { get; set; }

        public string Onwer { get; set; }

        public string BoxCode { get; set; }

        public string TrayCode { get; set; }

        public string BatchCode { get; set; }

        public double Qty { get; set; }

        public DateTime[] ProductionDate { get; set; }

        public DateTime[] ExpirationDate { get; set; }

        public string Remark { get; set; }

        public DateTime[] InventoryTime { get; set; }

        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }

        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Str1 { get; set; }

        public string Str2 { get; set; }

        public string Str3 { get; set; }

        public string Str4 { get; set; }

        public string Str5 { get; set; }

        public DateTime? DateTime1 { get; set; }

        public DateTime? DateTime2 { get; set; }

        public int? Int1 { get; set; }

        public int? Int2 { get; set; }
        //// 自定义编码结束
    }
}
