using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    /// <summary>
    /// 省份Model
    /// </summary>
    [Serializable]
   public class StateProvince:BaseEntity
    {
        [Description("省份ID")]
        public int ProvinceId { get; set; }
        [Description("省份名称")]
        public string ProviceName { get; set; }
        [Description("省份简称")]
        public string ProvinceSimple { get; set; }
        /// <summary>
        /// 所属国家
        /// </summary>
        [Description("所属国家")]
        public virtual Country ParentContry { get; set; }
        [Description("下级城市")]
        public virtual ICollection<City> Citys { get; set; }
        public string ExtenfField { get; set; }

    }
}
