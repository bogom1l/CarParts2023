using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SeedSeriousCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4f635ee-e790-49f0-9309-97c845231aa0", "AQAAAAEAACcQAAAAEJ7zGMVr4Al85UyD+vVF4yuOqRUDT3h1/Oyy2AnvsqRVgfD39Vcl0RLg+XhTI2YT0g==", "65e814d6-25e9-4af8-bd37-8b99c79cda4f" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CategoryId", "Color", "DealerId", "Description", "EngineSize", "FuelConsumption", "FuelTypeId", "Horsepower", "ImageUrl", "Make", "Model", "Price", "RentPrice", "RentalEndDate", "RentalStartDate", "RenterId", "TopSpeed", "Torque", "TransmissionId", "Weight", "Year" },
                values: new object[,]
                {
                    { 180, 10.1, 3, "Red", 14, "ToAddDescription", 2993.0, 5.5999999999999996, 2, 110.0, "https://www.auto-data.net/images/f76/Skoda-Fabia-III-facelift-2018.jpg", "Skoda", "Fabia III", 24000.0, 130.0, null, null, null, 195.0, 200.0, 2, 1957.0, 2018 },
                    { 181, 6.7999999999999998, 4, "Dark blue", 14, "ToAddDescription", 3456.0, 11.699999999999999, 2, 290.0, "https://www.auto-data.net/images/f28/file9510003.jpg", "Lexus", "RX IV", 85000.0, 220.0, null, null, null, 200.0, 363.0, 1, 2025.0, 2016 },
                    { 182, 9.5, 1, "White", 14, "ToAddDescription", 1999.0, 10.800000000000001, 2, 145.0, "https://www.auto-data.net/images/f88/Volvo-S40-II-facelift-2007.jpg", "Volvo", "S40 II", 4800.0, 75.0, null, null, null, 200.0, 185.0, 2, 1370.0, 2011 },
                    { 183, 10.699999999999999, 5, "Red", 14, "ToAddDescription", 2993.0, 10.1, 2, 163.0, "https://www.auto-data.net/images/f56/Kia-Optima-IV-Sportswagon-facelift-2018.jpg", "Kia", "Optima IV", 3900.0, 360.0, null, null, null, 205.0, 196.0, 1, 1625.0, 2018 },
                    { 184, 6.4000000000000004, 1, "Black", 14, "ToAddDescription", 2993.0, 9.0, 1, 286.0, "https://i.pinimg.com/originals/51/62/d5/5162d58a4f273c8ce26544da15659b5d.jpg", "BMW", "E60", 18500.0, 190.0, null, null, null, 250.0, 580.0, 1, 1660.0, 2010 },
                    { 185, 5.0999999999999996, 2, "White", 14, "ToAddDescription", 2997.0, 14.6, 2, 330.0, "https://media.suara.com/pictures/653x366/2019/05/23/91189-toyota-supra-mk4.jpg", "Toyota", "Supra", 60000.0, 300.0, null, null, null, 250.0, 440.0, 2, 1570.0, 1993 },
                    { 186, 5.7000000000000002, 3, "Black", 14, "ToAddDescription", 1984.0, 12.4, 2, 265.0, "https://www.ilr-carbon.com/1603-large_default/audi-a3-s3-8p-3-dr-rear-spoiler-rs3-style.jpg", "Audi", "S3 8P", 15400.0, 210.0, null, null, null, 250.0, 350.0, 2, 1455.0, 2006 },
                    { 187, 6.9000000000000004, 6, "Black", 14, "ToAddDescription", 2996.0, 11.800000000000001, 2, 272.0, "https://www.auto-data.net/images/f37/BMW-6-Series-Convertible-E64-facelift-2007.jpg", "BMW", "E64", 24000.0, 260.0, null, null, null, 250.0, 320.0, 2, 1740.0, 2007 },
                    { 188, 7.2000000000000002, 2, "Black", 14, "ToAddDescription 330cd", 2993.0, 9.0999999999999996, 1, 204.0, "https://cloud.leparking.fr/2021/09/07/00/14/bmw-serie-3-coupe-bmw-e46-330cd-coupe-manual-rare-colour-xenons-satnav-heated-seats-bleu_8263957425.jpg", "BMW", "E46", 8100.0, 150.0, null, null, null, 250.0, 410.0, 2, 1540.0, 2003 },
                    { 189, 10.199999999999999, 8, "White", 14, "ToAddDescription", 2231.0, 8.3000000000000007, 1, 136.0, "https://d1gymyavdvyjgt.cloudfront.net/drive/images/made/drive/images/remote/https_ssl.caranddriving.com/f2/images/used/big/toycorollaverso%202006_750_500_70.jpg", "Toyota", "Corolla Verso II", 6800.0, 70.0, null, null, null, 250.0, 310.0, 2, 1575.0, 2004 },
                    { 190, 6.0, 2, "Grey", 14, "ToAddDescription C300", 1991.0, 8.3000000000000007, 2, 245.0, "https://www.auto-data.net/images/f22/file8603854.jpg", "Mercedes-Benz", "C-Class", 5200.0, 135.0, null, null, null, 250.0, 370.0, 1, 1490.0, 2016 },
                    { 191, 6.7999999999999998, 4, "White", 14, "ToAddDescription", 3444.0, 18.5, 2, 415.0, "https://www.auto-data.net/images/f109/Toyota-Land-Cruiser-J300.jpg", "Toyota", "Land Cruiser", 85000.0, 190.0, null, null, null, 250.0, 650.0, 1, 2520.0, 2003 },
                    { 192, 8.5999999999999996, 5, "Blue", 14, "ToAddDescription", 1995.0, 8.0999999999999996, 1, 163.0, "https://www.auto-data.net/images/f41/BMW-3-Series-Touring-E91.jpg", "BMW", "E91", 8200.0, 140.0, null, null, null, 223.0, 340.0, 2, 1510.0, 2005 },
                    { 193, 6.7999999999999998, 7, "Yellow", 14, "ToAddDescription", 5657.0, 18.100000000000001, 2, 345.0, "https://www.auto-data.net/images/f46/Dodge-Ram-1500-III-DR-DH.jpg", "Dodge", "Ram", 3700.0, 330.0, null, null, null, 250.0, 529.0, 1, 1880.0, 2005 },
                    { 194, 11.1, 4, "Red", 14, "ToAddDescription", 2999.0, 6.7000000000000002, 2, 90.0, "https://cdn3.focus.bg/autodata/i/dacia/sandero/sandero-ii-stepway/large/675829b961ab0a61241270896e202b87.jpg", "Dacia", "Sandero II Stepway", 9999.0, 199.0, null, null, null, 170.0, 135.0, 2, 1023.0, 2013 },
                    { 195, 10.800000000000001, 3, "Black", 14, "ToAddDescription", 1598.0, 10.199999999999999, 2, 102.0, "https://static-eu.cargurus.com/images/forsale/2023/05/16/15/02/2003_mercedes-benz_a-class-pic-3974413017599453644-1024x768.jpeg", "Mercedes-Benz", "A-Class (W168)", 4400.0, 110.0, null, null, null, 180.0, 150.0, 2, 1135.0, 1999 },
                    { 196, 8.0999999999999996, 1, "Grey", 14, "ToAddDescription", 1798.0, 7.4000000000000004, 2, 170.0, "https://www.auto-data.net/images/f93/Audi-A4-B8-8K-facelift-2011.jpg", "Audi", "A4", 12400.0, 180.0, null, null, null, 230.0, 320.0, 2, 1430.0, 2011 },
                    { 197, 3.6000000000000001, 1, "Black", 14, "ToAddDescription", 3996.0, 14.4, 2, 550.0, "https://www.auto-data.net/images/f15/file8561600.jpg", "Porsche", "Panamera G2", 175000.0, 100.0, null, null, null, 306.0, 770.0, 1, 1995.0, 2019 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 197);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df571915-1637-4588-82e2-12da7e22f453", "AQAAAAEAACcQAAAAEAi1nGlIcLCN5T18v+uNwfzfdmi+WYNcEBPlbxi1k7cm3hWfve0NlqocmTYH8HvXsg==", "63684d46-8935-40e6-96c7-c5546453a6b8" });
        }
    }
}
