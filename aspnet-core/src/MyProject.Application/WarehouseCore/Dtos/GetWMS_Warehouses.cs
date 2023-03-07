
using Abp.Runtime.Validation;
using MyProject;
using MyProject.WarehouseCore;
using MyProject.Dtos;
using System;
using Abp.AutoMapper;

namespace MyProject.WarehouseCore.Dtos
{
    /// <summary>
    /// 获取的传入参数Dto
    /// </summary>
    [AutoMap(typeof(WMS_Warehouse))]
    public class GetWMS_Warehouses
    {

        public long Id { get; set; }

        //// 自定义编码开始
        public string WarehouseName { get; set; }

        public int WarehouseStatus { get; set; }

        public string WarehouseType { get; set; }

        public string Description { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Contractor { get; set; }

        public string ContractorAddress { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Remark { get; set; }

        public string Creator { get; set; }

        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime CreationTime { get; set; }
        //// 自定义编码结束
    }
}
