using System;

namespace Khan.Common.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
