using System;

namespace FarmExp.Models
{
    /// <summary>
    /// ArticleModel
    /// </summary>
    [Serializable]
    public class FarmArticle : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string KeyWords { get; set; }
        public string Short { get; set; }
        public string FullDescription { get; set; }
        public string SmallPictureId { get; set; }
        public string BigPictureId { get; set; }
        public int parent { get; set; }
        public Comment Comment { get; set; }
        public virtual ArticleLog ArticleLog { get; set; }
        public DateTime UpdateOn { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public int Hits { get; set; }
    }
}
