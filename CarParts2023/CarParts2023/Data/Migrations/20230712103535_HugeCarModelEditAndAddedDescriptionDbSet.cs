using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts2023.Data.Migrations
{
    public partial class HugeCarModelEditAndAddedDescriptionDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Cars_CarId",
                table: "Parts");

            migrationBuilder.DeleteData(
                table: "CarUsers",
                keyColumns: new[] { "CarId", "UserId" },
                keyValues: new object[] { 1, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.DeleteData(
                table: "CarUsers",
                keyColumns: new[] { "CarId", "UserId" },
                keyValues: new object[] { 2, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PartUsers",
                keyColumns: new[] { "PartId", "UserId" },
                keyValues: new object[] { 3, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.DeleteData(
                table: "PartUsers",
                keyColumns: new[] { "PartId", "UserId" },
                keyValues: new object[] { 4, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Parts",
                newName: "DescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_CarId",
                table: "Parts",
                newName: "IX_Parts_DescriptionId");

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Wheels = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EngineSize = table.Column<double>(type: "float", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    TopSpeed = table.Column<double>(type: "float", nullable: false),
                    Acceleration = table.Column<double>(type: "float", nullable: false),
                    Horsepower = table.Column<double>(type: "float", nullable: false),
                    Torque = table.Column<double>(type: "float", nullable: false),
                    FuelConsumption = table.Column<double>(type: "float", nullable: false),
                    Emission = table.Column<double>(type: "float", nullable: false),
                    SafetyFeatures = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_Descriptions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_CarId",
                table: "Descriptions",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Descriptions_DescriptionId",
                table: "Parts",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "DescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Descriptions_DescriptionId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "Parts",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_DescriptionId",
                table: "Parts",
                newName: "IX_Parts_CarId");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Make", "Model", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "Ford", "Mustang", "845cb430-7df3-4865-beaf-7fc07799f99c", 2021 },
                    { 2, "Toyota", "Camry", "845cb430-7df3-4865-beaf-7fc07799f99c", 2018 },
                    { 3, "BMW", "3 Series", "845cb430-7df3-4865-beaf-7fc07799f99c", 2020 }
                });

            migrationBuilder.InsertData(
                table: "PartCategories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Engine" },
                    { 2, "Suspension" },
                    { 3, "Brakes" }
                });

            migrationBuilder.InsertData(
                table: "CarUsers",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 1, "845cb430-7df3-4865-beaf-7fc07799f99c" },
                    { 2, "845cb430-7df3-4865-beaf-7fc07799f99c" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CarId", "CategoryId", "Description", "Name", "Price", "UserId" },
                values: new object[,]
                {
                    { 3, null, 1, "V8 Engine", "Engine", 5000.0, "845cb430-7df3-4865-beaf-7fc07799f99c" },
                    { 4, null, 2, "Front Suspension", "Suspension", 1000.0, "845cb430-7df3-4865-beaf-7fc07799f99c" },
                    { 5, null, 3, "Front Brakes", "Brakes", 500.0, "845cb430-7df3-4865-beaf-7fc07799f99c" }
                });

            migrationBuilder.InsertData(
                table: "PartUsers",
                columns: new[] { "PartId", "UserId" },
                values: new object[] { 3, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.InsertData(
                table: "PartUsers",
                columns: new[] { "PartId", "UserId" },
                values: new object[] { 4, "845cb430-7df3-4865-beaf-7fc07799f99c" });

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Cars_CarId",
                table: "Parts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId");
        }
    }
}
