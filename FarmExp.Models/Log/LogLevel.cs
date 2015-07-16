using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    public enum LogLevel:int
    {
        /// <summary>
        /// 信息
        /// </summary>
        [Description("[信息]")]
        Info = 1,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("[警告]")]
        Warning = 2,
        /// <summary>
        /// 中断
        /// </summary>
        [Description("[中断]")]
        Throw = 3,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("[异常]")]
        Exception = 4,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("[错误]")]
        Error = 5,
        /// <summary>
        /// 退出
        /// </summary>
        [Description("[退出]")]
        Exit = 6
    }
}
