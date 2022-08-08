
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProject.CustomerCore.Dtos
{	
	
    /// <summary>
	/// CustomerDetail的列表DTO
	/// </summary>
	public class CreateOrUpdateCustomerDetailInput
    {
        //[Required]
        public CustomerDetailEditDto CustomerDetail { get; set; }

		/* 这里创建自己的代码 */
    }
}