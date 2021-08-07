

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
    /// <see cref="Customer"/>
    /// </summary>
    [AutoMap(typeof(Customer))]
    public class CustomerListDto : EntityDto<long>, IHasCreationTime
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
        /// Description
        /// </summary>
        public string Description { get; set; }



        /// <summary>
        /// CustomerType
        /// </summary>
        public string CustomerType { get; set; }



        /// <summary>
        /// CustomerStatus
        /// </summary>
        public int CustomerStatus { get; set; }



        /// <summary>
        /// CreditLine
        /// </summary>
        public string CreditLine { get; set; }



        /// <summary>
        /// Province
        /// </summary>
        public string Province { get; set; }



        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }



        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }



        /// <summary>
        /// Remark
        /// </summary>
        public string Remark { get; set; }



        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }



        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }



        /// <summary>
        /// LawPerson
        /// </summary>
        public string LawPerson { get; set; }



        /// <summary>
        /// PostCode
        /// </summary>
        public string PostCode { get; set; }



        /// <summary>
        /// Bank
        /// </summary>
        public string Bank { get; set; }



        /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }



        /// <summary>
        /// TaxID
        /// </summary>
        public string TaxId { get; set; }



        /// <summary>
        /// InvoiceTitle
        /// </summary>
        public string InvoiceTitle { get; set; }



        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }



        /// <summary>
        /// WebSite
        /// </summary>
        public string WebSite { get; set; }



        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }



        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }



        /// <summary>
        /// CreationTime
        /// </summary>
        public DateTime CreationTime { get; set; }



        /// <summary>
        /// CustomerDetails
        /// </summary>
        public List<CustomerDetailEditDto> CustomerDetails { get; set; }




        //// custom codes



        //// custom codes end
    }
}