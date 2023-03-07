
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderCore.Dtos
{	
	
    /// <summary>
	/// WMS_OrderAllocation的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_OrderAllocationInput
    {
        [Required]
        public WMS_OrderAllocationEditDto WMS_OrderAllocation { get; set; }

		/* 这里创建自己的代码 */
    }
}