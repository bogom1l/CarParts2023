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
            builder.Entity<CarUser>().HasKey(cu => new { cu.CarId, cu.UserId });
            builder.Entity<PartUser>().HasKey(pu => new { pu.PartId, pu.UserId });


            
            // Call the base method
            base.OnModelCreating(builder);

            // Seed with some data
            SeedData(builder);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {
            /*

                // Add example data to the tables

                // Example Car data
                modelBuilder.Entity<Car>().HasData(
                    new Car
                    {
                        CarId = 1, Make = "Ford", Model = "Mustang", Year = 2021,
                        UserId = "845cb430-7df3-4865-beaf-7fc07799f99c"
                    },
                    new Car
                    {
                        CarId = 2, Make = "Toyota", Model = "Camry", Year = 2018,
                        UserId = "845cb430-7df3-4865-beaf-7fc07799f99c"
                    },
                    new Car
                    {
                        CarId = 3, Make = "BMW", Model = "3 Series", Year = 2020,
                        UserId = "845cb430-7df3-4865-beaf-7fc07799f99c"
                    }
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
                    new Part
                    {
                        PartId = 3, Name = "Engine", Description = "V8 Engine", Price = 5000, CategoryId = 1,
                        UserId = "845cb430-7df3-4865-beaf-7fc07799f99c"
                    },
                    new Part
                    {
                        PartId = 4, Name = "Suspension", Description = "Front Suspension", Price = 1000, CategoryId = 2,

                        UserId = "845cb430-7df3-4865-beaf-7fc07799f99c"
                    },
                    new Part
                    {
                        PartId = 5, Name = "Brakes", Description = "Front Brakes", Price = 500, CategoryId = 3, 
                        UserId = "845cb430-7df3-4865-beaf-7fc07799f99c"
                    }
                    // Add more part data as needed
                );

                //seed PartUser data
                modelBuilder.Entity<PartUser>().HasData(
                    new PartUser { PartId = 3, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" },
                    new PartUser { PartId = 4, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" }
                );

                //seed CarUser data
                modelBuilder.Entity<CarUser>().HasData(
                    new CarUser { CarId = 1, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" },
                    new CarUser { CarId = 2, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" }
                );
            */

            //seed Car and Description

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarId = 12,
                    DescriptionId = 12,
                    UserId = "42f08d29-7999-43f6-8b3a-012cd6928be5"
                },
                new Car
                {
                    CarId = 13,
                    DescriptionId = 13,
                    UserId = "42f08d29-7999-43f6-8b3a-012cd6928be5"
                }
            );

            //seed Description
            modelBuilder.Entity<Description>().HasData(
                new Description
                {
                    DescriptionId = 12,
                    CarId = 12,
                    Make = "make1",
                    Model = "model1",
                    Year = 2001,
                    //Parts = null,
                    Wheels = "4 zimni gumi",
                    Price = 5000,
                    Color = "red",
                    EngineSize = 2000,
                    FuelType = "benzin",
                    Transmission = "ruchna",
                    Category = "sedan",
                    Weight = 2000,
                    TopSpeed = 200,
                    Acceleration = 5,
                    Horsepower = 197,
                    Torque = 213,
                    FuelConsumption = 8,
                    Emission = 3,
                    SafetyFeatures = "blablabla"
                },
                new Description
                {
                    DescriptionId = 13,
                    CarId = 13,
                    Make = "make2",
                    Model = "model2",
                    Year = 2002,
                    //Parts = null,
                    Wheels = "4 letni gumi",
                    Price = 6000,
                    Color = "green",
                    EngineSize = 2002,
                    FuelType = "dizel",
                    Transmission = "avtomat",
                    Category = "coupe",
                    Weight = 3000,
                    TopSpeed = 300,
                    Acceleration = 6,
                    Horsepower = 222,
                    Torque = 333,
                    FuelConsumption = 6,
                    Emission = 2,
                    SafetyFeatures = "ima sedalki"
                }
            );
        }




        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;

        public DbSet<PartCategory> PartCategories { get; set; } = null!;

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        public DbSet<PartUser> PartUsers { get; set; } = null!;

        public DbSet<CarUser> CarUsers { get; set; } = null!;

        public DbSet<Description> Descriptions { get; set; } = null!;
    }
}