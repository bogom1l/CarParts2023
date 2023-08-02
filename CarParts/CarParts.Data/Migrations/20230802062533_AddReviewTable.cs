using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class AddReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Cars_CarId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_CarId",
                table: "Reviews",
                newName: "IX_Reviews_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "UserId", "CarId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b17a6c8-bdd0-412b-a793-9e729e74bc2a", "AQAAAAEAACcQAAAAEK8bMgYmumJMLq+s1N2T44B/mNRbQ1pitnyyjpyWcaSG8M/Qys6qQT6mbz0x27GITg==", "3c42896c-aaf5-4e81-a3f8-5a32f1c6c577" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Cars_CarId",
                table: "Reviews",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Cars_CarId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CarId",
                table: "Review",
                newName: "IX_Review_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                columns: new[] { "UserId", "CarId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64aeec9d-c565-4ff6-bd6b-1a2e3f1aa827", "AQAAAAEAACcQAAAAECfhXAtOT+9nnxRz5dlw0MNkFm1y8qvDrw34wMJj7//E9xS42Id0jdBVZZWjY31Rhw==", "837e193a-8fac-44ae-9563-4a7ed2d04d89" });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Cars_CarId",
                table: "Review",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
