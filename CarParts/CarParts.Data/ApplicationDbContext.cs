namespace CarParts.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

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

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<UserComparisonCar> UsersComparisonCars { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            DataSeeder.Seed(builder);

            builder.Entity<UserFavoritePart>()
                .HasKey(ufp => new { ufp.UserId, ufp.PartId });

            builder.Entity<UserFavoriteCar>()
                .HasKey(ufc => new { ufc.UserId, ufc.CarId });

            builder.Entity<Review>()
                .HasKey(r => new { r.UserId, r.CarId });

            builder.Entity<UserComparisonCar>()
                .HasKey(ucc => new { ucc.UserId, ucc.CarId });

            base.OnModelCreating(builder);
        }
    }
}