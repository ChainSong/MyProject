
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ASNCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_ASNDetailForEditOutput
    {

        public WMS_ASNDetailEditDto WMS_ASNDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}