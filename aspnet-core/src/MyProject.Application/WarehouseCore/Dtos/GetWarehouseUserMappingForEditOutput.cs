
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WarehouseCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWarehouseUserMappingForEditOutput
    {

        public WarehouseUserMappingEditDto WarehouseUserMapping { get; set; }

		/* 这里创建自己的代码 */
    }
}