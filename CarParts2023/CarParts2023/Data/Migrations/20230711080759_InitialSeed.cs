using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "Ford", "Mustang", 2021 },
                    { 2, "Toyota", "Camry", 2018 },
                    { 3, "BMW", "3 Series", 2020 }
                });

            migrationBuilder.InsertData(
                table: "PartCategories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Engine" },
                    { 2, "Suspension" },
                    { 3, "Brakes" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 1, 1, 1, "V8 Engine", "Engine", 5000.0 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, 1, 2, "Front Suspension", "Suspension", 1000.0 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 3, 1, 3, "Front Brakes", "Brakes", 500.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
