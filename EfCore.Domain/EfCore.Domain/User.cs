using System.Collections;
using System.Collections.Generic;
using EfCore.Domain.Base;

namespace EfCore.Domain
{
    public class User : EntityBase
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserDetails> Properties { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}