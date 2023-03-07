
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_OrderAllocationForEditOutput
    {

        public WMS_OrderAllocationEditDto WMS_OrderAllocation { get; set; }

		/* 这里创建自己的代码 */
    }
}