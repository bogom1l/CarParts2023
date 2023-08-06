using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class ApplicationUserAddCarsToCompare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc176bfc-af43-43a5-969a-6a6154a3c059", "AQAAAAEAACcQAAAAEFgm4obzMK9PYhqgOUOvgwGN36EYhq46CZjzRMNOYdRMdNA9gEQ2NQDhlUSH33f7ww==", "92268e46-9397-47bc-9246-2ec32fd9c334" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee6fbebf-02e4-4eac-966c-fc73b1879ba2", "AQAAAAEAACcQAAAAEPJ6lRtAjwTRFKbtUVXKATXVLC4kMJZc89MjFL0v8i60BkSsij6lu50Oa5xGLievuA==", "9f1e31f0-8e9e-45cb-a2cb-0279b04ee0ad" });
        }
    }
}
