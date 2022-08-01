
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.PackageCore.Dtos
{	
	
    /// <summary>
	/// WMS_PackageDetail的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_PackageDetailInput
    {
        [Required]
        public WMS_PackageDetailEditDto WMS_PackageDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}