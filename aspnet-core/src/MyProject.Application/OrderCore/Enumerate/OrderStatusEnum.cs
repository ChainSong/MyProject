using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.OrderCore.Enumerate
{
    public enum OrderStatusEnum
    {

        新增 = 1,
        已分配 = 5,
        拣货 = 10,
        复检 = 15,
        包装 = 20,
        交接 = 25,
        完成 = 99,
    }
}





