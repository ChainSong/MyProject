
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_OrderDetailForEditOutput
    {

        public WMS_OrderDetailEditDto WMS_OrderDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}