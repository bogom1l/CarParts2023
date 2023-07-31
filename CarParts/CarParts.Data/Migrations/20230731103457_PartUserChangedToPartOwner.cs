using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class PartUserChangedToPartOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_AspNetUsers_UserId",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Parts",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_UserId",
                table: "Parts",
                newName: "IX_Parts_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_AspNetUsers_OwnerId",
                table: "Parts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_AspNetUsers_OwnerId",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Parts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_OwnerId",
                table: "Parts",
                newName: "IX_Parts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_AspNetUsers_UserId",
                table: "Parts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
