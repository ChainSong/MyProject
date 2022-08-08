
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using MyProject.TableColumns;
using Abp.AutoMapper;

namespace  MyProject.TableColumns.Dtos
{
	/// <summary>
	/// 的列表DTO
	/// <see cref="Table_Columns"/>
	/// </summary>
	[AutoMap(typeof(Table_Columns))]
	public class Table_ColumnsEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// RoleName
		/// </summary>
		public string RoleName { get; set; }



		/// <summary>
		/// TableName
		/// </summary>
		public string TableName { get; set; }



		/// <summary>
		/// TableNameCH
		/// </summary>
		public string TableNameCH { get; set; }



		/// <summary>
		/// DisplayName
		/// </summary>
		public string DisplayName { get; set; }



		/// <summary>
		/// DbColumnName
		/// </summary>
		public string DbColumnName { get; set; }



		/// <summary>
		/// IsKey
		/// </summary>
		public int IsKey { get; set; }



		/// <summary>
		/// IsSearchCondition
		/// </summary>
		public int IsSearchCondition { get; set; }



		/// <summary>
		/// IsHide
		/// </summary>
		public int IsHide { get; set; }



		/// <summary>
		/// IsReadOnly
		/// </summary>
		public int IsReadOnly { get; set; }



		/// <summary>
		/// IsShowInList
		/// </summary>
		public int IsShowInList { get; set; }



		/// <summary>
		/// IsImportColumn
		/// </summary>
		public int IsImportColumn { get; set; }



		/// <summary>
		/// IsDropDownList
		/// </summary>
		public int IsDropDownList { get; set; }



		/// <summary>
		/// IsCreate
		/// </summary>
		public int IsCreate { get; set; }



		/// <summary>
		/// IsUpdate
		/// </summary>
		public int IsUpdate { get; set; }



		/// <summary>
		/// SearchConditionOrder
		/// </summary>
		public int SearchConditionOrder { get; set; }



		/// <summary>
		/// Group
		/// </summary>
		public string Group { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		public string Type { get; set; }



		/// <summary>
		/// Order
		/// </summary>
		public int Order { get; set; }



		/// <summary>
		/// ForView
		/// </summary>
		public int ForView { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public long TenantId { get; set; }



		/// <summary>
		/// ProjectId
		/// </summary>
		public long ProjectId { get; set; }



		/// <summary>
		/// CustomerId
		/// </summary>
		public long CustomerId { get; set; }

		public int Precision { get; set; }
		public double Step { get; set; }
		public double Max { get; set; }
		public double Min { get; set; }

		/// <summary>
		/// Validation
		/// </summary>
		public string Validation { get; set; }



		/// <summary>
		/// Associated
		/// </summary>
		public string Associated { get; set; }



		/// <summary>
		/// Table_ColumnsDetails
		/// </summary>
		public List<Table_ColumnsDetail> Table_ColumnsDetails { get; set; }



		
							//// custom codes
									
							

							//// custom codes end
    }
}