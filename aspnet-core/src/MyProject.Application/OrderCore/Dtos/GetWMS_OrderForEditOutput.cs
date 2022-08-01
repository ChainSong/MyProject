
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_OrderForEditOutput
    {

        public WMS_OrderEditDto WMS_Order { get; set; }

		/* 这里创建自己的代码 */
    }
}