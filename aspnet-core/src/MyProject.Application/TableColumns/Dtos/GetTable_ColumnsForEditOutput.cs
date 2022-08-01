
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

        public Table_ColumnsEditDto Table_Columns { get; set; }
        public List<Table_ColumnsEditDto> Table_Columnss { get; set; }

		//// custom codes		


		//// custom codes end
	}
}