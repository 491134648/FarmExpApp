using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
   /// <summary>
   /// 国别地区
   /// </summary>
    [Serializable]
   public class Country:BaseEntity
    {
       [Description("国别ID")]
       public int CountryId { get; set; }
       [Description("国家地区名称")]
       public int CountryName { get; set; }
       public int CountryNameKey { get; set; }
       public object Cutrue { get; set; }
       public Object TimeIArea { get; set; }
    }
}
