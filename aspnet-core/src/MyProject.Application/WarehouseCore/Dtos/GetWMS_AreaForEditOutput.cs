
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WarehouseCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_AreaForEditOutput
    {

        public WMS_AreaEditDto WMS_Area { get; set; }

		/* 这里创建自己的代码 */
    }
}