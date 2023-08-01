namespace CarParts.Data
{
    using Common;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    using static Common.GlobalConstants.AdminUser;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarFuelType> FuelTypes { get; set; } = null!;
        public DbSet<CarTransmission> Transmissions { get; set; } = null!;
        public DbSet<CarCategory> Categories { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<PartCategory> PartCategories { get; set; } = null!;

        public DbSet<UserFavoritePart> UsersFavoriteParts { get; set; } = null!;
        public DbSet<UserFavoriteCar> UsersFavoriteCars { get; set; } = null!;

        public DbSet<Dealer> Dealers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            //TODO: da iznesa seedwaneto w drug class
            //TODO: da iznesa seedwaneto w drug class
            //TODO: da iznesa seedwaneto w drug class

            //seed first administrator
            SeedAdministrator(builder);

            //-----------------------------------------------------
            builder.Entity<UserFavoritePart>()
                .HasKey(ufp => new { ufp.UserId, ufp.PartId });

            builder.Entity<UserFavoriteCar>()
                .HasKey(ufc => new { ufc.UserId, ufc.CarId });

            SeedData(builder);

            base.OnModelCreating(builder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CarFuelType>()
                .HasData(
                    new CarFuelType { Id = 1, Name = "Diesel" },
                    new CarFuelType { Id = 2, Name = "Petrol" },
                    new CarFuelType { Id = 3, Name = "Electric" },
                    new CarFuelType { Id = 4, Name = "Hybrid" });

            modelBuilder
                .Entity<CarTransmission>()
                .HasData(
                    new CarTransmission { Id = 1, Name = "Automatic" },
                    new CarTransmission { Id = 2, Name = "Manual" });

            modelBuilder
                .Entity<CarCategory>()
                .HasData(
                    new CarCategory { Id = 1, Name = "Sedan" },
                    new CarCategory { Id = 2, Name = "Coupe" },
                    new CarCategory { Id = 3, Name = "Hatchback" },
                    new CarCategory { Id = 4, Name = "SUV" },
                    new CarCategory { Id = 5, Name = "Wagon" },
                    new CarCategory { Id = 6, Name = "Cabrio" },
                    new CarCategory { Id = 7, Name = "Pickup Truck" },
                    new CarCategory { Id = 8, Name = "Minivan" },
                    new CarCategory { Id = 9, Name = "Jeep" });

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.FuelType)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Transmission)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

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

        private void SeedAdministrator(ModelBuilder modelBuilder)
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                FirstName = AdminFirstName,
                LastName = AdminLastName,
                Balance = 9_999_999,
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, AdminPassword);

            modelBuilder
                .Entity<ApplicationUser>()
                .HasData(adminUser);

            modelBuilder
                .Entity<Dealer>()
                .HasData(
                    new Dealer { 
                        Id = 14, //careful, what is my last
                        Address = AdminAddress,
                        UserId = adminUser.Id
                    });

        }
    }
}
