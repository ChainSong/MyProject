
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ReceiptCore.Dtos
{	
	
    /// <summary>
	/// WMS_ReceiptDetail的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_ReceiptDetailInput
    {
        [Required]
        public WMS_ReceiptDetailEditDto WMS_ReceiptDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}