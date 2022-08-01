
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderExpandCore.Dtos
{	
	
    /// <summary>
	/// WMS_OrderAddress的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_OrderAddressInput
    {
        [Required]
        public WMS_OrderAddressEditDto WMS_OrderAddress { get; set; }

		/* 这里创建自己的代码 */
    }
}