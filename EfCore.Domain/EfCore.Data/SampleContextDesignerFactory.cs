using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCore.Data
{
    public class SampleContextDesignTimeFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        public SampleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite(new SqliteConnection("datasource =:memory"));
            return new SampleContext(optionsBuilder.Options);
        }
    }
}