namespace CarParts.Web.ViewModels.Part
{
    using Dealer;

    public class DetailsPartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string Category { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Owner { get; set; } = null!;

        public string PurchaserEmail { get; set; } = null!;

        public DetailsDealerViewModel DetailsDealerViewModel { get; set; } = null!;
    }
}