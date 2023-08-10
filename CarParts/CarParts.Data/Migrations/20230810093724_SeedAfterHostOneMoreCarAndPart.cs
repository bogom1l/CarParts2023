using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SeedAfterHostOneMoreCarAndPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "asd4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d93434eb-2485-4142-806d-f43e009baeed", "AQAAAAEAACcQAAAAEAeTg23M2BmTslN2DSK+5EGbJl8hdWUD5kTwUaMSf+avQtz0gfO+dmvlqMIM9if0eQ==", "6989fc5a-67e4-40e8-84e4-f2871b60fba7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a21db937-0edc-4ec9-a208-2bdea32992d1", "AQAAAAEAACcQAAAAEDGo2pFvzNNeU8fSODyPoUZ5skVWq4RLttrFwHA8t3seZZV6oDEw9mZZjQ666TAlMQ==", "31d4bf52-2dc9-4e3a-a6ba-6afbc54fb185" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "qwe4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2501faa5-6d79-495a-88de-a9f952995d47", "AQAAAAEAACcQAAAAEK8CPqNp7W8mapKOBadURcxsS2kZpb7pDEzziZDNm46d5K7mOQOIdwo/d5wVTzTrqw==", "51568dd4-f41a-4e3f-ba06-fda5170bad0e" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CategoryId", "Color", "DealerId", "Description", "EngineSize", "FuelConsumption", "FuelTypeId", "Horsepower", "ImageUrl", "Make", "Model", "Price", "RentPrice", "RentalEndDate", "RentalStartDate", "RenterId", "TopSpeed", "Torque", "TransmissionId", "Weight", "Year" },
                values: new object[] { 232, 4.0999999999999996, 1, "Black", 14, "Descrrrrrrrr", 3333.0, 11.0, 1, 333.0, "https://carwow-uk-wp-3.imgix.net/18015-MC20BluInfinito-scaled-e1666008987698.jpg", "SeedAfterHost", "SeedAfterHost", 1234.0, 144.0, null, null, null, 123.0, 333.0, 1, 1234.0, 2011 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CategoryId", "DealerId", "Description", "ImageUrl", "Name", "Price", "PurchaserId" },
                values: new object[] { 121, 6, 14, "descrrrrr", "https://cdn.w600.comps.canstockphoto.com/exhaust-pipe-and-back-part-of-car-pictures_csp23054986.jpg", "SeedAfterHost", 250.0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 121);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "asd4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "645db5ce-6469-4630-8d87-1ed44860c1bf", "AQAAAAEAACcQAAAAEB1eNYUTxDiISn3Ufaa0CuJNFBZ8SU+OxBFC/XvcmpXI6TR1mUUMIWHk6mn0v8FmIw==", "40a1936d-1c5e-4ddb-b855-b63f78ee2021" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aba43ac-57b2-474e-b8d4-9beac0fb98cf", "AQAAAAEAACcQAAAAEGscHtN2iJyUd5RlQI7GSUb22CwHFyU3vK8BDcZlpShKkc3Z63y9nlBHYdkH0PaBxw==", "e5f8f2c1-9da7-4019-ab65-c3ead8c0e642" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "qwe4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68ddff30-f2b9-44e1-9749-efaf500240e0", "AQAAAAEAACcQAAAAELQnI7424oRPVGYRIqTNhvWFgiH3Yv6RNj0SMcu3SvCYqhpdRGDVbrDrRsNLbDxuEw==", "082379f7-c2d6-4335-a7b9-b13c2506d28a" });
        }
    }
}
