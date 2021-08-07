
using Abp.Runtime.Validation;
using MyProject.Dtos;
using MyProject.CustomerCore;

namespace MyProject.CustomerCore.Dtos
{
    /// <summary>
    /// 获取的传入参数Dto
    /// </summary>
    public class GetCustomerUserMappingsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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

        public long UserId { get; set; }
        public string UserName { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Status { get; set; } = 1;
        public string Creator { get; set; }

        //// custom codes end
    }
}
