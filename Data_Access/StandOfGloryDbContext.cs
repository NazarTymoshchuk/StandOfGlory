using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Data_Access.Configurations;
using BusinessLogic.Entities;

namespace Data_Access
{
    public class StandOfGloryDbContext : IdentityDbContext
    {
        public StandOfGloryDbContext() : base() { }
        public StandOfGloryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedCities();
            modelBuilder.SeedBattalions();

            modelBuilder.ApplyConfiguration(new BattalionConfigurations());
            modelBuilder.ApplyConfiguration(new CityConfigurations());
            modelBuilder.ApplyConfiguration(new CardConfigurations());
            modelBuilder.ApplyConfiguration(new HeroConfigurations());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StandOfGlory;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }


        public DbSet<Hero> Heroes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Battalion> Battalions { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
