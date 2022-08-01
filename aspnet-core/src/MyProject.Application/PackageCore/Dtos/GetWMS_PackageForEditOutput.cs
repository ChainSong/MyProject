
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.PackageCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_PackageForEditOutput
    {

        public WMS_PackageEditDto WMS_Package { get; set; }

		/* 这里创建自己的代码 */
    }
}