using System;

namespace Khan.Common.Entities
{
    public class RoleEntity : BaseEntity
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public UserEntity User { get; set; }

        public RoleEntity()
        {
            this.RoleId = Guid.NewGuid();
        }
    }
}
