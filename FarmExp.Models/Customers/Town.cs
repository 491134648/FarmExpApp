using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
    public class Town:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string USName { get; set; }
        public string NameKey { get; set; }
    }
}
