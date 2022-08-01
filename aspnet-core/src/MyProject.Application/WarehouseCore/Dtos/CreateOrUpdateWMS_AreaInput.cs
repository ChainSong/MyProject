
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WarehouseCore.Dtos
{	
	
    /// <summary>
	/// WMS_Area的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_AreaInput
    {
        [Required]
        public WMS_AreaEditDto WMS_Area { get; set; }

		/* 这里创建自己的代码 */
    }
}