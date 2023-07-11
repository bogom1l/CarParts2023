using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class RemovedUnneccessaryPropertyCarIdFromPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Cars_CarId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                column: "CarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 4,
                column: "CarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 5,
                column: "CarId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Cars_CarId",
                table: "Parts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Cars_CarId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                column: "CarId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 4,
                column: "CarId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 5,
                column: "CarId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Cars_CarId",
                table: "Parts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
