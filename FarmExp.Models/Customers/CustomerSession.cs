using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    [Serializable]
   public class CustomerSession:BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime DateExpired { get; set; }
        public string DataKey { get; set; }
    }
}
