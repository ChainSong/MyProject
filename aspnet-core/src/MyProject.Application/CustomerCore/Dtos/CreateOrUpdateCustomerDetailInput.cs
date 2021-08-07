

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.CustomerCore;

namespace MyProject.CustomerCore.Dtos
{
    public class CreateOrUpdateCustomerDetailInput
    {
        [Required]
        public CustomerDetailEditDto CustomerDetail { get; set; }

        //// custom codes



        //// custom codes end
    }
}