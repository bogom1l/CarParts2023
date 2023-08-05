namespace CarParts.Web.ViewModels.Part
{
    public class PurchasePartViewModel
    {
        public int PartId { get; set; }

        public string Name { get; set; } = null!;
      
        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string? PurchaserName { get; set; }
    }
}
