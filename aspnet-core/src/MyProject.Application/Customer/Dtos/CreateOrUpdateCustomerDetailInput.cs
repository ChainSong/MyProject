

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyProject.Customers;

namespace MyProject.Customers.Dtos
{
    public class CreateOrUpdateCustomerDetailInput
    {
        [Required]
        public CustomerDetailEditDto CustomerDetail { get; set; }

        //// custom codes



        //// custom codes end
    }
}