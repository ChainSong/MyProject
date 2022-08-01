
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ReceiptReceivingCore.Dtos
{	
	
    /// <summary>
	/// WMS_ReceiptReceiving的列表DTO
	/// </summary>
	public class CreateOrUpdateWMS_ReceiptReceivingInput
    {
        [Required]
        public WMS_ReceiptReceivingEditDto WMS_ReceiptReceiving { get; set; }

		/* 这里创建自己的代码 */
    }
}