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

        public static void SeedBattalions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battalion>().HasData(new[]
            {
                new Battalion() {Id = 1, Name = "Dzhokhar Dudayev Battalion"},
                new Battalion() {Id = 2, Name = "Skala Battalion"},
                new Battalion() {Id = 3, Name = "Sheikh Mansur Battalion"},
                new Battalion() {Id = 4, Name = "Chechen volunteers on the side of Ukraine"}
            });
        }
    }
}