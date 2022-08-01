
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.InventoryCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_Inventory_UsableForEditOutput
    {

        public WMS_Inventory_UsableEditDto WMS_Inventory_Usable { get; set; }

		/* 这里创建自己的代码 */
    }
}