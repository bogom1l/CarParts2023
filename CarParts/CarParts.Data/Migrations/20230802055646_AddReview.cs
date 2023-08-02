using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class AddReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => new { x.UserId, x.CarId });
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64aeec9d-c565-4ff6-bd6b-1a2e3f1aa827", "AQAAAAEAACcQAAAAECfhXAtOT+9nnxRz5dlw0MNkFm1y8qvDrw34wMJj7//E9xS42Id0jdBVZZWjY31Rhw==", "837e193a-8fac-44ae-9563-4a7ed2d04d89" });

            migrationBuilder.CreateIndex(
                name: "IX_Review_CarId",
                table: "Review",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9c09652-f411-4bc1-8594-49152c425764", "AQAAAAEAACcQAAAAEDB0lEYcqIwNoEN7olCfZbBq19MiNUYw8y9WdKvMlEz5jPs1pU7D7Hco0qgjcfiz5g==", "da644130-1458-4cea-bbe6-cf6e317f1a5b" });
        }
    }
}
