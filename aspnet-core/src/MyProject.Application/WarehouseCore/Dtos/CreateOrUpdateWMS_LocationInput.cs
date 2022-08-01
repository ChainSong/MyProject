
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WarehouseCore.Dtos
{	
	
    /// <summary>
	/// WMS_Location的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_LocationInput
    {
        [Required]
        public WMS_LocationEditDto WMS_Location { get; set; }

		/* 这里创建自己的代码 */
    }
}