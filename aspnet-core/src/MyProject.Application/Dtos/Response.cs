﻿using MyProject.CommonCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Dtos
{


    public   class Response
    {
        public   StatusCode Code { get; set; }
        public   string Msg { get; set; }

    }

    public   class Response<T>
    {
        public   StatusCode Code { get; set; }

        public   string Msg { get; set; }

        public   T Data { get; set; }

    }



}
