using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    [Serializable]
    public class City:BaseEntity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityNameKey { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public string ZipPostCode { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
