using EfCore.Domain.Base;

namespace EfCore.Domain
{
    public class UserRole : EntityBase
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}