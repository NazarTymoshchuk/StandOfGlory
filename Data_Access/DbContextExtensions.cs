using Microsoft.EntityFrameworkCore;
using BusinessLogic.Entities;

namespace Data_Access
{
    public static class DbContextExtensions
    {
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new[]
            {
                new City() { Id = 1, Name = "Rivne" },
                new City() { Id = 2, Name = "Lutsk" },
                new City() { Id = 3, Name = "Kyiv" },
                new City() { Id = 4, Name = "Odesa" },
            });
        }

        public static void SeedMovies(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Battalion>().HasData(new[]
            //{
                
            //});
        }
    }
}