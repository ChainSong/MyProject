using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PreOrderCore.Enumerate
{
    public enum PreOrderStatusEnum
    {
        取消 = -1,
        新增 = 1,
        部分转出库 = 5,
        转出库 = 10,
        完成 = 99
    }
}
