using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class AddedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Parts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                column: "UserId",
                value: "845cb430-7df3-4865-beaf-7fc07799f99c");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 4,
                column: "UserId",
                value: "845cb430-7df3-4865-beaf-7fc07799f99c");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 5,
                column: "UserId",
                value: "845cb430-7df3-4865-beaf-7fc07799f99c");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_UserId",
                table: "Parts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_AspNetUsers_UserId",
                table: "Parts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_AspNetUsers_UserId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_UserId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
