
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.PackageCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_PackageDetailForEditOutput
    {

        public WMS_PackageDetailEditDto WMS_PackageDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}