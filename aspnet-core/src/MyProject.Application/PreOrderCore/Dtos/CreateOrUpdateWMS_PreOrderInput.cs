
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.PreOrderCore.Dtos
{	
	
    /// <summary>
	/// WMS_PreOrder的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_PreOrderInput
    {
        [Required]
        public WMS_PreOrderEditDto WMS_PreOrder { get; set; }

		/* 这里创建自己的代码 */
    }
}