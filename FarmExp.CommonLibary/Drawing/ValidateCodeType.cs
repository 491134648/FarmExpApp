using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.CommonLibary
{
    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum ValidateCodeType
    {
        /// <summary>
        /// 纯数值
        /// </summary>
        Number=0,

        /// <summary>
        /// 数值与字母的组合
        /// </summary>
        NumberAndLetter=1,

        /// <summary>
        /// 汉字
        /// </summary>
        Hanzi=2
    }
}