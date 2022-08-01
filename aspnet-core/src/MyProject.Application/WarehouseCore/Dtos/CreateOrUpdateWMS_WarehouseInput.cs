
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WarehouseCore.Dtos
{	
	
    /// <summary>
	/// WMS_Warehouse的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_WarehouseInput
    {
        [Required]
        public WMS_WarehouseEditDto WMS_Warehouse { get; set; }

		/* 这里创建自己的代码 */
    }
}