using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TableColumns
{

    public class Table_Columns : Entity<long>, IHasCreationTime
    {

        public long TenantId { get; set; }
        public long ProjectId { get; set; }
        public string RoleName { get; set; }
        public long CustomerId { get; set; }
        public string TableName { get; set; }
        public string TableNameCH { get; set; }
        public string DisplayName { get; set; }
        public string DbColumnName { get; set; }
        public int IsKey { get; set; }
        public int IsSearchCondition { get; set; }
        public int IsHide { get; set; }
        public int IsReadOnly { get; set; }
        public int IsShowInList { get; set; }
        public int IsImportColumn { get; set; }
        public int IsDropDownList { get; set; }
        public int IsCreate { get; set; }
        public int IsUpdate { get; set; }
        public int SearchConditionOrder { get; set; }
        public string Validation { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
        public string Associated { get; set; }
        public int Order { get; set; }
        public int ForView { get; set; }
        public DateTime CreationTime { get; set; } = new DateTime();


        public List<Table_ColumnsDetail> Table_ColumnsDetails { get; set; }
    }
}
