using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.InventoryCore.Enumerate
{
    public enum InventoryStatusEnum
    {

        /// <summary>
        /// 库存 新增 1
        /// </summary>
        可用 = 1,

        /// <summary>
        /// 库存 占用 10
        /// </summary>
        占用 = 10,

        /// <summary>
        /// 库存 冻结 20
        /// </summary>
        冻结 = 20,

        /// <summary>
        /// 出库 99
        /// </summary>
        出库 = 99,
    }
}
