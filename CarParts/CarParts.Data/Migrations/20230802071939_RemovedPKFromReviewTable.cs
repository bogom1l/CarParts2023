using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class RemovedPKFromReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b149dc42-a7a5-4e86-a5b4-afc513322354", "AQAAAAEAACcQAAAAEB62tEJm4yrGPu1+Fl/S2BYEP/bcgbTfPK+dt3AVX7XZAXpZgcbsF+K1TkDO5ELUog==", "af14e984-2ab6-4607-a6ef-f18caed09ab3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b17a6c8-bdd0-412b-a793-9e729e74bc2a", "AQAAAAEAACcQAAAAEK8bMgYmumJMLq+s1N2T44B/mNRbQ1pitnyyjpyWcaSG8M/Qys6qQT6mbz0x27GITg==", "3c42896c-aaf5-4e81-a3f8-5a32f1c6c577" });
        }
    }
}
