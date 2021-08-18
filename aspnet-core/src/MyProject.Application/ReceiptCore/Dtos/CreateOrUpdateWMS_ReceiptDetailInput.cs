

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.ReceiptCore;

namespace MyProject.ReceiptCore.Dtos
{
    public class CreateOrUpdateWMS_ReceiptDetailInput
    {
        [Required]
        public WMS_ReceiptDetailEditDto WMS_ReceiptDetail { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}