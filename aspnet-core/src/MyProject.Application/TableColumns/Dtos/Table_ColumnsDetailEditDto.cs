
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using MyProject.TableColumns;
using Abp.AutoMapper;

namespace MyProject.TableColumns.Dtos
{
    /// <summary>
    /// 的列表DTO
    /// <see cref="Table_ColumnsDetail"/>
    /// </summary>
    [AutoMap(typeof(Table_Columns))]
    public class Table_ColumnsDetailEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }



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