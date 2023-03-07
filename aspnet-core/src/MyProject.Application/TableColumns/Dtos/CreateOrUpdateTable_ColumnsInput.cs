

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.TableColumns;

namespace MyProject.TableColumns.Dtos
{
    public class CreateOrUpdateTable_ColumnsInput
    {
        [Required]
        public Table_ColumnsEditDto TableColumns { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}