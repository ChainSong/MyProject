
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WarehouseCore.Dtos
{	
	
    /// <summary>
	/// WarehouseUserMapping的列表DTO
	/// </summary>
	public class CreateOrUpdateWarehouseUserMappingInput
    {
   
        public WarehouseUserMappingEditDto WarehouseUserMapping { get; set; }
        public List<WarehouseUserMappingEditDto> WarehouseUserMappings { get; set; }

		

		/* 这里创建自己的代码 */
	}
}