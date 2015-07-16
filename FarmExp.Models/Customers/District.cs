using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    [Serializable]
   public class District:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameKey { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
        public string ZipPostCode { get; set; }
        
    }
}
