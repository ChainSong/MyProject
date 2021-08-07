
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using MyProject.CustomerCore;


namespace  MyProject.CustomerCore.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="CustomerUserMapping"/>
	/// </summary>
    public class CustomerUserMappingEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
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