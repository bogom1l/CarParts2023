using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "DescriptionId", "UserId" },
                values: new object[] { 12, 12, "42f08d29-7999-43f6-8b3a-012cd6928be5" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "DescriptionId", "UserId" },
                values: new object[] { 13, 13, "42f08d29-7999-43f6-8b3a-012cd6928be5" });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescriptionId", "Acceleration", "CarId", "Category", "Color", "Emission", "EngineSize", "FuelConsumption", "FuelType", "Horsepower", "Make", "Model", "Price", "SafetyFeatures", "TopSpeed", "Torque", "Transmission", "Weight", "Wheels", "Year" },
                values: new object[] { 12, 5.0, 12, "sedan", "red", 3.0, 2000.0, 8.0, "benzin", 197.0, "make1", "model1", 5000.0, "blablabla", 200.0, 213.0, "ruchna", 2000.0, "4 zimni gumi", 2001 });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescriptionId", "Acceleration", "CarId", "Category", "Color", "Emission", "EngineSize", "FuelConsumption", "FuelType", "Horsepower", "Make", "Model", "Price", "SafetyFeatures", "TopSpeed", "Torque", "Transmission", "Weight", "Wheels", "Year" },
                values: new object[] { 13, 6.0, 13, "coupe", "green", 2.0, 2002.0, 6.0, "dizel", 222.0, "make2", "model2", 6000.0, "ima sedalki", 300.0, 333.0, "avtomat", 3000.0, "4 letni gumi", 2002 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 13);
        }
    }
}
