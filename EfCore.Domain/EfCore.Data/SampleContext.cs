using System.Security.Cryptography.X509Certificates;
using EfCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<MyUser> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserDetails> UserProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entry =>
            {
                entry.HasKey(x => x.Id);
                entry.HasMany(x => x.UserRoles).WithOne(ur => ur.User).HasPrincipalKey(x => x.Id);
            });

            modelBuilder.Entity<Role>(entry =>
            {
                entry.HasKey(x => x.Id);
                entry.HasMany(x => x.UserRoles).WithOne(ur => ur.Role).HasPrincipalKey(x => x.Id);
            });

            modelBuilder.Entity<MyUser>(entry =>
            {
                entry.HasBaseType<User>();
            });

            modelBuilder.Entity<UserDetails>(entry => { entry.HasKey(x => x.Id); });
            modelBuilder.Entity<ExtendedUserDetails>(entry => entry.HasBaseType<UserDetails>());
        }
    }
}