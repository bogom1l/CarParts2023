using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class FinalGOODseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f30ef96-7aae-4114-8316-7cc3d00fcd17", "AQAAAAEAACcQAAAAEKSpPwljxUJ4nRiI8LuSbwc4EbT8z8xCRDRriTq4vTNjhAN7Q4T2IgS8uSOyOPWZ/Q==", "c9fdb94a-f782-4e76-85b7-8fbfd0d445e4" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 228,
                column: "DealerId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 119,
                column: "DealerId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 120,
                column: "DealerId",
                value: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "813e37c3-7a4d-4672-9a86-a94cc10489f1", "AQAAAAEAACcQAAAAEPSp7OWRpF1gbI9jfMl/v7FiKDEUdu4aIBrTnVnnxdaXBFc/vmgI8O0dhMraW/fLyw==", "419676d4-bb39-4385-80c1-fd0593a685df" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 228,
                column: "DealerId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 119,
                column: "DealerId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 120,
                column: "DealerId",
                value: 18);
        }
    }
}
