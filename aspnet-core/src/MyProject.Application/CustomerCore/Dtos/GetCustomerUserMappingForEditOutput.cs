
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.CustomerCore.Dtos
{	
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetCustomerUserMappingForEditOutput
    {

        public CustomerUserMappingEditDto CustomerUserMapping { get; set; }

		/* 这里创建自己的代码 */
    }
}