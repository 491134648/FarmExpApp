using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
   [Serializable]
    public class Address:BaseEntity
    {
       [Description("地址ID")]
        public Guid Id { get; set; }
       [Description("联系人")]
        public string FullName { get; set; }
       [Description("手机")]
        public string Phone { get; set; }
       [Description("固定电话")]
        public string FaxNumber { get; set; }
       [Description("用户ID")]
        public Guid CustomerId { get; set; }
       [Description("城市")]
        public string City { get; set; }
       [Description("国别")]
        public int CountryId { get; set; }
       [Description("省份")]
        public int StateProvinceId { get; set; }
       [Description("城市ID")]
        public int CityId { get; set; }
       [Description("县市城区ID")]
       public int DistrictId { get; set; }
       [Description("镇区ID")]
        public int TownId { get; set; }
       [Description("省市区地址")]
        public string Address1 { get; set; }
       [Description("详细地址")]
        public string Address2 { get; set; }
       [Description("用户备注")]
        public String CustomerNote { get; set; }
       
    }
}
