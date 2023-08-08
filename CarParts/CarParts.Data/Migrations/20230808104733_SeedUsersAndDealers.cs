using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SeedUsersAndDealers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7985cb2e-4eb1-4b16-9c83-f75d0edca9c7", "AQAAAAEAACcQAAAAEM32Jd9IyNpj/jKj8DVnwaUjEk3k9Ve/nniEtiv3xeU/FNLS3RXU6t8aVPOGWicKkA==", "68250df7-4a0b-4286-9add-22e1e0593bf2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "asd4f072-ecca-43c9-ab26-c060c6f364e4", 0, 0.0, "1083c1c4-395e-4dd5-ab4d-bd1119e502c1", "johnwick@abv.bg", false, "John", "Wick", false, null, "JOHNWICK@ABV.BG", "JOHNWICK@ABV.BG", "AQAAAAEAACcQAAAAEGtovon5AI5yX42fTl/YXZSoPQdw7mwrdP8Bk20HQiauKMQpimCIEJfEytevCLlYZQ==", null, false, "1522a40b-631b-412b-be79-8eda546beaba", false, "johnwick@abv.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "qwe4f072-ecca-43c9-ab26-c060c6f364e4", 0, 0.0, "86cd8cf6-55fe-4b0c-9413-062cb601c50c", "bogi@mail.bg", false, "Bogi", "Shefa", false, null, "BOGI@MAIL.BG", "BOGI@MAIL.BG", "AQAAAAEAACcQAAAAEAqeNY/lgmYxcv/T4YETivmHAI3oZdrWhW7DqiMikrMWV4sNR5oonfpHG+mUZCTRTQ==", null, false, "60c0c660-1ec5-42d3-bde1-e9a7e47de164", false, "bogi@mail.bg" });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "Address", "UserId" },
                values: new object[] { 21, "St. St. Constantine and Elena", "qwe4f072-ecca-43c9-ab26-c060c6f364e4" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 209,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 212,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 214,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 218,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 220,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 223,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 230,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 103,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 104,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 105,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 106,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 107,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 108,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 109,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 110,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 111,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 113,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 114,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 115,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 116,
                column: "DealerId",
                value: 21);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "asd4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "qwe4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f30ef96-7aae-4114-8316-7cc3d00fcd17", "AQAAAAEAACcQAAAAEKSpPwljxUJ4nRiI8LuSbwc4EbT8z8xCRDRriTq4vTNjhAN7Q4T2IgS8uSOyOPWZ/Q==", "c9fdb94a-f782-4e76-85b7-8fbfd0d445e4" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 209,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 212,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 214,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 218,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 220,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 223,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 230,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 103,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 104,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 105,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 106,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 107,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 108,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 109,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 110,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 111,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 113,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 114,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 115,
                column: "DealerId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 116,
                column: "DealerId",
                value: 14);
        }
    }
}
