
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
        public long ProjectId { get; set; }

        public long CustomerId { get; set; }
        public string TableName { get; set; }

        public string TableFormat { get; set; }

        public string RoleName { get; set; }

        //// custom codes end
    }
}
