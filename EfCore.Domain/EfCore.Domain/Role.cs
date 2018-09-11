using System.Collections;
using System.Collections.Generic;
using EfCore.Domain.Base;

namespace EfCore.Domain
{
    public class Role : EntityBase
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}