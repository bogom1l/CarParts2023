using CarParts2023.Data.Models;

namespace CarParts2023.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Emit;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call the base method
            base.OnModelCreating(builder);

            // Seed with some data
            SeedData(builder);
        }

        
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Add example data to the tables

            // Example Car data
            modelBuilder.Entity<Car>().HasData(
                new Car { CarId = 1, Make = "Ford", Model = "Mustang", Year = 2021 },
                new Car { CarId = 2, Make = "Toyota", Model = "Camry", Year = 2018 },
                new Car { CarId = 3, Make = "BMW", Model = "3 Series", Year = 2020 }
                // Add more car data as needed
            );

             // Example PartCategory data
            modelBuilder.Entity<PartCategory>().HasData(
                new PartCategory { CategoryId = 1, Name = "Engine" },
                new PartCategory { CategoryId = 2, Name = "Suspension" },
                new PartCategory { CategoryId = 3, Name = "Brakes" }
                // Add more part category data as needed
            );

            // Example Part data
            modelBuilder.Entity<Part>().HasData(
                new Part { PartId = 3, Name = "Engine", Description = "V8 Engine", Price = 5000, CategoryId = 1, CarId = 1 },
                new Part { PartId = 4, Name = "Suspension", Description = "Front Suspension", Price = 1000, CategoryId = 2, CarId = 1 },
                new Part { PartId = 5, Name = "Brakes", Description = "Front Brakes", Price = 500, CategoryId = 3, CarId = 1 }
                // Add more part data as needed
            );

        }

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;

        public DbSet<PartCategory> PartCategories { get; set; } = null!;
    }
}