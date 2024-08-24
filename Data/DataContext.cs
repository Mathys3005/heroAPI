using heroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace heroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=Heroes;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Hero> Hero { get; set; }
        public DbSet<Power> Power { get; set; }

        public DbSet<School> School { get; set; }
    }
}
