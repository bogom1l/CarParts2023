using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SeededPartsOfficially : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75f69bb9-59b6-4069-858e-125478852b1e", "AQAAAAEAACcQAAAAEA/y5x3ltkQPw1/kF2fx/r1qCfpVIiwWz1chN7O06Y3eDdCT8JqOmfVbqRNLO+cbTg==", "4882257f-3f8f-45e6-9f49-e8e61031cc54" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CategoryId", "DealerId", "Description", "ImageUrl", "Name", "Price", "PurchaserId" },
                values: new object[,]
                {
                    { 73, 1, 14, "ToAddPartDescription", "https://www.bimmerarchive.org/images/5177-114-bmw-m52@2x.jpg", "BMW M52", 15000.0, null },
                    { 74, 1, 14, "ToAddPartDescription", "https://i.ytimg.com/vi/4yw4_1bI63I/maxresdefault.jpg", "BMW M54", 13000.0, null },
                    { 75, 1, 14, "ToAddPartDescription", "https://images-stag.jazelc.com/uploads/theautopian-m2en/335i-engine-bay.jpg", "BMW N54", 17000.0, null },
                    { 76, 2, 14, "ToAddPartDescription", "https://static.wixstatic.com/media/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png/v1/fill/w_640,h_400,al_c,q_85,usm_4.00_1.00_0.00,enc_auto/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png", "S tronic (DSG) Audi", 19000.0, null },
                    { 77, 2, 14, "ToAddPartDescription", "https://www.audi-technology-portal.de/en/download?file=813", "Tiptronic Audi", 21000.0, null },
                    { 78, 2, 14, "ToAddPartDescription", "https://b1936034.smushcdn.com/1936034/wp-content/uploads/2020/01/DL382.png?lossy=1&strip=1&webp=1", "DSG (Direct Shift Gearbox) VW", 9000.0, null },
                    { 79, 2, 14, "ToAddPartDescription", "https://images.hgmsites.net/hug/volkswagen_100708189_h.jpg", "6-speed Manual VW", 7500.0, null },
                    { 80, 3, 14, "ToAddPartDescription", "https://tro-nik.com/wp-content/uploads/2021/07/Mercedes-Benz-W167-brakes.-pic.-1.jpg", "Mercedes-Benz AMG Ceramic Composite Brakes (CCB)", 4500.0, null },
                    { 81, 3, 14, "ToAddPartDescription", "https://www.kunzmann.de/image/replacement-and-wearparts-brake-equipment-brake-di-29847-xl.jpg", "Mercedes-Benz AMG Performance Brakes", 8700.0, null },
                    { 82, 4, 14, "ToAddPartDescription", "https://www.bmw.ie/en/shop/ls/images/connected-drive/xl/VDC_Offer/images/Adaptives_M_Fahrwerk_902x508.jpg", "Adaptive M Suspension", 16000.0, null },
                    { 83, 4, 14, "ToAddPartDescription", "https://audimediacenter-a.akamaihd.net/system/production/media/84119/images/7e6b0f01721320da20eade10395735ebf282c6a1/A1912000_x500.jpg?1582560882", "Audi Dynamic Ride Control (DRC)", 9500.0, null },
                    { 84, 5, 14, "BMW E46 Cab M Sport Dakota Coral Red Leather", "https://trimtechnik.net/assets/images/content/129/bmw_e46_cab_m_sport_coral_red_leather_003__1000.jpg", "M Sport Seats", 123456789.0, null },
                    { 85, 5, 14, "ToAddPartDescription", "https://bringatrailer.com/wp-content/uploads/2019/01/1547765401b064a6f7f52ae3fPhoto-Jan-10-6-09-19-PM.jpg", "Audi RS4 B7 Recaro Seats", 1150.0, null },
                    { 86, 6, 14, "ToAddPartDescription", "https://luethen-motorsport.com/media/image/9f/42/ed/mercedes-c63-amg-coupe-c205-carbon-heckflugel-heckspoiler-ac2051200_600x600.jpg", "Carbon rear wing / rear spoiler", 600.0, null },
                    { 87, 6, 14, "ToAddPartDescription", "https://nastarta-shop.com/wp-content/uploads/2022/02/led_halo.jpg", "LED Angel Eyes (white)", 2200.0, null },
                    { 88, 6, 14, "ToAddPartDescription", "https://bimmerplug.com/cdn/shop/products/LCI-LED-Headlights-BMW-F10-M5-5-Series-2_800x.jpg?v=1655094531", "LCI LED Headlights - BMW F10 M5 & 5 Series", 800.0, null },
                    { 89, 7, 14, "ToAddPartDescription", "https://integralaudio.com/media/catalog/product/cache/429f869d5d4fbd3e94a8a75b24ebea81/f/3/f30.soundstage.complete_2_1.jpg", "Soundstage + Subwoofer System for BMW 3-Series", 2599.0, null },
                    { 90, 7, 14, "ToAddPartDescription", "https://www.ptronic.com/files/images/boitiers/12/1.jpg", "Performance chip Audi A3 1.9 TDI 110hp", 300.0, null },
                    { 91, 7, 14, "ToAddPartDescription", "https://cdn.autodoc.de/thumb?id=17857567&m=1&n=0&lng=bg&ccf=94077841", "First aid kit", 60.0, null },
                    { 92, 6, 14, "ToAddPartDescription", "https://www.felgenoutlet.at/felgenbilder/10985_5/seo/bbs_cc-r_schwarz_matt.jpg?1589867390", "BBS CC-R Rims", 2400.0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 92);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4f635ee-e790-49f0-9309-97c845231aa0", "AQAAAAEAACcQAAAAEJ7zGMVr4Al85UyD+vVF4yuOqRUDT3h1/Oyy2AnvsqRVgfD39Vcl0RLg+XhTI2YT0g==", "65e814d6-25e9-4af8-bd37-8b99c79cda4f" });
        }
    }
}
