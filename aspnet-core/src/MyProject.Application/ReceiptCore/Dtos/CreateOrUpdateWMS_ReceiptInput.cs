

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.ReceiptCore;

namespace MyProject.ReceiptCore.Dtos
{
    public class CreateOrUpdateWMS_ReceiptInput
    {
        [Required]
        public WMS_ReceiptEditDto WMS_Receipt { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}