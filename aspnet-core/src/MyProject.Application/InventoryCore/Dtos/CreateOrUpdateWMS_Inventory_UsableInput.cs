
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.InventoryCore.Dtos
{	
	
    /// <summary>
	/// WMS_Inventory_Usable的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_Inventory_UsableInput
    {
        [Required]
        public WMS_Inventory_UsableEditDto WMS_Inventory_Usable { get; set; }

		/* 这里创建自己的代码 */
    }
}