

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.ProductCore;

namespace MyProject.ProductCore.Dtos
{
    public class CreateOrUpdateWMS_ProductInput
    {
        [Required]
        public WMS_ProductEditDto WMS_Product { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}