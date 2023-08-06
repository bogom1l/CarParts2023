namespace CarParts.Web.ViewModels.Car.CarProperties
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Car;
    public class CarTransmissionViewModel
    {
        [Required] public int Id { get; set; }

        [Required] 
        [StringLength(CarTransmissionMaxLength, 
            MinimumLength = CarTransmissionMinLength)]
        public string Name { get; set; } = null!;
    }
}