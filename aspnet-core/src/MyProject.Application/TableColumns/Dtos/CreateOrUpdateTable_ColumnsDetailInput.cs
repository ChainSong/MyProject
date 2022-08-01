

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.TableColumns;

namespace MyProject.TableColumns.Dtos
{
    public class CreateOrUpdateTable_ColumnsDetailInput
    {
        [Required]
        public Table_ColumnsDetailEditDto Table_ColumnsDetail { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}