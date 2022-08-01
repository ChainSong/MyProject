
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ASNCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetWMS_ASNForEditOutput
    {

        public WMS_ASNEditDto WMS_ASN { get; set; }

		/* 这里创建自己的代码 */
    }
}