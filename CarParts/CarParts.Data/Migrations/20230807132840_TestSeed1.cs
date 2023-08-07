using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class TestSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20a0221c-ef05-4e52-a2ad-1061ffb8001b", "AQAAAAEAACcQAAAAECCY5WCr8JjaZmp2uDl7iX+lbzuHO0G7rcc9A1MqV1YvmFGGvKsEnSDJ9sTCIpv7rw==", "0fed9890-b286-405a-b27a-b0a302139f51" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CategoryId", "Color", "DealerId", "Description", "EngineSize", "FuelConsumption", "FuelTypeId", "Horsepower", "ImageUrl", "Make", "Model", "Price", "RentPrice", "RentalEndDate", "RentalStartDate", "RenterId", "TopSpeed", "Torque", "TransmissionId", "Weight", "Year" },
                values: new object[] { 178, 4.9000000000000004, 1, "Black", 14, "ToAdd", 2999.0, 0.69999999999999996, 4, 365.0, "https://www.auto-data.net/images/f94/Mercedes-Benz-S-class-W223.jpg", "Mercedes-Benz", "S-Class (W223)", 175000.0, 700.0, null, null, null, 250.0, 500.0, 1, 2345.0, 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 178);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92528687-4502-431b-8ed1-45c7eaacc3af", "AQAAAAEAACcQAAAAEO3+w1/biDQwPXcfawjHgb44We3g5a9Kw2IXldYllka8rLferif8H2ctlv+ncfURPg==", "b08a6d69-5ee8-438a-889b-a2c83a534895" });
        }
    }
}
