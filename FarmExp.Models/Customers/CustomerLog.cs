using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    [Serializable]
    public class CustomerLog:BaseEntity
    {
        public Guid LogId { get; set; }
        public int CustomerId { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public int OperationType { get; set; }
        public int CustomerIp { get; set; }
        /// <summary>
        /// 登陆来源
        /// </summary>
        public int LoginSign { get; set; }
        /// <summary>
        /// 浏览器或设备类型
        /// </summary>
        public int Browser { get; set; }
        /// <summary>
        ///是否登陆成功
        /// </summary>
        public bool IsSuccess { get; set;}
        /// <summary>
        ///是否第三方登陆
        /// </summary>
        public int LoginMethod { get; set; }
    }
}
