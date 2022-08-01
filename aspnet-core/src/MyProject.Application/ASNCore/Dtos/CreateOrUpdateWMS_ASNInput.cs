
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ASNCore.Dtos
{	
	
    /// <summary>
	/// WMS_ASN的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_ASNInput
    {
        [Required]
        public WMS_ASNEditDto WMS_ASN { get; set; }

		/* 这里创建自己的代码 */
    }
}