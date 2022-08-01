using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Authorization
{
    public class SOPAuthorization : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            var aaa = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var aaa = context;
        }
    }
}
