namespace CarParts.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using CarParts.Data.Models;


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

            
            // Seed with some data
            SeedData(builder);

            // Call the base method
            base.OnModelCreating(builder);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {

            //FuelTypes
            modelBuilder
                .Entity<FuelType>()
                .HasData(new FuelType()
                    {
                        Id = 1,
                        Name = "Diesel"
                    },
                    new FuelType()
                    {
                        Id = 2,
                        Name = "Petrol"
                    },
                    new FuelType()
                    {
                        Id = 3,
                        Name = "Electric"
                    },
                    new FuelType()
                    {
                        Id = 4,
                        Name = "Hybrid"
                    });

            //Transmissions
            modelBuilder
                .Entity<Transmission>()
                .HasData(new Transmission()
                    {
                        Id = 1,
                        Name = "Automatic"
                    },
                    new FuelType()
                    {
                        Id = 2,
                        Name = "Manual"
                    });

            //Categories
            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                    {
                        Id = 1,
                        Name = "Sedan"
                    },
                    new FuelType()
                    {
                        Id = 2,
                        Name = "Coupe"
                    },
                    new FuelType()
                    {
                        Id = 3,
                        Name = "Hatchback"
                    },
                    new FuelType()
                    {
                        Id = 4,
                        Name = "SUV"
                    },
                    new FuelType()
                    {
                        Id = 5,
                        Name = "Wagon"
                    },
                    new FuelType()
                    {
                        Id = 6,
                        Name = "Cabrio"
                    },
                    new FuelType()
                    {
                        Id = 7,
                        Name = "Pickup Truck"
                    },
                    new FuelType()
                    {
                        Id = 8,
                        Name = "Minivan"
                    },
                    new FuelType()
                    {
                        Id = 9,
                        Name = "Jeep"
                    });

            //add OnDelete Restrict to Cars Category Id

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            //add OnDelete Restrict to Cars FuelTypeId

            modelBuilder.Entity<Car>()
                .HasOne(c => c.FuelType)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            //add OnDelete Restrict to Cars TransmissionId

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Transmission)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            /*

           // Example Car data
           modelBuilder.Entity<Car>().HasData(
               new Car
               {
                   CarId = 1,
                   Make = "Ford",
                   Model = "Mustang",
                   Year = 2021,
                   UserId = "41b333fe-2257-47d9-8e04-f43a0a645bf7",
                   Description = "This is a car",
                   //Wheels = "4",
                   Price = 10000,
                   Color = "Red",
                   EngineSize = 2.5,
                   FuelTypeId = 1,
                   TransmissionId = 1,
                   CategoryId = 1,
                   Weight = 123,
                   TopSpeed = 123,
                   Acceleration = 123,
                   Horsepower = 123,
                   Torque = 123,
                   FuelConsumption = 123,
                   //Emission = 123
               },
               new Car
               {
                   CarId = 2, Make = "Toyota", Model = "Camry", Year = 2018,
                   UserId = "41b333fe-2257-47d9-8e04-f43a0a645bf7",
                   Description = "This is a car2",
                   Price = 444,
                   Color = "Red",
                   EngineSize = 444,
                   FuelTypeId = 2,
                   TransmissionId = 2,
                   CategoryId = 2,
                   Weight = 444,
                   TopSpeed = 14423,
                   Acceleration = 4443,
                   Horsepower = 443,
                   Torque = 43,
                   FuelConsumption = 4123,
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
                   PartId = 1, Name = "Engine", Description = "V8 Engine", Price = 5000, CategoryId = 1,
                   UserId = "41b333fe-2257-47d9-8e04-f43a0a645bf7"
               },
               new Part
               {
                   PartId = 2, Name = "Suspension", Description = "Front Suspension", Price = 1000, CategoryId = 2,
                   UserId = "41b333fe-2257-47d9-8e04-f43a0a645bf7"
               },
               new Part
               {
                   PartId = 3, Name = "Brakes", Description = "Front Brakes", Price = 500, CategoryId = 3,
                   UserId = "41b333fe-2257-47d9-8e04-f43a0a645bf7"
               }
               // Add more part data as needed
           );

          
           */
            //seed PartUser data
            //modelBuilder.Entity<PartUser>().HasData(
            //    new PartUser { PartId = 1, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" },
            //    new PartUser { PartId = 2, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" }
            //);

            ////seed CarUser data
            //modelBuilder.Entity<CarUser>().HasData(
            //    new CarUser { CarId = 1, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" },
            //    new CarUser { CarId = 2, UserId = "845cb430-7df3-4865-beaf-7fc07799f99c" }
            //);

            

        }

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;

        public DbSet<PartCategory> PartCategories { get; set; } = null!;

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        public DbSet<FuelType> FuelTypes { get; set; } = null!;

        public DbSet<Transmission> Transmissions { get; set; } = null!;
        
        public DbSet<Category> Categories { get; set; } = null!;



        //public DbSet<PartUser> PartUsers { get; set; } = null!;

        //public DbSet<CarUser> CarUsers { get; set; } = null!;
    }
}