
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WarehouseCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_WarehouseForEditOutput
    {

        public WMS_WarehouseEditDto WMS_Warehouse { get; set; }

		/* 这里创建自己的代码 */
    }
}