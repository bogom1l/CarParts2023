namespace CarParts.Web.ViewModels.Part
{
    public class PartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string CategoryName { get; set; } = null!;

        public string Owner { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}