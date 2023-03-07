
using Abp.Runtime.Validation;
using MyProject;
using MyProject.CustomerCore;
using MyProject.Dtos;
using System;

namespace MyProject.CustomerCore.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetCustomersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

        //// 自定义编码开始
        public long ProjectId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string CustomerType { get; set; }
        public int CustomerStatus { get; set; }
        public string CreditLine { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LawPerson { get; set; }
        public string PostCode { get; set; }
        public string Bank { get; set; }
        public string Account { get; set; }
        public string TaxId { get; set; }
        public string InvoiceTitle { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string Creator { get; set; }
        public DateTime? CreateTime { get; set; }


        public string Updator { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? CreationTime { get; set; }
        //// 自定义编码结束
    }
}
