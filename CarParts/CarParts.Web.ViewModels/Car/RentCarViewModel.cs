using System.ComponentModel.DataAnnotations;

namespace CarParts.Web.ViewModels.Car
{
    public class RentCarViewModel
    {

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string Color { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;


        public double RentPrice { get; set; }

        [Display(Name = "Rental Start Date")]
        //[DataType(DataType.Date)]
        public DateTime RentalStartDate { get; set; }

        [Display(Name = "Rental End Date")]
        //[DataType(DataType.Date)]
        public DateTime RentalEndDate { get; set; }

        public string? RenterName { get; set; }


        public int Id { get; set; }

    }
}
