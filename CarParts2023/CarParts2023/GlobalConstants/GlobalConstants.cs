﻿namespace CarParts2023.GlobalConstants
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
