using EfCore.Domain;
using EfCore.Domain.Base;

namespace EfCore.Domain
{
    public class UserDetails : EntityBase
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}