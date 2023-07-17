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
                    new Transmission()
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
                    new Category()
                    {
                        Id = 2,
                        Name = "Coupe"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Hatchback"
                    },
                    new Category()
                    {
                        Id = 4,
                        Name = "SUV"
                    },
                    new Category()
                    {
                        Id = 5,
                        Name = "Wagon"
                    },
                    new Category()
                    {
                        Id = 6,
                        Name = "Cabrio"
                    },
                    new Category()
                    {
                        Id = 7,
                        Name = "Pickup Truck"
                    },
                    new Category()
                    {
                        Id = 8,
                        Name = "Minivan"
                    },
                    new Category()
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
           // Example PartCategory data
           modelBuilder.Entity<PartCategory>().HasData(
               new PartCategory { CategoryId = 1, Name = "Engine" },
               new PartCategory { CategoryId = 2, Name = "Suspension" },
               new PartCategory { CategoryId = 3, Name = "Brakes" }
               // Add more part category data as needed
           ); */

            

        }

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;

        public DbSet<PartCategory> PartCategories { get; set; } = null!;

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;


        public DbSet<FuelType> FuelTypes { get; set; } = null!;

        public DbSet<Transmission> Transmissions { get; set; } = null!;
        
        public DbSet<Category> Categories { get; set; } = null!;


        //public DbSet<PartUser> PartUsers { get; set; } = null!;

    }
}