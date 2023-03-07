

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MyProject.TableColumns;
using System.Collections.ObjectModel;
using Abp.AutoMapper;

namespace MyProject.TableColumns.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="Table_ColumnsDetail"/>
	/// </summary>
	[AutoMap(typeof(Table_ColumnsDetail))]
	public class Table_ColumnsDetailListDto : EntityDto<long>,IHasCreationTime 
    {

        
		/// <summary>
		/// Code
		/// </summary>
		public string CodeStr { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		public string Type { get; set; }


		public string Color { get; set; }

		/// <summary>
		/// Status
		/// </summary>
		public string Status { get; set; }



		/// <summary>
		/// Creator
		/// </summary>
		public int Creator { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// CodeN
		/// </summary>
		public int CodeInt { get; set; }



		/// <summary>
		/// Associated
		/// </summary>
		public string Associated { get; set; }



		/// <summary>
		/// Table_Columns
		/// </summary>
		public Table_Columns Table_Columns { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}