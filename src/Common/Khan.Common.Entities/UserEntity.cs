using System;

namespace Khan.Common.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public Guid RoleId { get; set; }
        public RoleEntity Role { get; set; }

        public UserEntity()
        {
            this.UserId = Guid.NewGuid();
        }
    }
}
