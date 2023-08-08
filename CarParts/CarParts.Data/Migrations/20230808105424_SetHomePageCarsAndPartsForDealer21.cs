using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SetHomePageCarsAndPartsForDealer21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "asd4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65663d8a-4f12-4885-a085-f584d7caaeb2", "AQAAAAEAACcQAAAAEJZ1piaLVOcROEbWWKH3jauLfCvMpynF9c/r2tf/DEZ6vK6QLectj9uqvz52WhGBAg==", "383c5dc4-36cf-47db-935c-4473165b31c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1b85c76-3b33-4c3f-bd75-9f2d10671f07", "AQAAAAEAACcQAAAAEAWqWNjBbMeFQeDf+gMv2Dboi1Qa+gxmvfuWQCLhCaSvaf5OFsO3MfwXj5ZOCyC+cA==", "a3120f3a-32c5-4a24-82cb-9fd4177122f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "qwe4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41354710-12a8-45ff-9a06-762264147a8a", "AQAAAAEAACcQAAAAEEKF3RyEDx1yg37gMFtiOnb82qqbcYIbSgBksyWd/1/etypATKHHfddvKQVLBgpWAg==", "13310e84-5655-40a1-8cbb-cc726245c45d" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 227,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 228,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 229,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 118,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 119,
                column: "DealerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 120,
                column: "DealerId",
                value: 21);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "asd4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1083c1c4-395e-4dd5-ab4d-bd1119e502c1", "AQAAAAEAACcQAAAAEGtovon5AI5yX42fTl/YXZSoPQdw7mwrdP8Bk20HQiauKMQpimCIEJfEytevCLlYZQ==", "1522a40b-631b-412b-be79-8eda546beaba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7985cb2e-4eb1-4b16-9c83-f75d0edca9c7", "AQAAAAEAACcQAAAAEM32Jd9IyNpj/jKj8DVnwaUjEk3k9Ve/nniEtiv3xeU/FNLS3RXU6t8aVPOGWicKkA==", "68250df7-4a0b-4286-9add-22e1e0593bf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "qwe4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86cd8cf6-55fe-4b0c-9413-062cb601c50c", "AQAAAAEAACcQAAAAEAqeNY/lgmYxcv/T4YETivmHAI3oZdrWhW7DqiMikrMWV4sNR5oonfpHG+mUZCTRTQ==", "60c0c660-1ec5-42d3-bde1-e9a7e47de164" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 227,
                column: "DealerId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 228,
                column: "DealerId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 229,
                column: "DealerId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 118,
                column: "DealerId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 119,
                column: "DealerId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 120,
                column: "DealerId",
                value: 20);
        }
    }
}
