
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.PackageCore.Dtos
{	
	
    /// <summary>
	/// WMS_Package的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_PackageInput
    {
        [Required]
        public WMS_PackageEditDto WMS_Package { get; set; }

		/* 这里创建自己的代码 */
    }
}