
using Abp.Runtime.Validation;
using MyProject.Dtos;
using MyProject.TableColumns;
using System;

namespace MyProject.TableColumns.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetTable_ColumnsDetailsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
		/// Code
		/// </summary>
		public string CodeStr { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		public string Type { get; set; }


		public string Color { get; set; }

		/// <summary>
		/// Status
		/// </summary>
		public string Status { get; set; }



		/// <summary>
		/// Creator
		/// </summary>
		public int Creator { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime? CreationTime { get; set; }



		/// <summary>
		/// CodeN
		/// </summary>
		public int CodeInt { get; set; }



		/// <summary>
		/// Associated
		/// </summary>
		public string Associated { get; set; }

		//// custom codes end
	}
}
