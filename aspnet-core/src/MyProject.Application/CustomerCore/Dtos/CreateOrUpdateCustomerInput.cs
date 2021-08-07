

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.CustomerCore;

namespace MyProject.CustomerCore.Dtos
{
    public class CreateOrUpdateCustomerInput
    {
        [Required]
        public CustomerEditDto Customer { get; set; }


        [Required]
        public List<CustomerDetailEditDto> CustomerDetails { get; set; }

        //// custom codes



        //// custom codes end
    }
}