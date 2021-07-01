
using Abp.Runtime.Validation;
using MyProject.Dtos;
using MyProject.ASNCode;
using System;

namespace MyProject.ASNCode.Dtos
{
    /// <summary>
    /// 获取的传入参数Dto
    /// </summary>
    public class GetWMS_ASNsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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

        //// custom codes

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// ExtensionGUID
        /// </summary>
        public Guid? ExtensionGUID { get; set; }



        /// <summary>
        /// ASNNumber
        /// </summary>
        public string ASNNumber { get; set; }



        /// <summary>
        /// ExternReceiptNumber
        /// </summary>
        public string ExternReceiptNumber { get; set; }



        /// <summary>
        /// CustomerID
        /// </summary>
        public long CustomerID { get; set; }



        /// <summary>
        /// CustomerName
        /// </summary>
        public string CustomerName { get; set; }



        /// <summary>
        /// WarehouseID
        /// </summary>
        public long WarehouseID { get; set; }



        /// <summary>
        /// WarehouseName
        /// </summary>
        public string WarehouseName { get; set; }



        /// <summary>
        /// ExpectDate
        /// </summary>
        public DateTime?[] ExpectDate { get; set; }



        /// <summary>
        /// ASNStatus
        /// </summary>
        public int ASNStatus { get; set; }



        /// <summary>
        /// ASNType
        /// </summary>
        public string ASNType { get; set; }



        /// <summary>
        /// PO
        /// </summary>
        public string PO { get; set; }



        /// <summary>
        /// Contact
        /// </summary>
        public string Contact { get; set; }



        /// <summary>
        /// ContactInfo
        /// </summary>
        public string ContactInfo { get; set; }



        /// <summary>
        /// CompleteDate
        /// </summary>
        public DateTime?[] CompleteDate { get; set; }



        /// <summary>
        /// Remark
        /// </summary>
        public string Remark { get; set; }



        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }



        /// <summary>
        /// CreationTime
        /// </summary>
        public DateTime[] CreationTime { get; set; }



        /// <summary>
        /// Updator
        /// </summary>
        public string Updator { get; set; }



        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime?[] UpdateTime { get; set; }



        /// <summary>
        /// Str1
        /// </summary>
        public string Str1 { get; set; }



        /// <summary>
        /// Str2
        /// </summary>
        public string Str2 { get; set; }



        /// <summary>
        /// Str3
        /// </summary>
        public string Str3 { get; set; }



        /// <summary>
        /// Str4
        /// </summary>
        public string Str4 { get; set; }



        /// <summary>
        /// Str5
        /// </summary>
        public string Str5 { get; set; }



        /// <summary>
        /// Str6
        /// </summary>
        public string Str6 { get; set; }



        /// <summary>
        /// Str7
        /// </summary>
        public string Str7 { get; set; }



        /// <summary>
        /// Str8
        /// </summary>
        public string Str8 { get; set; }



        /// <summary>
        /// Str9
        /// </summary>
        public string Str9 { get; set; }



        /// <summary>
        /// Str10
        /// </summary>
        public string Str10 { get; set; }



        /// <summary>
        /// Str11
        /// </summary>
        public string Str11 { get; set; }



        /// <summary>
        /// Str12
        /// </summary>
        public string Str12 { get; set; }



        /// <summary>
        /// Str13
        /// </summary>
        public string Str13 { get; set; }



        /// <summary>
        /// Str14
        /// </summary>
        public string Str14 { get; set; }



        /// <summary>
        /// Str15
        /// </summary>
        public string Str15 { get; set; }



        /// <summary>
        /// Str16
        /// </summary>
        public string Str16 { get; set; }



        /// <summary>
        /// Str17
        /// </summary>
        public string Str17 { get; set; }



        /// <summary>
        /// Str18
        /// </summary>
        public string Str18 { get; set; }



        /// <summary>
        /// Str19
        /// </summary>
        public string Str19 { get; set; }



        /// <summary>
        /// Str20
        /// </summary>
        public string Str20 { get; set; }



        /// <summary>
        /// DateTime1
        /// </summary>
        public DateTime?[] DateTime1 { get; set; }



        /// <summary>
        /// DateTime2
        /// </summary>
        public DateTime?[] DateTime2 { get; set; }



        /// <summary>
        /// DateTime3
        /// </summary>
        public DateTime?[] DateTime3 { get; set; }



        /// <summary>
        /// DateTime4
        /// </summary>
        public DateTime?[] DateTime4 { get; set; }



        /// <summary>
        /// DateTime5
        /// </summary>
        public DateTime?[] DateTime5 { get; set; }



        /// <summary>
        /// Int1
        /// </summary>
        public int Int1 { get; set; }



        /// <summary>
        /// Int2
        /// </summary>
        public int Int2 { get; set; }



        /// <summary>
        /// Int3
        /// </summary>
        public int Int3 { get; set; }



        /// <summary>
        /// Int4
        /// </summary>
        public int Int4 { get; set; }



        /// <summary>
        /// Int5
        /// </summary>
        public int Int5 { get; set; }




        //// custom codes end
    }
}
