
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderCore.Dtos
{	
	
    /// <summary>
	/// WMS_Order的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_OrderInput
    {
        [Required]
        public WMS_OrderEditDto WMS_Order { get; set; }

		/* 这里创建自己的代码 */
    }
}