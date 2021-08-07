

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.ASNCore;

namespace MyProject.ASNCore.Dtos
{
    public class CreateOrUpdateWMS_ASNInput
    {
        [Required]
        public WMS_ASNEditDto WMS_ASN { get; set; }

        //// custom codes

        [Required]
        public List<WMS_ASNDetailEditDto> WMS_ASNDetails { get; set; }

        //// custom codes end
    }
}