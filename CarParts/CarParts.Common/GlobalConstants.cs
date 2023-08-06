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
            public const int CarPriceMaxValue = 999_999;

            public const int CarEngineSizeMinValue = 10;
            public const int CarEngineSizeMaxValue = 9000;

            public const int CarWeightMinValue = 100;
            public const int CarWeightMaxValue = 9000;

            public const int CarTopSpeedMinValue = 10;
            public const int CarTopSpeedMaxValue = 350;

            public const int CarAccelerationMinValue = 0;
            public const int CarAccelerationMaxValue = 30;

            public const int CarHorsepowerMinValue = 1;
            public const int CarHorsepowerMaxValue = 3000;

            public const int CarTorqueMinValue = 1;
            public const int CarTorqueMaxValue = 3000;

            public const int CarFuelConsumptionMinValue = 0;
            public const int CarFuelConsumptionMaxValue = 50;

            public const int CarRentPriceMinValue = 20;
            public const int CarRentPriceMaxValue = 30_000;

            public const double TaxPriceForCancelingRental = 20;
            public const double TaxPriceForAdjustingRental = 10;

            public const int ComparisonListMinCount = 2;
            public const int ComparisonListMaxCount = 5;
        }

        public static class Part
        {
            public const int PartNameMinLength = 1;
            public const int PartNameMaxLength = 50;

            public const int PartDescriptionMinLength = 1;
            public const int PartDescriptionMaxLength = 3500;

            public const int PartPriceMinValue = 1;
            public const int PartPriceMaxValue = 300_000;

            public const int PartCategoryNameMinLength = 1;
            public const int PartCategoryNameMaxLength = 50;

            public const double TaxPriceForRefundingPart = 5;
        }

        public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 50;

            public const int BalanceMinValue = 0;
            public const int BalanceMaxValue = 10_000_000;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Dealer
        {
            public const int DealerAddressMinLength = 1;
            public const int DealerAddressMaxLength = 80;
        }

        public static class AdminUser
        {
            public const string AdminRoleName = "Administrator";
            public const string AdminEmail = "admin@mail.com";
            public const string AdminPassword = "admin123";
            public const string AdminFirstName = "ADMINISTRATOR";
            public const string AdminLastName = "ADMINISTRATOR";
            public const string AdminAddress = "ADMIN_ADDRESS";
            public const string AdminAreaName = "Admin";
        }

        public static class Review
        {
            public const int ReviewContentMinLength = 1;
            public const int ReviewContentMaxLength = 3000;
        }
    }
}