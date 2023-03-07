
using Abp.Runtime.Validation;
using MyProject;
using MyProject.OrderCore;
using MyProject.Dtos;
namespace MyProject.OrderCore.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetWMS_OrderAllocationsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
				
		//// 自定义编码结束
    }
}
