using System;


namespace FarmExp.Models
{
    [Serializable]
    public class ArticleLog : BaseEntity
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int OperationType { get; set; }
        public int CustomerId { get; set; }
        public string CustomerIp { get; set; }
    }
}
