using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class AddedPropertyIsFreeForCompareInCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFreeForCompare",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc176bfc-af43-43a5-969a-6a6154a3c059", "AQAAAAEAACcQAAAAEFgm4obzMK9PYhqgOUOvgwGN36EYhq46CZjzRMNOYdRMdNA9gEQ2NQDhlUSH33f7ww==", "92268e46-9397-47bc-9246-2ec32fd9c334" });
        }
    }
}
