using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class AddPartsForHomePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53573b79-4d23-4a28-95eb-baf4709858c7", "AQAAAAEAACcQAAAAENCsaka8+kflLO1xlH6hwspN6O43TCC1+UaLHlMdR0aI/e4e4xKIkRc/T2Q8Ugmmqg==", "8fe152fe-02fa-4932-953e-eeb47aa6f58d" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CategoryId", "DealerId", "Description", "ImageUrl", "Name", "Price", "PurchaserId" },
                values: new object[,]
                {
                    { 93, 1, 14, "The BMW S85 is a high-revving 5.0-liter V10 engine, primarily known for powering the iconic E60 M5 and E63 M6 models. With its distinctive exhaust note and impressive performance, the S85 remains a celebrated powerplant among automotive enthusiasts.", "https://upload.wikimedia.org/wikipedia/commons/f/f0/BMW_S85B50_Engine.JPG", "BMW S85", 2400.0, null },
                    { 94, 3, 14, "Audi S-line brakes offer enhanced stopping power and performance, designed to complement high-performance S-line models. With improved brake pads, calipers, and rotors, they provide precise control and confidence, making them ideal for spirited driving experiences.", "https://i.ebayimg.com/images/g/vHMAAOSwc6deV7Zx/s-l1600.jpg", "Audi S-line Brakes", 1700.0, null },
                    { 95, 6, 14, "The Mercedes-Benz C-Class side mirror features a sleek design with integrated turn signals and auto-dimming capabilities. Its power-adjustable function and heating element provide added convenience and safety, enhancing the driving experience.", "https://www.mercedes-benz.com.cy/passengercars/mercedes-benz-cars/models/c-class/coupe-c205/safety/safety-packages/mirror-package/_jcr_content/par/productinfotextimage/media2/slides/videoimageslide_3f5b/image.MQ6.12.20210515155216.jpeg", "Side Mirror C-Class", 390.0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 95);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dbbfa7a-8f6a-4423-b357-6bfbfa8355ca", "AQAAAAEAACcQAAAAEBl2VC8g5KuK1LpoLLn1wuZh1jDmuubUZ0f8tTuaI2rP7IxotxIvOQExQefmH184+Q==", "858d86d5-775b-4afc-bc4a-806896e7b8e7" });
        }
    }
}
