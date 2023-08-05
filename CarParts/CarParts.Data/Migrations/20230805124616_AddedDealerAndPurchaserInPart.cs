using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class AddedDealerAndPurchaserInPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_AspNetUsers_OwnerId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_OwnerId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Parts");

            migrationBuilder.AddColumn<int>(
                name: "DealerId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PurchaserId",
                table: "Parts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee6fbebf-02e4-4eac-966c-fc73b1879ba2", "AQAAAAEAACcQAAAAEPJ6lRtAjwTRFKbtUVXKATXVLC4kMJZc89MjFL0v8i60BkSsij6lu50Oa5xGLievuA==", "9f1e31f0-8e9e-45cb-a2cb-0279b04ee0ad" });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_DealerId",
                table: "Parts",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PurchaserId",
                table: "Parts",
                column: "PurchaserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_AspNetUsers_PurchaserId",
                table: "Parts",
                column: "PurchaserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Dealers_DealerId",
                table: "Parts",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_AspNetUsers_PurchaserId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Dealers_DealerId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_DealerId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PurchaserId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "PurchaserId",
                table: "Parts");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Parts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e8b2520-9284-4e6f-aef1-eae16b9bb084", "AQAAAAEAACcQAAAAEJirY2wYmtVyC8bgFrangPj9VEjyU/17e96wZ3AtfDyYErEDVBB3ycsq7Ml3K5sDUg==", "7664ff25-55d3-40ad-aa16-081129a672bf" });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_OwnerId",
                table: "Parts",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_AspNetUsers_OwnerId",
                table: "Parts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
