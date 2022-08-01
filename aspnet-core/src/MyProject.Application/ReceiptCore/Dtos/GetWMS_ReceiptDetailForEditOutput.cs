
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ReceiptCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_ReceiptDetailForEditOutput
    {

        public WMS_ReceiptDetailEditDto WMS_ReceiptDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}