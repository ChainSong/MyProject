
using Abp.Runtime.Validation;
using MyProject.Dtos;
using MyProject.Customers;

namespace MyProject.Customers.Dtos
{
    /// <summary>
    /// 获取的传入参数Dto
    /// </summary>
    public class GetCustomerDetailsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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



        //// custom codes end
    }
}
