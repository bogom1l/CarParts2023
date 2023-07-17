namespace CarParts.GlobalConstants
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
            public const int CarColorMaxLength = 50;

            public const int CarFuelTypeMinLength = 2;
            public const int CarFuelTypeMaxLength = 30;

            public const int CarTransmissionMinLength = 2;
            public const int CarTransmissionMaxLength = 30;

            public const int CarCategoryMinLength = 2;
            public const int CarCategoryMaxLength = 40;

            public const int CarDescriptionMinLength = 2;
            public const int CarDescriptionMaxLength = 300;

            public const double CarPriceMinValue = 0.01;
            public const double CarPriceMaxValue = 999_999;

            public const double CarEngineSizeMinValue = 500;
            public const double CarEngineSizeMaxValue = 9000;

            public const int CarWeightMinValue = 500;
            public const int CarWeightMaxValue = 9000;

            public const int CarTopSpeedMinValue = 60;
            public const int CarTopSpeedMaxValue = 350;
    
            public const int CarAccelerationMinValue = 1;
            public const int CarAccelerationMaxValue = 20;

            public const int CarHorsepowerMinValue = 20;
            public const int CarHorsepowerMaxValue = 2000;

            public const int CarTorqueMinValue = 50;
            public const int CarTorqueMaxValue = 2000;

            public const int CarFuelConsumptionMinValue = 2;
            public const int CarFuelConsumptionMaxValue = 50;

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

        public static class CarProperties
        {
            public const int FuelTypeMaxLength = 30;
            public const int FuelTypeMinLength = 2;

            public const int TransmissionMaxLength = 30;
            public const int TransmissionMinLength = 2;

            public const int CategoryMaxLength = 40;
            public const int CategoryMinLength = 2;
        }

    }
}
