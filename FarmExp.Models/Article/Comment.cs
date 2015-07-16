using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Models
{
     [Serializable]
    public class Comment : BaseEntity
    {
         public int Id { get; set; }
         public int RelateId { get; set; }
         public int RelateType { get; set; }
         public string Title { get; set; }
         public string Keywords { get; set; }
         public string FullComment { get; set; }
         public int CommentLevel { get; set; }
         public string PictureUrl { get; set; }
         public int CustomerId { get; set; }
         public string CustomerIp { get; set; }
         public bool IsFilterWords { get; set; }
         public string FilterWords { get; set; }
         public bool IsAppend { get;set;}
         public int ParentId { get; set; }
         public int AdminId { get; set; }
         public string AdminIp { get; set; }
    }
}
