
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.InventoryCore.Dtos
{	
	
    /// <summary>
	/// WMS_Inventory_Used的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_Inventory_UsedInput
    {
        [Required]
        public WMS_Inventory_UsedEditDto WMS_Inventory_Used { get; set; }

		/* 这里创建自己的代码 */
    }
}