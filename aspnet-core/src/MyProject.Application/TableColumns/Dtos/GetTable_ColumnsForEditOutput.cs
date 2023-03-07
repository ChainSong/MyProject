
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using MyProject.TableColumns;

namespace MyProject.TableColumns.Dtos
{
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetTable_ColumnsForEditOutput
    {

        public Table_ColumnsEditDto TableColumn { get; set; }
        public List<Table_ColumnsEditDto> TableColumns { get; set; }

		//// custom codes		


		//// custom codes end
	}
}