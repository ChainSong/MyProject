

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.ASNCode;

namespace MyProject.ASNCode.Dtos
{
    public class CreateOrUpdateWMS_ASNDetailInput
    {
        [Required]
        public WMS_ASNDetailEditDto WMS_ASNDetail { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}