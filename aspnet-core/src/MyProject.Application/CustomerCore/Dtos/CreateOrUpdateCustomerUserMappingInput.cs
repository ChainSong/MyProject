

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.CustomerCore;

namespace MyProject.CustomerCore.Dtos
{
    public class CreateOrUpdateCustomerUserMappingInput
    {
        [Required]
        public CustomerUserMappingEditDto CustomerUserMapping { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}