using MyProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Interface
{

    internal interface IHub
    {
        Response Hub();
    }

    internal interface IHub<T>
    {
        Response<T> Hub(T t);
    }


    internal interface IHub<T, H>
    {
        Response<T> Hub(H h);
    }
}
