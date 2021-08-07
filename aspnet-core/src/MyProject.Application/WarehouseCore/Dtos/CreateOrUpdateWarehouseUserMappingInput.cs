

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.WarehouseCore;

namespace MyProject.WarehouseCore.Dtos
{
    public class CreateOrUpdateWarehouseUserMappingInput
    {
        [Required]
        public WarehouseUserMappingEditDto WarehouseUserMapping { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}