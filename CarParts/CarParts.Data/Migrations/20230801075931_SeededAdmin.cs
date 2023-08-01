using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SeededAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, 9999999.0, "630ae1ad-4199-43bb-9030-e8bf1dab47c6", "admin@mail.com", false, "ADMINISTRATOR", "ADMINISTRATOR", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEJSn91C4NxJwzg9Tzl2iQrVV2Ajh86iRHdfGzCaDet4QKKKn/DgcAWZQrONC9+nZAA==", null, false, "41d44862-cb67-43b9-92e7-d68f4368ad44", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "Address", "UserId" },
                values: new object[] { 14, "ADMIN_ADDRESS", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");
        }
    }
}
