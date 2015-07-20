using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    [Serializable]
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Customer : BaseEntity
    {
      [Description("用户ID")]
       public Guid CustomerId { get; set; }
      [Description("用户账号")]
       public string UserName { get; set; }
       [Description("用户密码")]
       public string Password { get; set; }
       [Description("手机号码")]
       public string Phone { get; set; }
       [Description("是否验证手机")]
       public bool PhoneValidate { get; set; }
       [Description("是否验证邮箱")]      
       public bool EmailValidate { get; set; }
       public virtual Address BilingAddress { get; set; }
       public virtual Address ContactAddress { get; set; }
       public virtual ICollection<Role> Roles { get; set; }
       public virtual Address DefaultAddress { get; set; }
       public virtual ICollection<Address> ShippingAddress { get; set; }
       public virtual ICollection<CustomerLog> CustomerLog { get; set; }
   }
}
