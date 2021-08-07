

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MyProject.WarehouseCore;
using System.Collections.ObjectModel;


namespace MyProject.WarehouseCore.Dtos
{
    /// <summary>
    /// 的列表DTO
    /// <see cref="WarehouseUserMapping"/>
    /// </summary>
    public class WarehouseUserMappingListDto : EntityDto<long>
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
        /// WarehouseId
        /// </summary>
        public long WarehouseId { get; set; }



        /// <summary>
        /// WarehouseName
        /// </summary>
        public string WarehouseName { get; set; }



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