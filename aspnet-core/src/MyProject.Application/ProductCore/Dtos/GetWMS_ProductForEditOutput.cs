
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ProductCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_ProductForEditOutput
    {

        public WMS_ProductEditDto WMS_Product { get; set; }

		/* 这里创建自己的代码 */
    }
}