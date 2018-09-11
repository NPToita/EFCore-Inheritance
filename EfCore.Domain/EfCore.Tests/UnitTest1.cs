using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EfCore.Data;
using EfCore.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfCore.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite(new SqliteConnection("data source =:memory:"));
            var dbContext = new SampleContext(optionsBuilder.Options);
            dbContext.Database.OpenConnection();
            dbContext.Database.Migrate();
            

            var roles = CreatRoles();
            dbContext.AddRange(roles);
            var users = CreateUsers();
            for (int i = 0; i < 5; i++)
            {
                var user = users.ElementAt(i);
                user.UserRoles.Add(new UserRole{ Role= roles.ElementAt(i)});
            }
            dbContext.AddRange(users);
            dbContext.SaveChanges();

            var dbUsers = dbContext.Set<User>()
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(x => x.Properties)
                .ToList();

            foreach (var user in dbUsers)
            {
                PrintUser(user);
            }
            dbContext.Database.CloseConnection();
        }

        private void PrintUser(User user)
        {
            Debug.WriteLine($"User: {user.Id}-{user.UserName}, UserType: {user.GetType().FullName}, UserDetailsType: {PrintProperties(user.Properties)}");
        }

        private string PrintProperties(ICollection<UserDetails> userProperties)
        {
            var sb = new StringBuilder();
            foreach (var item in userProperties)
            {
                sb.Append($"{item.GetType().FullName},");
            }

            return sb.ToString();
        }

        private ICollection<Role> CreatRoles()
        {
            var roles = new HashSet<Role>();
            for (int i = 0; i < 5; i++)
            {
                roles.Add(new Role
                {
                    Name = $"Role{i}",
                    Description = $"Role{i} Description"
                });
            }

            return roles;
        }

        private ICollection<User> CreateUsers()
        {
            var users = new HashSet<User>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(CreateUser(i));
            }

            return users;
        }

        private User CreateUser(int postFix)
        {
            return new MyUser
            {
                FirstName = $"FirstName{postFix}",
                LastName = $"LastName{postFix}",
                PhoneNumber = $"PhoneNumber{postFix}",
                UserName = $"UserName{postFix}",
                Properties = CreateUserDetails(postFix)
            };
        }

        private ICollection<UserDetails> CreateUserDetails(int postFix)
        {
            var random = new Random();
            var count = random.Next(5);
            var userDetails = new HashSet<UserDetails>();
            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                {
                    userDetails.Add(new UserDetails
                    {
                        Name = $"Name-{postFix}-{i}"
                    });
                }
                else
                {
                    userDetails.Add(new ExtendedUserDetails
                    {
                        Name = $"Name-{postFix}-{i}",
                        Property2 = $"Property2-{postFix}-{i}"
                    });
                }
            }

            return userDetails;
        }
    }
}
