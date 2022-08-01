
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.InventoryCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_Inventory_UsedForEditOutput
    {

        public WMS_Inventory_UsedEditDto WMS_Inventory_Used { get; set; }

		/* 这里创建自己的代码 */
    }
}