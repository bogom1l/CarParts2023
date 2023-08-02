using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class ReviewRatingIntToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Reviews",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e8b2520-9284-4e6f-aef1-eae16b9bb084", "AQAAAAEAACcQAAAAEJirY2wYmtVyC8bgFrangPj9VEjyU/17e96wZ3AtfDyYErEDVBB3ycsq7Ml3K5sDUg==", "7664ff25-55d3-40ad-aa16-081129a672bf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b149dc42-a7a5-4e86-a5b4-afc513322354", "AQAAAAEAACcQAAAAEB62tEJm4yrGPu1+Fl/S2BYEP/bcgbTfPK+dt3AVX7XZAXpZgcbsF+K1TkDO5ELUog==", "af14e984-2ab6-4607-a6ef-f18caed09ab3" });
        }
    }
}
