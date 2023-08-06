using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class ValidationReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cb04556-9e4e-46b6-8b7c-6c0379967290", "AQAAAAEAACcQAAAAEGEJFzKJl78vc4eG1XPwyRBb4Nhur/bEqALXsl8w6fBzkGZLokF3DyOuTyjFTVELVg==", "538bf513-7281-46ec-9476-f6a1c01e9bbe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85bbc2b4-99b5-4b7e-9fcf-f140c2b65a35", "AQAAAAEAACcQAAAAEPOhBqsZQvYYXlbi8k58DwLPyEd3hC1QbWgo7VznBEqfl0QYFFmJ/Ud0dgk9etYspA==", "0fac83a1-cece-462f-8aea-85eba87a9670" });
        }
    }
}
