
using Abp.Runtime.Validation;
using MyProject.Dtos;
using MyProject.ReceiptCore;

namespace MyProject.ReceiptCore.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetWMS_ReceiptDetailsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
