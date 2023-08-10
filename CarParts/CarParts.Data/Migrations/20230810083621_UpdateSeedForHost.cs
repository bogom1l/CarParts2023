using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class UpdateSeedForHost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "asd4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "645db5ce-6469-4630-8d87-1ed44860c1bf", "AQAAAAEAACcQAAAAEB1eNYUTxDiISn3Ufaa0CuJNFBZ8SU+OxBFC/XvcmpXI6TR1mUUMIWHk6mn0v8FmIw==", "40a1936d-1c5e-4ddb-b855-b63f78ee2021" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aba43ac-57b2-474e-b8d4-9beac0fb98cf", "AQAAAAEAACcQAAAAEGscHtN2iJyUd5RlQI7GSUb22CwHFyU3vK8BDcZlpShKkc3Z63y9nlBHYdkH0PaBxw==", "e5f8f2c1-9da7-4019-ab65-c3ead8c0e642" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "qwe4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68ddff30-f2b9-44e1-9749-efaf500240e0", "AQAAAAEAACcQAAAAELQnI7424oRPVGYRIqTNhvWFgiH3Yv6RNj0SMcu3SvCYqhpdRGDVbrDrRsNLbDxuEw==", "082379f7-c2d6-4335-a7b9-b13c2506d28a" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 227,
                column: "ImageUrl",
                value: "https://pbs.twimg.com/media/Ei3lNlHXsAAoMQD.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "ImageUrl",
                value: "https://collectingcars.imgix.net/007137/19-ww-8.jpg?w=1263&fit=fillmax&crop=edges&auto=format,compress&cs=srgb&q=85");
        }
    }
}
