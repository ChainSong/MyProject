

using System;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MyProject.CustomerCore;
using System.Collections.ObjectModel;
using Abp.AutoMapper;

namespace MyProject.CustomerCore.Dtos
{
    /// <summary>
    /// 的列表DTO
    /// <see cref="CustomerDetail"/>
    /// </summary>
    [AutoMap(typeof(CustomerDetail))]
    public class CustomerDetailListDto : EntityDto<long>, IHasCreationTime
    {


        /// <summary>
        /// ProjectId
        /// </summary>
        public long ProjectId { get; set; }



        /// <summary>
        /// CustomerCode
        /// </summary>
        public string CustomerCode { get; set; }



        /// <summary>
        /// CustomerName
        /// </summary>
        public string CustomerName { get; set; }



        /// <summary>
        /// Contact
        /// </summary>
        public string Contact { get; set; }



        /// <summary>
        /// Tel
        /// </summary>
        public string Tel { get; set; }



        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }



        /// <summary>
        /// CreationTime
        /// </summary>
        public DateTime CreationTime { get; set; }



        /// <summary>
        /// CustomerId
        /// </summary>
        public long CustomerId { get; set; }



        /// <summary>
        /// Customer
        /// </summary>
        //public Customer Customer { get; set; }




        //// custom codes



        //// custom codes end
    }
}