
using Abp.Runtime.Validation;
using MyProject;
using MyProject.WarehouseCore;
using MyProject.Dtos;
using System;

namespace MyProject.WarehouseCore.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetWMS_LocationsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
        public long WarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public long AreaId { get; set; }

        public string AreaName { get; set; }

        public string Location { get; set; }

        public int LocationStatus { get; set; }

        public string LocationType { get; set; }

        public int Classification { get; set; }

        public int Category { get; set; }

        public string ABCClassification { get; set; }

        public int IsMultiLot { get; set; }

        public int IsMultiSKU { get; set; }

        public string LocationLevel { get; set; }

        public string GoodsPutOrder { get; set; }

        public string GoodsPickOrder { get; set; }

        public string SKU { get; set; }

        public string Creator { get; set; }

        public DateTime? CreationTime { get; set; }

        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }
        //// 自定义编码结束
    }
}
