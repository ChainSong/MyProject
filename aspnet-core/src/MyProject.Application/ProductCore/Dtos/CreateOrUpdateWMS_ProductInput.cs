
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ProductCore.Dtos
{	
	
    /// <summary>
	/// WMS_Product的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_ProductInput
    {
        //[Required]
        public WMS_ProductEditDto WMS_Product { get; set; }

		/* 这里创建自己的代码 */
    }
}