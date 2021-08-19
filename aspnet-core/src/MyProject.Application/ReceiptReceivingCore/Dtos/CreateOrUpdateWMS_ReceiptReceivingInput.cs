

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.ReceiptReceivingCore;

namespace MyProject.ReceiptReceivingCore.Dtos
{
    public class CreateOrUpdateWMS_ReceiptReceivingInput
    {
        [Required]
        public WMS_ReceiptReceivingEditDto WMS_ReceiptReceiving { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}