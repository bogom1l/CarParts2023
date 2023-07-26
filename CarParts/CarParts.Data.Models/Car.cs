using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarParts.Common.GlobalConstants.Car;

namespace CarParts.Data.Models
{
    public class Car
    {
        [Key] public int CarId { get; set; }

        [Required]
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required] 
        public int Year { get; set; }


        [Required] 
        [MaxLength(CarDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] 
        public double Price { get; set; }

        [Required]
        [MaxLength(CarColorMaxLength)]
        public string Color { get; set; } = null!;

        [Required]
        public double EngineSize { get; set; }


        [Required]
        [ForeignKey(nameof(FuelType))]
        public int FuelTypeId { get; set; }

        public CarFuelType FuelType { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Transmission))]
        public int TransmissionId { get; set; }

        public CarTransmission Transmission { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public CarCategory Category { get; set; } = null!;
        

        [Required]
        public double Weight { get; set; }

        [Required] 
        public double TopSpeed { get; set; }

        [Required] 
        public double Acceleration { get; set; }

        [Required] 
        public double Horsepower { get; set; }

        [Required]
        public double Torque { get; set; }

        [Required]
        public double FuelConsumption { get; set; }


        public string ImageUrl { get; set; } = null!;


        public ICollection<UserFavoriteCar> UserFavoriteCars { get; set; } = new List<UserFavoriteCar>();



        public bool IsRented { get; set; } = false; //TODO?
        public double RentPrice { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }



        [ForeignKey(nameof(Renter))]
        public string RenterId { get; set; } = null!;


        [Required] 
        public ApplicationUser? Renter { get; set; } = null!; 


        [Required]
        [ForeignKey(nameof(Dealer))]
        public int DealerId { get; set; }

        [Required]
        public Dealer Dealer { get; set; } = null!;
        



    }
}

