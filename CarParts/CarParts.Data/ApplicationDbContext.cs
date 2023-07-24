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

            builder.Entity<UserFavoritePart>()
                .HasKey(ufp => new { ufp.UserId, ufp.PartId });

            builder.Entity<UserFavoriteCar>()
                .HasKey(ufc => new { ufc.UserId, ufc.CarId});

            // Seed with some data
            SeedData(builder);

            // Call the base method
            base.OnModelCreating(builder);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {

            //FuelTypes
            modelBuilder
                .Entity<CarFuelType>()
                .HasData(
                    new CarFuelType() { Id = 1, Name = "Diesel" },
                    new CarFuelType() { Id = 2, Name = "Petrol" },
                    new CarFuelType() { Id = 3, Name = "Electric" },
                    new CarFuelType() { Id = 4, Name = "Hybrid" });

            //Transmissions
            modelBuilder
                .Entity<CarTransmission>()
                .HasData(
                    new CarTransmission() { Id = 1, Name = "Automatic" },
                    new CarTransmission() { Id = 2, Name = "Manual" });

            //Categories
            modelBuilder
                .Entity<CarCategory>()
                .HasData(
                    new CarCategory() { Id = 1, Name = "Sedan" },
                    new CarCategory() { Id = 2, Name = "Coupe" },
                    new CarCategory() { Id = 3, Name = "Hatchback" },
                    new CarCategory() { Id = 4, Name = "SUV" },
                    new CarCategory() { Id = 5, Name = "Wagon" },
                    new CarCategory() { Id = 6, Name = "Cabrio" },
                    new CarCategory() { Id = 7, Name = "Pickup Truck" },
                    new CarCategory() { Id = 8, Name = "Minivan" },
                    new CarCategory() { Id = 9, Name = "Jeep" });

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

            modelBuilder
                .Entity<PartCategory>()
                .HasData(
                    new PartCategory { CategoryId = 1, Name = "Engine" },
                    new PartCategory { CategoryId = 2, Name = "Transmission" },
                    new PartCategory { CategoryId = 3, Name = "Brakes" },
                    new PartCategory { CategoryId = 4, Name = "Suspension" },
                    new PartCategory { CategoryId = 5, Name = "Interior" },
                    new PartCategory { CategoryId = 6, Name = "Exterior" },
                    new PartCategory { CategoryId = 7, Name = "Electrical" });
            

        }


        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarFuelType> FuelTypes { get; set; } = null!;
        public DbSet<CarTransmission> Transmissions { get; set; } = null!;
        public DbSet<CarCategory> Categories { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<PartCategory> PartCategories { get; set; } = null!;


        public DbSet<UserFavoritePart> UsersFavoriteParts { get; set; } = null!;

        public DbSet<UserFavoriteCar> UsersFavoriteCars { get; set; } = null!;

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        //public DbSet<PartUser> PartUsers { get; set; } = null!;
    }
}