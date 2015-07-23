using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    /// <summary>
    /// 信息提示类型
    /// </summary>
    public enum MessageState
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Ok = 0,
        /// <summary>
        /// 页面跳转
        /// </summary>
        [Description("页面跳转")]
        redirect = 10,

        /// <summary>
        /// 需要登陆
        /// </summary>
        [Description("需要登录")]
        BaseNeedLogin = 100,
        /// <summary>
        /// 无效的请求
        /// </summary>
        [Description("请求无效")]
        BaseInvalidRequest = 101,

        /// <summary>
        /// 业务错误
        /// </summary>
        [Description("业务错误")]
        BaseBusinessError = 102,

        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        BaseSystemError = 103,

        /// <summary>
        /// 购物车为空
        /// </summary>
        [Description("购物车为空")]
        BaseCartIsNull = 104,

        /// <summary>
        /// 权限不足
        /// </summary>
        [Description("权限不足")]
        PrivilegeForbidden = 200
    }
}
