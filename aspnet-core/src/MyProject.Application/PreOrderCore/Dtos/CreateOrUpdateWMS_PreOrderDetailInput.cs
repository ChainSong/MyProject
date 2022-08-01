
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.PreOrderCore.Dtos
{	
	
    /// <summary>
	/// WMS_PreOrderDetail的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_PreOrderDetailInput
    {
        [Required]
        public WMS_PreOrderDetailEditDto WMS_PreOrderDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}