

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.InventoryCore;

namespace MyProject.InventoryCore.Dtos
{
    public class CreateOrUpdateWMS_InventoryInput
    {
        [Required]
        public WMS_InventoryEditDto WMS_Inventory { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}