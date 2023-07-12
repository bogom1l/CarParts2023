namespace CarParts2023.GlobalConstants
{
    public static class GlobalConstants
    {
        public static class Car
        {
            public const int CarMakeMinLength = 2;
            public const int CarMakeMaxLength = 50;

            public const int CarModelMinLength = 2;
            public const int CarModelMaxLength = 50;

            public const int CarYearMinValue = 1900;
            public const int CarYearMaxValue = 2024;

            public const int CarColorMinLength = 2;
            public const int CarColorMaxLength = 30;

            public const int CarFuelTypeMinLength = 2;
            public const int CarFuelTypeMaxLength = 30;

            public const int CarTransmissionMinLength = 2;
            public const int CarTransmissionMaxLength = 20;

            public const int CarCategoryMinLength = 2;
            public const int CarCategoryMaxLength = 20;

            public const int CarWheelsMinLength = 2;
            public const int CarWheelsMaxLength = 40;
        }

        public static class Part
        {
            public const int PartNameMinLength = 1;
            public const int PartNameMaxLength = 50;

            public const int PartDescriptionMinLength = 2;
            public const int PartDescriptionMaxLength = 300;

            public const double PartPriceMinValue = 0.01;
            public const double PartPriceMaxValue = 10_000;
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 2;
            public const int CategoryNameMaxLength = 50;
        }
    }
}
