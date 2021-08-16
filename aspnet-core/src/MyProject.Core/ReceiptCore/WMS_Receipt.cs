﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptCore
{
    public class WMS_Receipt : Entity<long>, IHasCreationTime
    {
        public string ReceiptNumber { get; set; }
        public string ExternReceiptNumber { get; set; }
        public Guid? ExtensionGUID { get; set; }
        public long ASNId { get; set; }
        public string ASNNumber { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public int ReceiptStatus { get; set; }
        public string ReceiptType { get; set; }
        public string PO { get; set; }
        public string Contact { get; set; }
        public string ContactInfo { get; set; }
        public string CompleteDate { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Updator { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public string Str5 { get; set; }
        public string Str6 { get; set; }
        public string Str7 { get; set; }
        public string Str8 { get; set; }
        public string Str9 { get; set; }
        public string Str10 { get; set; }
        public string Str11 { get; set; }
        public string Str12 { get; set; }
        public string Str13 { get; set; }
        public string Str14 { get; set; }
        public string Str15 { get; set; }
        public string Str16 { get; set; }
        public string Str17 { get; set; }
        public string Str18 { get; set; }
        public string Str19 { get; set; }
        public string Str20 { get; set; }
        public DateTime? DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }
        public DateTime? DateTime3 { get; set; }
        public DateTime? DateTime4 { get; set; }
        public DateTime? DateTime5 { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public int Int3 { get; set; }
        public int Int4 { get; set; }
        public int Int5 { get; set; }
        public DateTime CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
