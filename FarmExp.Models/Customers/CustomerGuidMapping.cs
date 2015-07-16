using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
   public class CustomerGuidMapping:BaseEntity
    {
       public int Id { get; set; }
       public Guid CustomerGuid { get; set; }
       public int OpearType { get; set; }
       public int IsSuccess { get; set; }
    }
}
