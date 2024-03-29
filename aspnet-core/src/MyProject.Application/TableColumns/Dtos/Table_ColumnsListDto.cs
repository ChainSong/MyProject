

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
    /// <see cref="Table_Columns"/>
    /// </summary>
    [AutoMap(typeof(Table_Columns))]
    public class Table_ColumnsListDto : EntityDto<long>, IHasCreationTime
    {


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

        public string ColumnName
        {
            get
            {
                var resolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                return resolver.GetResolvedPropertyName(DbColumnName);
            }
        }
        public string RelationColumn
        {
            get
            {
                var resolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                return resolver.GetResolvedPropertyName(RelationDBColumn);
            }
        }

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

        public string Characteristic { get; set; }
        public string Default { get; set; }
        public string RelationDBColumn { get; set; }

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



        /// <summary>
        /// Validation
        /// </summary>
        public string Validation { get; set; }



        /// <summary>
        /// Associated
        /// </summary>
        public string Associated { get; set; }

        public int Precision { get; set; }
        public double Step { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        public string Link { get; set; }

        
        /// <summary>
        /// Table_ColumnsDetails
        /// </summary>
        public List<Table_ColumnsDetail> TableColumnsDetails { get; set; }




        //// custom codes







        //public List<Table_ColumnsDetail> Table_ColumnsDetails { get; set; }



        //// custom codes end
    }
}