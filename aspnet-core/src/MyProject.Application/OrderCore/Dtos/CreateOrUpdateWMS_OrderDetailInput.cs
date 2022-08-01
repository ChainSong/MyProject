
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderCore.Dtos
{	
	
    /// <summary>
	/// WMS_OrderDetail的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_OrderDetailInput
    {
        [Required]
        public WMS_OrderDetailEditDto WMS_OrderDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}