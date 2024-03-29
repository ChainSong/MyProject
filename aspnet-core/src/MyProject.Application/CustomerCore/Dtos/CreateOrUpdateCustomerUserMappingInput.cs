
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProject.CustomerCore.Dtos
{	
	
    /// <summary>
	/// CustomerUserMapping的列表DTO
	/// </summary>
	public class CreateOrUpdateCustomerUserMappingInput
    {
        //[Required]
        public CustomerUserMappingEditDto CustomerUserMapping { get; set; }
        public List<CustomerUserMappingEditDto> CustomerUserMappings { get; set; }

        /* 这里创建自己的代码 */
    }
}