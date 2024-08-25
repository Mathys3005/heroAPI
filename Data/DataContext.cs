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
        public DbSet<HeroPower> HeroPowers { get; set; }

        public DbSet<School> School { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations entre les entités

            // Relation entre Hero et HeroPower
            modelBuilder.Entity<HeroPower>()
                .HasKey(hp => new { hp.HeroId, hp.PowerId }); // Clé composite
            
            modelBuilder.Entity<HeroPower>()
                    .HasOne<Hero>(hp => hp.Hero)
                    .WithMany(h => h.HeroPowers)
                    .HasForeignKey(hp => hp.HeroId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HeroPower>()
            .HasOne<Power>(hp => hp.Power)
            .WithMany(p => p.HeroPowers)
            .HasForeignKey(hp => hp.PowerId)
            .OnDelete(DeleteBehavior.Restrict);

            // Configuration des autres relations

            modelBuilder.Entity<Hero>()
                .HasOne(h => h.School)
                .WithMany(s => s.Students)
                .HasForeignKey(h => h.SchoolId);
        }
    }
}
