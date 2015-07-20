using System;

namespace FarmExp.Models
{
    [Serializable]
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public bool IsDeleteed { get; set; }
        public DateTime CreateOnUtc { get; set; }
        public int DisplayOrder { get; set; }
        public string ExtendField { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
  
        private Type GetUnproxiedType()
        {
            return GetType();
        }
    }
}
