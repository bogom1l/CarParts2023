using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class AddedStatisticsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCars = table.Column<int>(type: "int", nullable: false),
                    TotalParts = table.Column<int>(type: "int", nullable: false),
                    TotalUsers = table.Column<int>(type: "int", nullable: false),
                    TotalDealers = table.Column<int>(type: "int", nullable: false),
                    TotalRents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d882520e-30f4-412a-9c7e-8a18be893b2b", "AQAAAAEAACcQAAAAELcjvMLyMRlE1ZgxA4wEtS4Ty0AOL1p4SnnRKBW+c4BhMUwRXD2X7/7cqkJDbdVrlg==", "1094d296-baf9-436a-a059-bcf3ab713011" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cb04556-9e4e-46b6-8b7c-6c0379967290", "AQAAAAEAACcQAAAAEGEJFzKJl78vc4eG1XPwyRBb4Nhur/bEqALXsl8w6fBzkGZLokF3DyOuTyjFTVELVg==", "538bf513-7281-46ec-9476-f6a1c01e9bbe" });
        }
    }
}
