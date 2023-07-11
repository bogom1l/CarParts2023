using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class SecondSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 1, "V8 Engine", "Engine", 5000.0 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 4, 1, 2, "Front Suspension", "Suspension", 1000.0 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 5, 1, 3, "Front Brakes", "Brakes", 500.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 3, "Front Brakes", "Brakes", 500.0 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 1, 1, 1, "V8 Engine", "Engine", 5000.0 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, 1, 2, "Front Suspension", "Suspension", 1000.0 });
        }
    }
}
