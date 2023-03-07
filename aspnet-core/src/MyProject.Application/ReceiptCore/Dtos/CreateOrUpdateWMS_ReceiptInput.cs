
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ReceiptCore.Dtos
{	
	
    /// <summary>
	/// WMS_Receipt的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_ReceiptInput
    {
        [Required]
        public WMS_ReceiptEditDto WMS_Receipt { get; set; }
        public List<WMS_ReceiptEditDto> WMS_Receipts { get; set; }

        /* 这里创建自己的代码 */
    }
}