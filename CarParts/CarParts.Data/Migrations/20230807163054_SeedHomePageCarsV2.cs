using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class SeedHomePageCarsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dbbfa7a-8f6a-4423-b357-6bfbfa8355ca", "AQAAAAEAACcQAAAAEBl2VC8g5KuK1LpoLLn1wuZh1jDmuubUZ0f8tTuaI2rP7IxotxIvOQExQefmH184+Q==", "858d86d5-775b-4afc-bc4a-806896e7b8e7" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CategoryId", "Color", "DealerId", "Description", "EngineSize", "FuelConsumption", "FuelTypeId", "Horsepower", "ImageUrl", "Make", "Model", "Price", "RentPrice", "RentalEndDate", "RentalStartDate", "RenterId", "TopSpeed", "Torque", "TransmissionId", "Weight", "Year" },
                values: new object[,]
                {
                    { 198, 4.4000000000000004, 2, "Black", 14, "The BMW E92 M3 is a high-performance sports coupe known for its powerful V8 engine, precise handling, and iconic design. With a perfect blend of luxury and exhilaration, it remains a favorite among car enthusiasts seeking a thrilling driving experience.", 4361.0, 18.5, 2, 450.0, "https://collectingcars.imgix.net/007137/19-ww-8.jpg?w=1263&fit=fillmax&crop=edges&auto=format,compress&cs=srgb&q=85", "BMW", "E92 M3", 66500.0, 600.0, null, null, null, 250.0, 440.0, 1, 1530.0, 2010 },
                    { 199, 3.6000000000000001, 2, "Black", 14, "The Mercedes CLS 63 AMG is a luxury four-door coupe that combines elegance with blistering performance. Powered by a potent V8 engine, it offers a comfortable yet exhilarating driving experience, setting new standards for high-end performance cars.", 5461.0, 14.4, 2, 585.0, "https://citycarrentals.ca/wp-content/uploads/2018/02/mercedes-benz-cls-63-amg-black-3.jpg", "Mercedes-Benz", "CLS 63 AMG", 67500.0, 680.0, null, null, null, 250.0, 800.0, 1, 1945.0, 2014 },
                    { 200, 5.0999999999999996, 2, "Black", 14, "The Audi S5 is a dynamic and sleek sports coupe, featuring a turbocharged V6 engine and Quattro all-wheel drive. Its blend of performance, comfort, and cutting-edge technology make it a compelling choice for driving enthusiasts with a taste for luxury.", 2999.0, 10.699999999999999, 2, 333.0, "https://i.pinimg.com/originals/4f/23/28/4f2328613a9577fef6f77eee198e5f65.jpg", "Audi", "S5", 64000.0, 510.0, null, null, null, 250.0, 440.0, 1, 1745.0, 2012 },
                    { 201, 1.1000000000000001, 1, "Black", 14, "Test1", 444.0, 11.0, 1, 333.0, "https://images.drive.com.au/driveau/image/upload/t_wp-default/v1/cms/uploads/jjslyagf8e3gcny2doyy", "Test1", "Test1", 1234.0, 111.0, null, null, null, 123.0, 333.0, 1, 1234.0, 2012 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 201);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75f69bb9-59b6-4069-858e-125478852b1e", "AQAAAAEAACcQAAAAEA/y5x3ltkQPw1/kF2fx/r1qCfpVIiwWz1chN7O06Y3eDdCT8JqOmfVbqRNLO+cbTg==", "4882257f-3f8f-45e6-9f49-e8e61031cc54" });
        }
    }
}
