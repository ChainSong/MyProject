using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.CommonCore
{
    public enum StatusCode
    {
        /// <summary>
        /// 失败
        /// </summary>
        error = -1,
        /// <summary>
        /// 成功
        /// </summary>
        success = 1,

        /// <summary>
        /// 警告
        /// </summary>
        warning = 5,

        /// <summary>
        /// 提示
        /// </summary>
        info = 10,

    }
}
