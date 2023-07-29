namespace CarParts.Common
{
    public static class GlobalConstants
    {
        public static class Car
        {
            public const int CarMakeMinLength = 1;
            public const int CarMakeMaxLength = 50;

            public const int CarModelMinLength = 1;
            public const int CarModelMaxLength = 50;

            public const int CarYearMinValue = 1900;
            public const int CarYearMaxValue = 2024;

            public const int CarColorMinLength = 1;
            public const int CarColorMaxLength = 50;

            public const int CarFuelTypeMinLength = 1;
            public const int CarFuelTypeMaxLength = 30;

            public const int CarTransmissionMinLength = 1;
            public const int CarTransmissionMaxLength = 30;

            public const int CarCategoryMinLength = 1;
            public const int CarCategoryMaxLength = 40;

            public const int CarDescriptionMinLength = 1;
            public const int CarDescriptionMaxLength = 3500;

            public const int CarPriceMinValue = 1;
            public const int CarPriceMaxValue = 999999;

            public const int CarEngineSizeMinValue = 10;
            public const int CarEngineSizeMaxValue = 9000;

            public const int CarWeightMinValue = 100;
            public const int CarWeightMaxValue = 9000;

            public const int CarTopSpeedMinValue = 10;
            public const int CarTopSpeedMaxValue = 350;

            public const int CarAccelerationMinValue = 1;
            public const int CarAccelerationMaxValue = 20;

            public const int CarHorsepowerMinValue = 1;
            public const int CarHorsepowerMaxValue = 2000;

            public const int CarTorqueMinValue = 1;
            public const int CarTorqueMaxValue = 2000;

            public const int CarFuelConsumptionMinValue = 0;
            public const int CarFuelConsumptionMaxValue = 50;
        }

        public static class Part
        {
            public const int PartNameMinLength = 1;
            public const int PartNameMaxLength = 50;

            public const int PartDescriptionMinLength = 1;
            public const int PartDescriptionMaxLength = 3500;

            public const int PartPriceMinValue = 1;
            public const int PartPriceMaxValue = 100000;
        }

        public static class PartProperties
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

        public static class PhoneNumber
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Rental
        {
            public const double TaxPriceForEndingRental = 5;
        }
    }
}