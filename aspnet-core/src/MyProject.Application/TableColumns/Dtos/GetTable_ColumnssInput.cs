
using Abp.Runtime.Validation;
using MyProject.Dtos;
using MyProject.TableColumns;

namespace MyProject.TableColumns.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetTable_ColumnssInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
									
							

									
							


        public int TenantId { get; set; }
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

        
							
							//// custom codes end
    }
}
