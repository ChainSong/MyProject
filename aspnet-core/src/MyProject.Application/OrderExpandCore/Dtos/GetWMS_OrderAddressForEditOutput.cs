
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.OrderExpandCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_OrderAddressForEditOutput
    {

        public WMS_OrderAddressEditDto WMS_OrderAddress { get; set; }

		/* 这里创建自己的代码 */
    }
}