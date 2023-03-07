
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace serv.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_PreOrderDetailForEditOutput
    {

        public WMS_PreOrderDetailEditDto WMS_PreOrderDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}