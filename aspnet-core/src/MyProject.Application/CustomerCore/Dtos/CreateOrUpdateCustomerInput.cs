
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.CustomerCore.Dtos
{	
	
    /// <summary>
	/// Customer的列表DTO
	/// </summary>
	public class CreateOrUpdateCustomerInput
    {
        [Required]
        public CustomerEditDto Customer { get; set; }

		/* 这里创建自己的代码 */
    }
}