

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.ASNCore;

namespace MyProject.ASNCore.Dtos
{
    public class CreateOrUpdateWMS_ASNDetailInput
    {
        [Required]
        public WMS_ASNDetailEditDto WMS_ASNDetail { get; set; }

        //// custom codes



        //// custom codes end
    }
}