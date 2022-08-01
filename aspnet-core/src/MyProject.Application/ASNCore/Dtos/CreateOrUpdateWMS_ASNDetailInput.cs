
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ASNCore.Dtos
{	
	
    /// <summary>
	/// WMS_ASNDetail的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_ASNDetailInput
    {
        [Required]
        public WMS_ASNDetailEditDto WMS_ASNDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}