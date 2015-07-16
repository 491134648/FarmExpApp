using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FarmExp.Models
{
    public enum ArticleOperationEnum:int
    {
        /// <summary>
        /// 读取
        /// </summary>
        [Description("读取")]
        Read=0,
        /// <summary>
        /// 创建
        /// </summary>
        [Description("创建")]
        Create=1,
        /// <summary>
        /// 编辑
        /// </summary>
        [Description("编辑")]
        Edit=2,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete=3,
        /// <summary>
        /// 发布
        /// </summary>
        [Description("发布")]
        Publish=4,
        /// <summary>
        /// 下架
        /// </summary>
        [Description("隐藏")]
        Hide=5,
        /// <summary>
        /// 评论
        /// </summary>
        [Description("评论")]
        Comment=6
    }
}
