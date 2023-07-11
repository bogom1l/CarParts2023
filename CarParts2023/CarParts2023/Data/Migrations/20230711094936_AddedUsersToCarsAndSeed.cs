using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class AddedUsersToCarsAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "UserId",
                value: "845cb430-7df3-4865-beaf-7fc07799f99c");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "UserId",
                value: "845cb430-7df3-4865-beaf-7fc07799f99c");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                column: "UserId",
                value: "845cb430-7df3-4865-beaf-7fc07799f99c");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cars");
        }
    }
}
