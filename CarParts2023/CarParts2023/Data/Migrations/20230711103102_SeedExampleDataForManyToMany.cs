using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class SeedExampleDataForManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarUsers",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 1, "845cb430-7df3-4865-beaf-7fc07799f99c" },
                    { 2, "845cb430-7df3-4865-beaf-7fc07799f99c" }
                });

            migrationBuilder.InsertData(
                table: "PartUsers",
                columns: new[] { "PartId", "UserId" },
                values: new object[,]
                {
                    { 3, "845cb430-7df3-4865-beaf-7fc07799f99c" },
                    { 4, "845cb430-7df3-4865-beaf-7fc07799f99c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarUsers",
                keyColumns: new[] { "CarId", "UserId" },
                keyValues: new object[] { 1, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.DeleteData(
                table: "CarUsers",
                keyColumns: new[] { "CarId", "UserId" },
                keyValues: new object[] { 2, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.DeleteData(
                table: "PartUsers",
                keyColumns: new[] { "PartId", "UserId" },
                keyValues: new object[] { 3, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.DeleteData(
                table: "PartUsers",
                keyColumns: new[] { "PartId", "UserId" },
                keyValues: new object[] { 4, "845cb430-7df3-4865-beaf-7fc07799f99c" });
        }
    }
}
