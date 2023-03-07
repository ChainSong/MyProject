using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.CommonCore.AOP
{
    public class HttpResult : Attribute
    {
        public string url { get; set; }

    }
}
