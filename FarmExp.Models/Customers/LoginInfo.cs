using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    public class LoginInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthCode { get; set; }
        public string CustomerIp { get; set; }
        public string CustomerSign { get; set;}
        public int Browser { get; set; }
    }
}
