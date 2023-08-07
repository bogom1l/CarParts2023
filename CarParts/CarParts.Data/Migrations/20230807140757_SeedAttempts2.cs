using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SeedAttempts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df571915-1637-4588-82e2-12da7e22f453", "AQAAAAEAACcQAAAAEAi1nGlIcLCN5T18v+uNwfzfdmi+WYNcEBPlbxi1k7cm3hWfve0NlqocmTYH8HvXsg==", "63684d46-8935-40e6-96c7-c5546453a6b8" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CategoryId", "Color", "DealerId", "Description", "EngineSize", "FuelConsumption", "FuelTypeId", "Horsepower", "ImageUrl", "Make", "Model", "Price", "RentPrice", "RentalEndDate", "RentalStartDate", "RenterId", "TopSpeed", "Torque", "TransmissionId", "Weight", "Year" },
                values: new object[] { 179, 12.9, 3, "black", 14, "ToAddDescription", 1896.0, 6.5, 1, 90.0, "https://www.auto-data.net/images/f118/Volkswagen-Golf-V.jpg", "VW", "Golf 5", 6200.0, 40.0, null, null, null, 176.0, 210.0, 1, 1285.0, 2004 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 179);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20a0221c-ef05-4e52-a2ad-1061ffb8001b", "AQAAAAEAACcQAAAAECCY5WCr8JjaZmp2uDl7iX+lbzuHO0G7rcc9A1MqV1YvmFGGvKsEnSDJ9sTCIpv7rw==", "0fed9890-b286-405a-b27a-b0a302139f51" });
        }
    }
}
