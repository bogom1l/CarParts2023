using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class ChangedPartClassToHaveIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Parts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ApplicationUserId",
                table: "Parts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_AspNetUsers_ApplicationUserId",
                table: "Parts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_AspNetUsers_ApplicationUserId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ApplicationUserId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Parts");
        }
    }
}
