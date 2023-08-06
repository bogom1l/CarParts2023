using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class AddedCarComparisonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFreeForCompare",
                table: "Cars");

            migrationBuilder.CreateTable(
                name: "UsersComparisonCars",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersComparisonCars", x => new { x.UserId, x.CarId });
                    table.ForeignKey(
                        name: "FK_UsersComparisonCars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersComparisonCars_Cars_CarId",
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
                values: new object[] { "85bbc2b4-99b5-4b7e-9fcf-f140c2b65a35", "AQAAAAEAACcQAAAAEPOhBqsZQvYYXlbi8k58DwLPyEd3hC1QbWgo7VznBEqfl0QYFFmJ/Ud0dgk9etYspA==", "0fac83a1-cece-462f-8aea-85eba87a9670" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersComparisonCars_CarId",
                table: "UsersComparisonCars",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersComparisonCars");

            migrationBuilder.AddColumn<bool>(
                name: "IsFreeForCompare",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eff97a11-07d9-49f8-8d89-3c7c82ac0dd9", "AQAAAAEAACcQAAAAEN3vMbl4JVjBhlYJkNv0gylVOxRa0T+bIxgTjzOYY6IemhWcLiPHWf9FDjxOu3Nbfw==", "8a942c2b-c53b-4d0d-a209-51b8cdcff7c1" });
        }
    }
}
