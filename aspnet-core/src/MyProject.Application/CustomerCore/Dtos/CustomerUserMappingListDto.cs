

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MyProject.CustomerCore;
using System.Collections.ObjectModel;


namespace MyProject.CustomerCore.Dtos
{	
	/// <summary>
	/// 的列表DTO
	/// <see cref="CustomerUserMapping"/>
	/// </summary>
    public class CustomerUserMappingListDto : EntityDto<long>
    {

        
		/// <summary>
		/// UserId
		/// </summary>
		public long UserId { get; set; }



		/// <summary>
		/// UserName
		/// </summary>
		public string UserName { get; set; }



		/// <summary>
		/// CustomerId
		/// </summary>
		public long CustomerId { get; set; }



		/// <summary>
		/// CustomerName
		/// </summary>
		public string CustomerName { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		public int Status { get; set; }



		/// <summary>
		/// Creator
		/// </summary>
		public string Creator { get; set; }



		/// <summary>
		/// CreateTime
		/// </summary>
		public DateTime? CreateTime { get; set; }



		/// <summary>
		/// Updator
		/// </summary>
		public string Updator { get; set; }



		/// <summary>
		/// UpdateTime
		/// </summary>
		public DateTime? UpdateTime { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}