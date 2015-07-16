using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    [Serializable]
   public class CustomerCertSession:BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int AuthType { get; set; }
        public string DataKey { get; set; }
        public string DateExpired { get; set; }
    }
}
