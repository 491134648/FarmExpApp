using System;

namespace FarmExp.WebApp.Models
{
    public class RegViewModel:BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ValiCode { get; set; }
    }
}