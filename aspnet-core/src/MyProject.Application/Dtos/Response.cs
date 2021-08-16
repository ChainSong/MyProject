using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Dtos
{


    public class Response
    {
        public int Code { get; set; }

    }

    public class Response<T>
    {
        public int Code { get; set; }

        public T Data { get; set; }

    }



}
