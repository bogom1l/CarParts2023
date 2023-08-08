using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Data.Migrations
{
    public partial class BetterSeedCarParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 179);

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
                values: new object[] { "813e37c3-7a4d-4672-9a86-a94cc10489f1", "AQAAAAEAACcQAAAAEPSp7OWRpF1gbI9jfMl/v7FiKDEUdu4aIBrTnVnnxdaXBFc/vmgI8O0dhMraW/fLyw==", "419676d4-bb39-4385-80c1-fd0593a685df" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CategoryId", "Color", "DealerId", "Description", "EngineSize", "FuelConsumption", "FuelTypeId", "Horsepower", "ImageUrl", "Make", "Model", "Price", "RentPrice", "RentalEndDate", "RentalStartDate", "RenterId", "TopSpeed", "Torque", "TransmissionId", "Weight", "Year" },
                values: new object[,]
                {
                    { 207, 4.9000000000000004, 1, "Black", 14, "The Mercedes-Benz S-Class (W223), a pinnacle of luxury and engineering excellence, continues its legacy in the year 2022. Renowned for its opulent features, cutting-edge technology, and refined performance, the S-Class remains a symbol of sophistication and prestige. The exterior design of the S-Class (W223) strikes a balance between timeless elegance and modern aesthetics. The body lines exude a sense of fluidity and strength, while the meticulously crafted details showcase the brand's commitment to perfection. Inside, the cabin offers an oasis of comfort and luxury. Premium materials, exquisite craftsmanship, and advanced features create an ambiance that indulges the senses. Mercedes-Benz's latest innovations are seamlessly integrated into the S-Class. The state-of-the-art MBUX infotainment system greets occupants with intuitive controls, voice commands, and a futuristic digital cockpit. Augmented reality navigation, AI-powered predictive functions, and customizable displays elevate the driving experience. Under the hood, the S-Class offers an array of potent powertrains, catering to diverse preferences. From refined gasoline and diesel engines to electrified options, each variant delivers a harmonious blend of power and efficiency. The advanced suspension system ensures a smooth and controlled ride, even on challenging road surfaces. Mercedes-Benz's commitment to safety is exemplified by the S-Class (W223). The vehicle incorporates an array of advanced driver assistance systems, including adaptive cruise control, lane-keeping assist, automatic emergency braking, and more. These features work together to enhance driver confidence and mitigate potential risks. The S-Class is renowned for introducing groundbreaking innovations, and the W223 is no exception. It boasts technologies such as E-Active Body Control, which uses cameras to scan the road and adjust the suspension accordingly, providing unparalleled comfort and stability. In conclusion, the Mercedes-Benz S-Class (W223) exemplifies the brand's dedication to luxury, technology, and performance. As a flagship model, it continues to set the standard for the automotive industry, redefining what it means to travel in style and comfort. With its timeless design and cutting-edge features, the S-Class remains an icon of automotive excellence in the year 2022.", 2999.0, 0.69999999999999996, 4, 365.0, "https://www.auto-data.net/images/f94/Mercedes-Benz-S-class-W223.jpg", "Mercedes-Benz", "S-Class (W223)", 175000.0, 700.0, null, null, null, 250.0, 500.0, 1, 2345.0, 2022 },
                    { 208, 12.9, 3, "black", 14, "The VW Golf 5, launched in 2004, is a part of Volkswagen's renowned Golf lineup. It blends practicality, reliability, and driving enjoyment seamlessly. With a design that balances aesthetics and modern simplicity, the Golf 5's compact dimensions offer style without sacrificing functionality. Inside, the cabin emphasizes user-friendly controls, comfortable seating, and ample cargo space. Under the hood, the Golf 5 presents a range of engine options, each delivering a mix of efficiency and performance. Responsive steering and a well-tuned suspension contribute to a confident driving experience. While not equipped with the latest technology, the Golf 5's interior provides essential comforts, reflecting Volkswagen's commitment to quality. In terms of safety, the Golf 5 incorporates airbags, anti-lock brakes, and stability control for occupant protection. As a significant iteration in the Golf lineup, the Golf 5 upholds the model's reputation for reliability and practicality, appealing to drivers seeking an affordable and dependable option. In summary, the 2004 VW Golf 5 remains a symbol of reliability and practicality within the compact car segment. Its enduring design, balanced performance, and comfort continue to exemplify Volkswagen's dedication to meeting diverse driver needs.", 1896.0, 6.5, 1, 90.0, "https://www.auto-data.net/images/f118/Volkswagen-Golf-V.jpg", "VW", "Golf 5", 6200.0, 40.0, null, null, null, 176.0, 210.0, 1, 1285.0, 2004 },
                    { 209, 10.1, 3, "Red", 14, "The Skoda Fabia III, introduced in 2018 by Skoda, embodies practicality, efficiency, and modern design in the compact car segment. With its sleek exterior and contemporary lines, the Fabia III boasts a design that merges aesthetics with functionality. The compact dimensions make it maneuverable in urban environments while offering ample interior space for passengers and cargo. Under the hood, the Fabia III offers a range of efficient engines, catering to both city commuting and longer journeys. Its balanced performance strikes a chord between fuel efficiency and driving enjoyment. The cabin of the Fabia III reflects Skoda's commitment to user-centered design. The interior space is intelligently organized, providing ergonomic seating and intuitive controls. Modern connectivity features ensure a convenient driving experience. In terms of safety, the Fabia III is equipped with standard airbags, anti-lock brakes, stability control, and more. While not the most advanced in terms of safety tech, it delivers a reassuring level of protection. As a part of Skoda's lineup, the Fabia III aligns with the brand's reputation for reliability and practicality. It's an ideal choice for drivers seeking a compact car that effortlessly combines style and functionality. In conclusion, the 2018 Skoda Fabia III stands as a testament to Skoda's commitment to producing compact cars that excel in practicality and efficiency. With its modern design, well-organized interior, and balanced performance, the Fabia III remains a relevant choice for drivers looking for a reliable and stylish urban companion.", 2993.0, 5.5999999999999996, 2, 110.0, "https://www.auto-data.net/images/f76/Skoda-Fabia-III-facelift-2018.jpg", "Skoda", "Fabia III", 24000.0, 130.0, null, null, null, 195.0, 200.0, 2, 1957.0, 2018 },
                    { 210, 6.7999999999999998, 4, "Dark blue", 14, "The Lexus RX IV, introduced in 2016 by Lexus, is a luxury SUV that blends sophistication, advanced technology, and comfort in a seamless package. Characterized by its bold and distinctive design, the RX IV commands attention on the road. The sharp lines and signature Lexus spindle grille contribute to its upscale presence, while the attention to detail showcases the brand's commitment to craftsmanship. Inside the RX IV, the cabin offers a sanctuary of luxury and modernity. High-quality materials, exquisite finishes, and meticulously crafted details create an ambiance that indulges the senses. The intuitive layout and user-friendly controls contribute to an effortless driving experience. Under the hood, the RX IV offers a range of powerful and efficient engine options, delivering both performance and fuel economy. The advanced suspension system ensures a smooth and composed ride, making it well-suited for both city driving and long journeys. Lexus is synonymous with cutting-edge technology, and the RX IV is no exception. It incorporates a suite of advanced features, including a user-friendly infotainment system, driver assistance technologies, and a premium sound system, elevating the driving experience to new heights. In terms of safety, the RX IV is equipped with a comprehensive set of features, including adaptive cruise control, lane departure warning, automatic emergency braking, and more. These systems work in harmony to enhance driver confidence and mitigate potential risks. As a flagship SUV in Lexus's lineup, the RX IV exemplifies the brand's dedication to luxury and innovation. Its combination of bold design, refined interior, and advanced technology positions it as a compelling choice in the luxury SUV segment. In conclusion, the 2016 Lexus RX IV is a testament to Lexus's pursuit of excellence in luxury and performance. With its distinctive design, opulent interior, and state-of-the-art technology, the RX IV continues to capture the essence of modern luxury and remains a symbol of Lexus's commitment to elevating the driving experience.", 3456.0, 11.699999999999999, 2, 290.0, "https://www.auto-data.net/images/f28/file9510003.jpg", "Lexus", "RX IV", 85000.0, 220.0, null, null, null, 200.0, 363.0, 1, 2025.0, 2016 },
                    { 211, 9.5, 1, "White", 14, "The Volvo S40 II, introduced in 2011 by Volvo, represents a harmonious blend of Scandinavian design, safety innovation, and driving dynamics in a compact sedan package. The S40 II's exterior design exudes a distinctive blend of elegance and modernity. Clean lines and a sleek profile capture Volvo's commitment to minimalist aesthetics while conveying a sense of purposeful movement. Inside, the cabin of the S40 II offers a comfortable and intuitive environment. High-quality materials and meticulous attention to detail create an atmosphere that prioritizes both driver and passenger comfort. The user-friendly controls and ergonomic layout contribute to an enjoyable driving experience. Under the hood, the S40 II presents a range of efficient and capable engine options, delivering a balance between performance and fuel economy. The sedan's well-tuned suspension system provides a composed and engaging ride, whether navigating city streets or cruising on the highway. Volvo's reputation for safety innovation shines in the S40 II. The sedan is equipped with a comprehensive set of safety features, including advanced airbag systems, stability control, and Volvo's City Safety system, which can help prevent or mitigate collisions at low speeds. While the S40 II might not offer the most cutting-edge infotainment features, it does provide essential connectivity and entertainment options to enhance the driving experience. As part of Volvo's lineup, the S40 II embodies the brand's commitment to safety and quality. It's a compelling choice for drivers seeking a compact sedan that combines style, comfort, and advanced safety features. In summary, the 2011 Volvo S40 II remains a testament to Volvo's legacy of designing vehicles that prioritize safety, comfort, and Scandinavian aesthetics. With its elegant design, well-appointed interior, and comprehensive safety features, the S40 II continues to reflect Volvo's dedication to engineering vehicles that enhance both the driving experience and occupant well-being.", 1999.0, 10.800000000000001, 2, 145.0, "https://www.auto-data.net/images/f88/Volvo-S40-II-facelift-2007.jpg", "Volvo", "S40 II", 4800.0, 75.0, null, null, null, 200.0, 185.0, 2, 1370.0, 2011 },
                    { 212, 10.699999999999999, 5, "Red", 14, "The Kia Optima IV, introduced in 2018, is a midsize sedan that showcases Kia's commitment to style, technology, and value. With its modern exterior design, the Optima IV captures attention on the road. Sleek lines and a bold front grille create an assertive presence, while the attention to aerodynamics contributes to its efficiency. Inside the Optima IV, the cabin offers a blend of comfort and technology. High-quality materials and well-crafted surfaces create an inviting atmosphere. The intuitive infotainment system provides connectivity and entertainment features that enhance the driving experience. Under the hood, the Optima IV offers a range of engine options, catering to different preferences for performance and fuel efficiency. The sedan's well-balanced suspension and responsive steering contribute to a confident and enjoyable driving dynamic. In terms of safety, the Optima IV is equipped with a suite of features, including adaptive cruise control, automatic emergency braking, lane departure warning, and more. These features work together to enhance driver confidence and mitigate potential risks. As a part of Kia's lineup, the Optima IV represents the brand's commitment to delivering value without compromising on style and technology. It's a practical choice for drivers seeking a midsize sedan that offers a combination of comfort, performance, and safety. In conclusion, the 2018 Kia Optima IV reflects Kia's dedication to providing a well-rounded midsize sedan. With its modern design, comfortable interior, and advanced safety and technology features, the Optima IV remains a relevant choice for drivers who prioritize style and practicality in their daily commute.", 2993.0, 10.1, 2, 163.0, "https://www.auto-data.net/images/f56/Kia-Optima-IV-Sportswagon-facelift-2018.jpg", "Kia", "Optima IV", 3900.0, 360.0, null, null, null, 205.0, 196.0, 1, 1625.0, 2018 },
                    { 213, 6.4000000000000004, 1, "Black", 14, "The BMW E60, introduced in 2010, is a representation of BMW's commitment to luxury, performance, and driving pleasure in the midsize sedan category. With its iconic design, the E60 carries BMW's distinctive styling cues. The elegant yet dynamic lines of the exterior showcase a timeless aesthetic that blends sophistication with athleticism. Inside, the cabin of the E60 offers a driver-focused environment. High-quality materials, precision craftsmanship, and ergonomic design create a space that exudes luxury and comfort. The intuitive controls and advanced infotainment system contribute to an engaging driving experience. Under the hood, the E60 offers a range of powerful engine options, each delivering the performance and refinement expected from a BMW. The sedan's responsive handling and well-tuned suspension system provide a dynamic driving experience that balances comfort and sportiness. Safety features in the E60 include airbags, stability control, and advanced braking systems, which contribute to occupant protection and peace of mind while on the road. As part of BMW's lineup, the E60 upholds the brand's legacy of engineering excellence and driving dynamics. It's an appealing choice for drivers who seek a midsize sedan that offers a blend of luxury, performance, and prestige. In summary, the 2010 BMW E60 continues to embody BMW's commitment to creating vehicles that deliver an exceptional driving experience. With its iconic design, luxurious interior, and engaging performance, the E60 remains a symbol of BMW's dedication to producing vehicles that cater to enthusiasts and luxury-seekers alike.", 2993.0, 9.0, 1, 286.0, "https://i.pinimg.com/originals/51/62/d5/5162d58a4f273c8ce26544da15659b5d.jpg", "BMW", "E60", 18500.0, 190.0, null, null, null, 250.0, 580.0, 1, 1660.0, 2010 },
                    { 214, 5.0999999999999996, 2, "White", 14, "The Toyota Supra, introduced in 1993, is an iconic sports car that embodies Toyota's pursuit of performance, style, and innovation. With its distinctive design, the Supra carries an unmistakable presence on the road. The sleek and aerodynamic body lines reflect both form and function, showcasing a blend of elegance and sportiness. Inside the Supra, the driver-focused cockpit emphasizes a connection between the driver and the road. High-quality materials, supportive seating, and intuitive controls create an environment that caters to both performance and comfort. Under the hood, the Supra offers a robust and turbocharged engine, delivering exhilarating acceleration and a thrilling driving experience. The precise handling and balanced suspension system make it a joy to navigate winding roads and tracks alike. While safety features in the 1993 Supra might not be as advanced as those in modern cars, it offers essential features like airbags and anti-lock brakes to ensure a level of occupant protection. As a part of Toyota's lineup, the Supra remains a symbol of the brand's dedication to engineering excellence and innovation. It's a coveted choice for enthusiasts and drivers seeking a sports car that offers both performance and prestige. In conclusion, the 1993 Toyota Supra stands as a testament to Toyota's commitment to creating a sports car that excites and inspires. With its iconic design, thrilling performance, and driver-focused interior, the Supra continues to hold a special place in the hearts of automotive enthusiasts and remains a timeless representation of Toyota's dedication to delivering excitement on the road.", 2997.0, 14.6, 2, 330.0, "https://media.suara.com/pictures/653x366/2019/05/23/91189-toyota-supra-mk4.jpg", "Toyota", "Supra", 60000.0, 300.0, null, null, null, 250.0, 440.0, 2, 1570.0, 1993 },
                    { 215, 5.7000000000000002, 3, "Black", 14, "The Audi S3 8P, introduced in 2006, is a performance-oriented compact car that represents Audi's dedication to combining power, sophistication, and driving dynamics. With its understated yet sporty design, the S3 8P carries Audi's signature styling cues. The sleek lines and aggressive stance give the car a dynamic presence on the road, while subtle details hint at its performance capabilities. Inside, the S3 8P offers a well-appointed interior that caters to both comfort and sportiness. High-quality materials, supportive seating, and a driver-centric layout create an environment that aligns with Audi's commitment to luxury and performance. Under the hood, the S3 8P is powered by a potent turbocharged engine, delivering exhilarating acceleration and a spirited driving experience. The sport-tuned suspension and responsive steering contribute to the car's engaging handling and precise control. While safety features in the 2006 S3 8P might not be as advanced as those found in newer vehicles, it offers standard airbags, stability control, and other essential systems to ensure occupant protection. As a part of Audi's lineup, the S3 8P showcases the brand's passion for engineering vehicles that offer performance without compromising on luxury. It's a sought-after choice for enthusiasts who seek a compact car that delivers driving excitement. In summary, the 2006 Audi S3 8P stands as a testament to Audi's commitment to producing performance-oriented vehicles. With its sporty design, exhilarating performance, and refined interior, the S3 8P continues to capture the essence of Audi's dedication to creating cars that offer both thrill and sophistication on the road.", 1984.0, 12.4, 2, 265.0, "https://www.ilr-carbon.com/1603-large_default/audi-a3-s3-8p-3-dr-rear-spoiler-rs3-style.jpg", "Audi", "S3 8P", 15400.0, 210.0, null, null, null, 250.0, 350.0, 2, 1455.0, 2006 },
                    { 216, 6.9000000000000004, 6, "Black", 14, "The BMW E64, introduced in 2007, is a convertible that embodies BMW's pursuit of luxury, open-air driving, and performance. With its elegant design, the E64 carries BMW's signature styling cues. The sleek lines and graceful proportions translate seamlessly into the convertible form, creating a harmonious blend of aesthetics and functionality. Inside the E64, the cabin offers a blend of comfort and sophistication. High-quality materials, meticulous craftsmanship, and thoughtful details create an environment that caters to both driver and passenger enjoyment. The convertible configuration adds an extra layer of excitement to the driving experience. Under the hood, the E64 presents a range of engine options, each delivering a balance between performance and refinement. The convertible's chassis and suspension are well-tuned to provide a controlled and engaging ride, whether the top is up or down. While the E64 might not feature the most advanced infotainment systems found in newer BMWs, it provides essential connectivity and entertainment features to enhance the driving experience. As a part of BMW's lineup, the E64 reflects the brand's commitment to producing vehicles that offer a blend of luxury and driving pleasure. It's a desirable choice for drivers seeking a convertible that encapsulates the thrill of open-air motoring. In conclusion, the 2007 BMW E64 remains a testament to BMW's dedication to delivering luxury and performance in a convertible package. With its timeless design, refined interior, and engaging driving dynamics, the E64 continues to capture the essence of BMW's philosophy of creating vehicles that provide a unique and exhilarating driving experience.", 2996.0, 11.800000000000001, 2, 272.0, "https://www.auto-data.net/images/f37/BMW-6-Series-Convertible-E64-facelift-2007.jpg", "BMW", "E64", 24000.0, 260.0, null, null, null, 250.0, 320.0, 2, 1740.0, 2007 },
                    { 217, 7.2000000000000002, 2, "Black", 14, "The BMW E46, introduced in 2003, is a compact luxury car that exemplifies BMW's commitment to performance, driving dynamics, and refined design. With its timeless design, the E46 carries BMW's iconic styling cues. The balanced proportions, clean lines, and distinctive front grille create an appearance that combines elegance with a touch of sportiness. Inside the E46, the cabin offers a blend of comfort and driver-oriented design. High-quality materials, meticulous attention to detail, and intuitive controls contribute to an environment that caters to both driver and passenger satisfaction. The cockpit layout fosters a connection between the driver and the road. Under the hood, the E46 presents a range of engine options, each delivering a balance between power and efficiency. The well-tuned suspension system and responsive steering provide an engaging driving experience that blends comfort and sportiness. While the E46's technology might not be as advanced as that of modern cars, it offers essential amenities to enhance the driving experience, including infotainment and connectivity features. As a part of BMW's lineup, the E46 reflects the brand's commitment to producing vehicles that offer dynamic driving characteristics and a touch of luxury. It's a sought-after choice for enthusiasts and drivers seeking a compact car that provides both performance and prestige. In conclusion, the 2003 BMW E46 stands as a testament to BMW's dedication to engineering vehicles that offer a balance of performance and refinement. With its timeless design, driver-focused interior, and engaging driving dynamics, the E46 continues to capture the essence of BMW's philosophy of delivering the ultimate driving experience.", 2993.0, 9.0999999999999996, 1, 204.0, "https://cloud.leparking.fr/2021/09/07/00/14/bmw-serie-3-coupe-bmw-e46-330cd-coupe-manual-rare-colour-xenons-satnav-heated-seats-bleu_8263957425.jpg", "BMW", "E46", 8100.0, 150.0, null, null, null, 250.0, 410.0, 2, 1540.0, 2003 },
                    { 218, 10.199999999999999, 8, "White", 14, "The Toyota Corolla Verso II, introduced in 2004, is a versatile and practical compact MPV that exemplifies Toyota's commitment to reliability, functionality, and family-friendly design. With its unassuming yet functional design, the Corolla Verso II embodies Toyota's approach to creating vehicles that cater to everyday needs. The compact dimensions, efficient use of space, and practical features contribute to its suitability for family-oriented use. Inside the Corolla Verso II, the cabin offers a flexible and user-friendly layout. Seating configurations can be adjusted to accommodate passengers or cargo, making it adaptable for various situations. The emphasis on functionality extends to the controls and features, which prioritize ease of use. Under the hood, the Corolla Verso II offers a range of efficient engine options, delivering reliable and economical performance for both city and highway driving. The vehicle's suspension system provides a comfortable and stable ride, enhancing passenger comfort. While the Corolla Verso II's technology might not be as advanced as that of newer MPVs, it offers essential features to enhance convenience and entertainment during journeys. As part of Toyota's lineup, the Corolla Verso II reflects the brand's reputation for reliability and practicality. It's a practical choice for families and drivers seeking a compact MPV that offers functionality and dependability. In conclusion, the 2004 Toyota Corolla Verso II stands as a testament to Toyota's dedication to engineering vehicles that address practical needs. With its adaptable design, family-friendly interior, and efficient performance, the Corolla Verso II continues to uphold Toyota's legacy of producing vehicles that cater to a wide range of drivers' requirements.", 2231.0, 8.3000000000000007, 1, 136.0, "https://d1gymyavdvyjgt.cloudfront.net/drive/images/made/drive/images/remote/https_ssl.caranddriving.com/f2/images/used/big/toycorollaverso%202006_750_500_70.jpg", "Toyota", "Corolla Verso II", 6800.0, 70.0, null, null, null, 250.0, 310.0, 2, 1575.0, 2004 },
                    { 219, 6.0, 2, "Grey", 14, "The Mercedes-Benz C-Class, introduced in 2016, represents a harmonious blend of luxury, performance, and advanced technology within the compact luxury sedan segment. With its refined and stylish design, the C-Class carries Mercedes-Benz's signature aesthetic. The sleek body lines and distinctive front grille create an elegant and modern appearance that captures attention on the road. Inside the C-Class, the cabin offers a haven of luxury and sophistication. High-quality materials, meticulous attention to detail, and cutting-edge technology create an interior that caters to both driver and passenger comfort. The intuitive infotainment system and user-friendly controls contribute to an elevated driving experience. Under the hood, the C-Class presents a range of engine options, each delivering a balance between power and efficiency. The sedan's well-tuned suspension system provides a smooth and composed ride, ensuring a refined driving dynamic. In terms of safety and technology, the C-Class is equipped with a comprehensive set of features. Advanced driver assistance systems, including adaptive cruise control, automatic emergency braking, and lane departure warning, enhance driver confidence and occupant protection. As a part of Mercedes-Benz's lineup, the C-Class exemplifies the brand's dedication to engineering excellence and luxury. It's a coveted choice for drivers seeking a compact luxury sedan that offers a blend of elegance, performance, and technological innovation. In conclusion, the 2016 Mercedes-Benz C-Class remains a testament to Mercedes-Benz's commitment to delivering luxury and refinement in a compact package. With its sophisticated design, opulent interior, and advanced safety and technology features, the C-Class continues to capture the essence of Mercedes-Benz's philosophy of creating vehicles that provide an exceptional driving experience.", 1991.0, 8.3000000000000007, 2, 245.0, "https://www.auto-data.net/images/f22/file8603854.jpg", "Mercedes-Benz", "C-Class", 5200.0, 135.0, null, null, null, 250.0, 370.0, 1, 1490.0, 2016 },
                    { 220, 6.7999999999999998, 4, "White", 14, "The Toyota Land Cruiser, introduced in 2003, embodies Toyota's legacy of rugged durability, off-road capability, and timeless design within the realm of SUVs. With its iconic and robust design, the Land Cruiser showcases Toyota's commitment to creating vehicles that can conquer diverse terrains. The bold exterior lines, prominent grille, and sturdy construction emphasize the vehicle's capability both on and off the road. Inside the Land Cruiser, the cabin offers a functional and comfortable environment. Practicality and utility take precedence, with durable materials and a layout designed to withstand demanding conditions. The focus on reliability extends to the controls and features, ensuring a dependable and straightforward driving experience. Under the hood, the Land Cruiser presents a powerful engine and a robust four-wheel-drive system, designed to tackle challenging landscapes with confidence. The vehicle's suspension and chassis provide a comfortable ride while maintaining the ability to handle rough terrain. In terms of technology, the 2003 Land Cruiser might not offer the same level of modern amenities found in contemporary SUVs, but it provides essential features for a comfortable journey. As part of Toyota's lineup, the Land Cruiser remains a symbol of the brand's reputation for dependability and off-road prowess. It's a sought-after choice for adventurers and drivers seeking a reliable SUV that can handle both urban environments and the great outdoors. In conclusion, the 2003 Toyota Land Cruiser stands as a testament to Toyota's commitment to producing rugged and capable SUVs. With its enduring design, functional interior, and impressive off-road capabilities, the Land Cruiser continues to uphold Toyota's legacy of engineering vehicles that are built to withstand the test of time and conquer diverse landscapes.", 3444.0, 18.5, 2, 415.0, "https://www.auto-data.net/images/f109/Toyota-Land-Cruiser-J300.jpg", "Toyota", "Land Cruiser", 85000.0, 190.0, null, null, null, 250.0, 650.0, 1, 2520.0, 2003 },
                    { 221, 8.5999999999999996, 5, "Blue", 14, "The BMW E91, introduced in 2005, is a versatile and stylish wagon that embodies BMW's commitment to combining performance, practicality, and dynamic design. With its sleek yet functional design, the E91 carries BMW's iconic styling cues. The balanced proportions, clean lines, and attention to detail create an appearance that is both elegant and athletic. Inside the E91, the cabin offers a harmonious blend of comfort and utility. High-quality materials, ergonomic design, and ample cargo space make it a practical choice for drivers seeking versatility without sacrificing luxury. The driver-centric layout ensures an engaging and intuitive driving experience. Under the hood, the E91 presents a range of engine options, each delivering a balance between power and efficiency. The vehicle's suspension system and responsive steering contribute to a dynamic and enjoyable driving dynamic, whether navigating city streets or highways. While the E91's technology might not be as advanced as that of newer models, it offers essential features to enhance the driving experience, including connectivity and entertainment options. As a part of BMW's lineup, the E91 reflects the brand's dedication to producing vehicles that offer driving pleasure without compromising on functionality. It's a desirable choice for drivers who seek a wagon that delivers both performance and practicality. In conclusion, the 2005 BMW E91 stands as a testament to BMW's commitment to engineering vehicles that offer a blend of performance and versatility. With its sleek design, functional interior, and engaging driving dynamics, the E91 continues to capture the essence of BMW's philosophy of creating vehicles that provide the best of both worlds – style and practicality.", 1995.0, 8.0999999999999996, 1, 163.0, "https://www.auto-data.net/images/f41/BMW-3-Series-Touring-E91.jpg", "BMW", "E91", 8200.0, 140.0, null, null, null, 223.0, 340.0, 2, 1510.0, 2005 },
                    { 222, 6.7999999999999998, 7, "Yellow", 14, "The Dodge Ram, introduced in 2005, is a rugged and capable full-size pickup truck that embodies Dodge's commitment to power, utility, and distinctive design. With its bold and muscular design, the Ram carries Dodge's signature styling cues. The robust grille, chiseled lines, and imposing stance create an appearance that exudes strength and capability. Inside the Ram, the cabin offers a functional and spacious environment. Utilitarian materials, comfortable seating, and a layout designed for practicality make it well-suited for both work and everyday driving. The emphasis on functionality extends to the controls and features, prioritizing ease of use. Under the hood, the Ram presents a range of powerful engine options, delivering impressive towing and hauling capabilities. The truck's sturdy chassis and suspension system contribute to a stable and confident ride, whether carrying heavy loads or navigating rough terrains. While the 2005 Ram's technology might not match the advanced features of modern trucks, it provides essential amenities to enhance both work and leisure, including entertainment and connectivity options. As part of Dodge's lineup, the Ram reflects the brand's reputation for producing vehicles that cater to drivers who demand performance and versatility. It's a sought-after choice for truck enthusiasts and drivers seeking a dependable and robust pickup truck. In conclusion, the 2005 Dodge Ram stands as a testament to Dodge's commitment to engineering trucks that offer power and utility. With its commanding design, practical interior, and robust capabilities, the Ram continues to uphold Dodge's legacy of creating vehicles that can tackle tough tasks and deliver a dependable performance in various scenarios.", 5657.0, 18.100000000000001, 2, 345.0, "https://www.auto-data.net/images/f46/Dodge-Ram-1500-III-DR-DH.jpg", "Dodge", "Ram", 3700.0, 330.0, null, null, null, 250.0, 529.0, 1, 1880.0, 2005 },
                    { 223, 11.1, 4, "Red", 14, "The Dacia Sandero II Stepway, introduced in 2013, is a practical and affordable compact crossover that embodies Dacia's commitment to simplicity, value, and functionality. With its rugged and utilitarian design, the Sandero II Stepway carries Dacia's straightforward styling cues. The elevated ground clearance, protective cladding, and distinctive front grille create an appearance that balances practicality and adventure. Inside the Sandero II Stepway, the cabin offers a straightforward and functional layout. Basic yet durable materials, ergonomic seating, and practical storage solutions make it well-suited for drivers seeking a no-frills approach to driving. Under the hood, the Sandero II Stepway presents efficient engine options, delivering dependable performance for everyday commuting and urban driving. The crossover's slightly raised suspension system provides enhanced ground clearance and a comfortable ride, suitable for varied road conditions. While the 2013 Sandero II Stepway's technology might not be as advanced as that of modern crossovers, it offers essential features to enhance the driving experience, focusing on practicality rather than luxury. As part of Dacia's lineup, the Sandero II Stepway reflects the brand's reputation for producing vehicles that prioritize value and functionality. It's a practical choice for drivers seeking a budget-friendly crossover that meets basic transportation needs. In conclusion, the 2013 Dacia Sandero II Stepway stands as a testament to Dacia's philosophy of providing affordable and straightforward vehicles. With its rugged design, functional interior, and dependable performance, the Sandero II Stepway continues to uphold Dacia's legacy of creating vehicles that offer practicality and value for budget-conscious drivers.", 2999.0, 6.7000000000000002, 2, 90.0, "https://cdn3.focus.bg/autodata/i/dacia/sandero/sandero-ii-stepway/large/675829b961ab0a61241270896e202b87.jpg", "Dacia", "Sandero II Stepway", 9999.0, 199.0, null, null, null, 170.0, 135.0, 2, 1023.0, 2013 },
                    { 224, 10.800000000000001, 3, "Black", 14, "The Mercedes-Benz A-Class (W168), introduced in 1999, is a compact car that embodies Mercedes-Benz's commitment to innovation, versatility, and safety. With its distinctive design, the A-Class (W168) showcases Mercedes-Benz's approach to creating compact vehicles that offer practicality without sacrificing style. The unique tall body design and compact dimensions create an appearance that maximizes interior space while remaining compact and agile. Inside the A-Class (W168), the cabin offers a surprisingly roomy and flexible environment. Smart space utilization, ergonomic seating, and practical storage solutions make it suitable for both urban driving and longer journeys. The driver-centric layout reflects Mercedes-Benz's dedication to creating user-friendly interiors. Under the hood, the A-Class (W168) presents a range of engine options, delivering efficient performance for various driving scenarios. The vehicle's suspension system provides a balanced and comfortable ride, suitable for navigating city streets and highways. While the 1999 A-Class (W168) might not feature the same level of technology as more recent Mercedes-Benz models, it offers essential amenities to enhance the driving experience, focusing on comfort and convenience. As part of Mercedes-Benz's lineup, the A-Class (W168) reflects the brand's commitment to engineering vehicles that cater to diverse driver needs. It's a practical choice for drivers seeking a compact car that offers Mercedes-Benz's reputation for quality and safety. In conclusion, the 1999 Mercedes-Benz A-Class (W168) stands as a testament to Mercedes-Benz's philosophy of creating vehicles that combine innovation and functionality. With its distinctive design, versatile interior, and emphasis on safety, the A-Class (W168) continues to capture the essence of Mercedes-Benz's dedication to producing vehicles that adapt to the evolving needs of drivers.", 1598.0, 10.199999999999999, 2, 102.0, "https://static-eu.cargurus.com/images/forsale/2023/05/16/15/02/2003_mercedes-benz_a-class-pic-3974413017599453644-1024x768.jpeg", "Mercedes-Benz", "A-Class (W168)", 4400.0, 110.0, null, null, null, 180.0, 150.0, 2, 1135.0, 1999 },
                    { 225, 8.0999999999999996, 1, "Grey", 14, "The Audi A4, introduced in 2011, represents Audi's commitment to luxury, performance, and innovative design. With a sleek and modern exterior, the A4 boasts Audi's signature aesthetic, characterized by clean lines, a distinctive grille, and balanced proportions. Inside the cabin, high-quality materials, meticulous craftsmanship, and advanced technology come together to create a refined and comfortable environment. The A4 offers a range of engine options that balance power and efficiency, while its suspension and steering provide a dynamic driving experience. Equipped with advanced safety and technology features like adaptive cruise control, automatic emergency braking, and lane departure warning, the 2011 A4 prioritizes driver confidence and occupant protection. As a part of Audi's lineup, the A4 embodies the brand's commitment to luxury and engineering excellence. It remains a sought-after choice for those seeking a compact luxury sedan that marries style, performance, and technological innovation seamlessly.", 1798.0, 7.4000000000000004, 2, 170.0, "https://www.auto-data.net/images/f93/Audi-A4-B8-8K-facelift-2011.jpg", "Audi", "A4", 12400.0, 180.0, null, null, null, 230.0, 320.0, 2, 1430.0, 2011 },
                    { 226, 3.6000000000000001, 1, "Black", 14, "The Porsche Panamera G2, introduced in 2019, is a luxury sports sedan that showcases Porsche's dedication to performance, innovation, and refined design. With its sleek and athletic design, the Panamera G2 embodies Porsche's iconic styling cues. The sweeping lines, distinctive headlights, and wide stance create an appearance that seamlessly combines elegance with sportiness. Inside the Panamera G2, the cabin offers a luxurious and driver-focused environment. High-quality materials, meticulous attention to detail, and cutting-edge technology create an interior that caters to both driver and passenger satisfaction. The intuitive infotainment system and driver assistance features enhance the driving experience. Under the hood, the Panamera G2 presents a range of powerful engine options, delivering exhilarating acceleration and impressive handling characteristics. The sedan's advanced suspension system and responsive steering contribute to a dynamic and engaging driving experience. In terms of safety and technology, the 2019 Panamera G2 is equipped with a suite of advanced features, including adaptive cruise control, lane keeping assist, and automatic emergency braking. These systems work together to enhance driver confidence and occupant protection. As part of Porsche's lineup, the Panamera G2 reflects the brand's commitment to engineering excellence and driving pleasure. It's a coveted choice for drivers seeking a luxury sports sedan that offers a blend of style, performance, and cutting-edge technology. In conclusion, the 2019 Porsche Panamera G2 stands as a testament to Porsche's philosophy of creating vehicles that deliver both luxury and performance. With its striking design, opulent interior, and advanced safety and technology features, the Panamera G2 continues to capture the essence of Porsche's dedication to providing an exceptional driving experience.", 3996.0, 14.4, 2, 550.0, "https://www.auto-data.net/images/f15/file8561600.jpg", "Porsche", "Panamera G2", 175000.0, 100.0, null, null, null, 306.0, 770.0, 1, 1995.0, 2019 },
                    { 227, 4.4000000000000004, 2, "Black", 19, "The BMW E92 M3 is a high-performance sports coupe known for its powerful V8 engine, precise handling, and iconic design. With a perfect blend of luxury and exhilaration, it remains a favorite among car enthusiasts seeking a thrilling driving experience.", 4361.0, 18.5, 2, 450.0, "https://collectingcars.imgix.net/007137/19-ww-8.jpg?w=1263&fit=fillmax&crop=edges&auto=format,compress&cs=srgb&q=85", "BMW", "E92 M3", 66500.0, 600.0, null, null, null, 250.0, 440.0, 1, 1530.0, 2010 },
                    { 228, 3.6000000000000001, 2, "Black", 18, "The Mercedes CLS 63 AMG is a luxury four-door coupe that combines elegance with blistering performance. Powered by a potent V8 engine, it offers a comfortable yet exhilarating driving experience, setting new standards for high-end performance cars.", 5461.0, 14.4, 2, 585.0, "https://citycarrentals.ca/wp-content/uploads/2018/02/mercedes-benz-cls-63-amg-black-3.jpg", "Mercedes-Benz", "CLS 63 AMG", 67500.0, 680.0, null, null, null, 250.0, 800.0, 1, 1945.0, 2014 },
                    { 229, 5.0999999999999996, 2, "Black", 19, "The Audi S5 is a dynamic and sleek sports coupe, featuring a turbocharged V6 engine and Quattro all-wheel drive. Its blend of performance, comfort, and cutting-edge technology make it a compelling choice for driving enthusiasts with a taste for luxury.", 2999.0, 10.699999999999999, 2, 333.0, "https://i.pinimg.com/originals/4f/23/28/4f2328613a9577fef6f77eee198e5f65.jpg", "Audi", "S5", 64000.0, 510.0, null, null, null, 250.0, 440.0, 1, 1745.0, 2012 },
                    { 230, 1.1000000000000001, 1, "Black", 14, "TestDesc1", 444.0, 11.0, 1, 333.0, "https://images.drive.com.au/driveau/image/upload/t_wp-default/v1/cms/uploads/jjslyagf8e3gcny2doyy", "TestMake1", "TestModel1", 1234.0, 111.0, null, null, null, 123.0, 333.0, 1, 1234.0, 2011 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CategoryId", "DealerId", "Description", "ImageUrl", "Name", "Price", "PurchaserId" },
                values: new object[,]
                {
                    { 98, 1, 14, "The BMW M52 is an inline-six engine that was part of BMW's M52 engine family. Introduced in the mid-1990s, the M52 engine was a significant advancement in BMW's lineup. It encompassed both 2.5-liter and 2.8-liter displacement variants. Known for its smooth and refined performance, the M52 engine utilized technologies like Double-VANOS variable valve timing, which optimized power delivery across different RPM ranges. With its aluminum block and cylinder head, the M52 achieved a balance between durability and weight reduction. The M52 engine found its place in various BMW models, contributing to their sporty and dynamic driving characteristics. Its torque delivery, combined with the efficient VANOS system, offered enhanced responsiveness and fuel efficiency. This engine played a crucial role in BMW's reputation for engineering excellence and driving pleasure. The M52's legacy continues to influence subsequent engine designs, contributing to BMW's commitment to delivering engaging and powerful driving experiences.", "https://www.bimmerarchive.org/images/5177-114-bmw-m52@2x.jpg", "BMW M52", 15000.0, null },
                    { 99, 1, 14, "The BMW M54 is an inline-six engine that belongs to BMW's M54 engine family. Introduced in the late 1990s, the M54 engine represented a significant evolution in BMW's powertrain technology and performance capabilities. The M54 engine was renowned for its smooth power delivery and refined performance. It featured technologies like Double-VANOS variable valve timing, which optimized both power output and fuel efficiency across varying driving conditions. The aluminum block and cylinder head construction helped balance durability with weight reduction. With a range of displacements, including 2.2-liter, 2.5-liter, and 3.0-liter variants, the M54 engine found application in various BMW models. Its performance characteristics contributed to the sporty and dynamic driving experiences that BMW vehicles are known for. One notable feature of the M54 engine was its adaptability to different driving demands. It offered a balance of low-end torque and high-end power, ensuring a responsive driving experience in a variety of situations. The M54 engine's influence extended beyond its initial production years, contributing to BMW's reputation for engineering excellence and driving enjoyment. Its legacy continues to impact subsequent generations of BMW engines, showcasing the brand's commitment to innovative powertrain technology.", "https://i.ytimg.com/vi/4yw4_1bI63I/maxresdefault.jpg", "BMW M54", 13000.0, null },
                    { 100, 1, 14, "The BMW N54 is a twin-turbocharged inline-six engine that emerged as a significant milestone in BMW's engine lineup. Introduced in the mid-2000s, the N54 engine represented a departure from traditional naturally aspirated designs, embracing forced induction for enhanced performance. With its twin-turbocharging setup, the N54 engine achieved impressive power output and torque. The turbochargers provided quicker throttle response and increased power across a broad RPM range. This allowed for exhilarating acceleration and dynamic driving experiences. The N54 engine was fitted with direct fuel injection, which improved fuel efficiency and combustion efficiency. The aluminum-alloy block and cylinder head helped reduce weight without compromising durability. A notable feature of the N54 engine was its adaptability to aftermarket tuning and modifications. Enthusiasts found the engine's design to be receptive to performance enhancements, contributing to its popularity in the tuning community. The N54 engine found its place in various BMW models, including performance-oriented vehicles. Its introduction marked a shift in BMW's approach to achieving higher power levels while maintaining efficiency. The legacy of the N54 engine continues to influence BMW's engine development, particularly in the realm of turbocharging and direct injection. This engine highlighted BMW's commitment to pushing boundaries in pursuit of power, performance, and driving pleasure.", "https://images-stag.jazelc.com/uploads/theautopian-m2en/335i-engine-bay.jpg", "BMW N54", 17000.0, null },
                    { 101, 2, 14, "The S tronic, also known as DSG (Direct-Shift Gearbox), is an innovative dual-clutch automatic transmission technology developed by Audi. This transmission system combines the convenience of an automatic transmission with the quick and precise gear changes of a manual gearbox. The S tronic/DSG transmission utilizes two separate clutches and gear sets, one for even-numbered gears and the other for odd-numbered gears. This design allows for seamless gear changes without the interruption of power delivery, resulting in lightning-fast shifts and improved acceleration. Drivers can experience the S tronic/DSG transmission in two primary modes: automatic mode and manual mode. In automatic mode, the transmission optimizes gear changes based on driving conditions, while manual mode enables drivers to take control of gear selection using paddle shifters or the gear lever. The benefits of the S tronic/DSG transmission include improved fuel efficiency, rapid gear changes, and enhanced driving dynamics. Its ability to predict gear changes and pre-select the next gear contributes to a smoother and more responsive driving experience. Audi has incorporated the S tronic/DSG technology across various models in its lineup, showcasing the brand's commitment to offering cutting-edge transmission solutions that cater to both performance and efficiency. This transmission technology has redefined the driving experience, providing a seamless blend of convenience and sportiness for Audi enthusiasts and drivers.", "https://static.wixstatic.com/media/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png/v1/fill/w_640,h_400,al_c,q_85,usm_4.00_1.00_0.00,enc_auto/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png", "S tronic (DSG) Audi", 19000.0, null },
                    { 102, 2, 14, "Tiptronic is a transmission technology developed by Audi that offers drivers the flexibility of both automatic and manual gear shifting. Introduced as a response to the demand for more control over gear changes, the Tiptronic system combines the convenience of an automatic transmission with the option to manually select gears. In Tiptronic-equipped vehicles, drivers can choose between fully automatic mode and manual mode. In automatic mode, the transmission shifts gears automatically based on driving conditions. In manual mode, drivers have the ability to manually select gears using either the gear lever or paddle shifters mounted on the steering wheel. The Tiptronic system empowers drivers to take control of gear changes when desired, enhancing the driving experience and allowing for a more engaging ride. This feature is particularly useful when driving on winding roads or seeking a more responsive acceleration. Tiptronic technology caters to both efficiency and sportiness. It optimizes gear changes based on throttle input, speed, and road conditions, contributing to improved fuel economy while maintaining a dynamic driving feel. Audi has integrated the Tiptronic technology across a range of its vehicles, providing a versatile solution for drivers who desire a balance between automatic convenience and manual control. This transmission system underscores Audi's commitment to innovation and delivering driving experiences tailored to individual preferences.", "https://www.audi-technology-portal.de/en/download?file=813", "Tiptronic Audi", 21000.0, null },
                    { 103, 2, 14, "The DSG (Direct Shift Gearbox) is an advanced dual-clutch automatic transmission technology developed by Volkswagen Group. This innovative transmission system combines the convenience of an automatic transmission with the precise and rapid gear changes of a manual gearbox. The DSG transmission employs two separate clutches and gear sets, one for odd-numbered gears and the other for even-numbered gears. This dual-clutch setup enables lightning-fast gear changes without interrupting the power flow, resulting in seamless acceleration and enhanced driving dynamics. Drivers can experience the DSG transmission in two primary modes: automatic mode and manual mode. In automatic mode, the transmission optimizes gear changes based on driving conditions. In manual mode, drivers can actively engage in gear selection using paddle shifters or the gear lever. The advantages of the DSG transmission include improved fuel efficiency, quick gear changes, and a more responsive driving experience. Its predictive shifting and pre-selection of the next gear contribute to a smoother and dynamic ride. Volkswagen Group has integrated the DSG technology across various brands under its umbrella, showcasing the commitment to delivering cutting-edge transmission solutions that cater to both efficiency and performance. The DSG transmission has redefined driving experiences, offering the best of both automatic and manual shifting for driving enthusiasts and those seeking a refined ride alike.", "https://b1936034.smushcdn.com/1936034/wp-content/uploads/2020/01/DL382.png?lossy=1&strip=1&webp=1", "DSG (Direct Shift Gearbox) VW", 9150.0, null },
                    { 104, 2, 14, "The 6-speed manual transmission in Volkswagen vehicles is a traditional gearbox that allows drivers to manually select gears for a more engaging and hands-on driving experience. With a 6-speed manual transmission, drivers have direct control over gear changes using the gear lever and clutch pedal. This type of transmission provides a closer connection between the driver and the vehicle, allowing for precise gear selection to match driving conditions and preferences. The 6-speed manual transmission is known for its simplicity, durability, and lower maintenance costs compared to automatic transmissions. It offers a sense of control and engagement that appeals to driving enthusiasts who enjoy shifting gears themselves. Volkswagen offers 6-speed manual transmissions in various models to cater to drivers who prefer a more traditional driving experience. This transmission option underscores Volkswagen's commitment to providing choices that align with drivers' preferences, whether they prioritize performance, engagement, or a combination of both.", "https://images.hgmsites.net/hug/volkswagen_100708189_h.jpg", "6-speed Manual VW", 7500.0, null },
                    { 105, 3, 14, "Mercedes-Benz AMG Ceramic Composite Brakes (CCB) are high-performance braking systems developed by Mercedes-AMG, the performance division of Mercedes-Benz. These advanced brakes are designed to provide exceptional stopping power, reduced fade, and improved performance under demanding driving conditions. The CCB system utilizes ceramic composite materials in the construction of the brake discs. This material offers several advantages, including higher heat resistance, reduced weight, and improved durability compared to traditional iron brake discs. As a result, CCB brakes are highly effective in dissipating heat generated during intense braking, minimizing the risk of brake fade. One of the main benefits of CCB brakes is their superior stopping power, even in high-speed and track-oriented driving scenarios. This technology provides consistent and reliable performance, allowing drivers to confidently tackle challenging conditions without compromising on brake responsiveness. Furthermore, CCB brakes contribute to reducing the unsprung weight of the vehicle, which can have a positive impact on handling, ride quality, and overall performance. This reduction in weight improves the vehicle's agility and responsiveness, enhancing the driving experience. Mercedes-Benz AMG Ceramic Composite Brakes reflect the brand's commitment to engineering excellence and high-performance driving. This braking technology is often found in Mercedes-AMG models and represents a premium option for enthusiasts and drivers who demand the utmost in braking performance for both everyday driving and track experiences.", "https://tro-nik.com/wp-content/uploads/2021/07/Mercedes-Benz-W167-brakes.-pic.-1.jpg", "Mercedes-Benz AMG Ceramic Composite Brakes (CCB)", 4500.0, null },
                    { 106, 3, 14, "Mercedes-Benz AMG Performance Brakes are high-performance braking systems developed by Mercedes-AMG, the performance division of Mercedes-Benz. These brakes are designed to provide enhanced stopping power, improved heat management, and superior performance to meet the demands of high-performance driving. The AMG Performance Brakes feature larger brake discs and more robust brake calipers compared to standard braking systems. This design increases the braking surface area and improves heat dissipation, making the brakes more resistant to fading during aggressive driving or track use. The brake calipers of the AMG Performance Brakes are often designed with multiple pistons to ensure even and effective distribution of braking force across the brake pads and discs. This results in consistent and reliable braking performance, even under extreme conditions. The AMG Performance Brakes are engineered to offer improved pedal feel and responsiveness, allowing drivers to modulate braking force with precision. This feature is especially valuable for high-performance vehicles that require quick and controlled deceleration. These brakes are often paired with advanced brake pad compounds optimized for performance driving. These pads provide excellent stopping power while maintaining a good balance between noise, dust, and overall brake performance. Mercedes-Benz AMG Performance Brakes reflect the brand's dedication to delivering exceptional performance and engineering excellence. This braking technology is a key component in enhancing the driving experience of Mercedes-AMG models, providing the stopping power and confidence required for spirited driving and track use.", "https://www.kunzmann.de/image/replacement-and-wearparts-brake-equipment-brake-di-29847-xl.jpg", "Mercedes-Benz AMG Performance Brakes", 8700.0, null },
                    { 107, 4, 14, "Adaptive M Suspension is an advanced suspension system developed by BMW's M division. This technology is designed to provide drivers with the ability to adjust the suspension characteristics to suit different driving conditions and preferences. The Adaptive M Suspension system utilizes electronically controlled dampers that can adjust their stiffness in real-time. This means that the suspension can adapt to changes in road conditions, driving dynamics, and driver inputs. The system takes into account factors like vehicle speed, steering angle, and acceleration to optimize the suspension settings for comfort and performance. Drivers can often select different driving modes, such as Comfort, Sport, and Sport+, to adjust the suspension's behavior. In Comfort mode, the suspension provides a smoother and more comfortable ride, ideal for daily commuting or long-distance travel. In Sport mode, the suspension firms up to improve handling and responsiveness, enhancing the driving experience on twisty roads or more dynamic driving situations. The Adaptive M Suspension technology contributes to improved handling, reduced body roll, and enhanced stability during cornering. It offers the best of both worlds by allowing drivers to choose between a more comfortable ride or a more engaging and sporty driving experience. This technology is often found in BMW M models, reflecting the brand's commitment to performance and driving pleasure. The Adaptive M Suspension is a crucial component in creating a well-rounded driving experience that caters to a variety of driving scenarios and preferences.", "https://www.bmw.ie/en/shop/ls/images/connected-drive/xl/VDC_Offer/images/Adaptives_M_Fahrwerk_902x508.jpg", "Adaptive M Suspension", 16000.0, null },
                    { 108, 4, 14, "Audi Dynamic Ride Control (DRC) is an advanced suspension technology developed by Audi to enhance handling, stability, and ride comfort in high-performance vehicles. This innovative system is designed to minimize body roll during cornering and provide a smoother ride by effectively managing the damping forces of the suspension. DRC uses a complex hydraulic system to connect diagonally opposed shock absorbers or dampers. This hydraulic connection allows the dampers to work in unison, counteracting body roll and maintaining optimal tire contact with the road. When the vehicle enters a corner, the DRC system automatically adjusts the damping forces to provide a level and composed ride. One of the key advantages of DRC is its ability to provide a stable and controlled ride even under aggressive driving conditions. It reduces body movements, allowing the vehicle to maintain better stability during dynamic maneuvers, which can be particularly beneficial on winding roads or on the track. DRC also contributes to ride comfort by minimizing pitch and roll motions, resulting in a smoother and more controlled ride quality. This technology strikes a balance between performance and comfort, making it well-suited for drivers who seek both spirited driving experiences and everyday comfort. Audi Dynamic Ride Control is often found in high-performance Audi models, highlighting the brand's commitment to delivering a dynamic and engaging driving experience. This suspension technology is a testament to Audi's dedication to innovation and engineering excellence, offering a sophisticated solution for drivers who demand precise handling and driving pleasure.", "https://audimediacenter-a.akamaihd.net/system/production/media/84119/images/7e6b0f01721320da20eade10395735ebf282c6a1/A1912000_x500.jpg?1582560882", "Audi Dynamic Ride Control (DRC)", 9500.0, null },
                    { 109, 5, 14, "M Sport Seats are a premium seating option offered by BMW's M division, designed to provide enhanced comfort, support, and a sporty driving experience. These seats are a key component in creating a more engaging and dynamic driving environment while offering a comfortable ride for both driver and passengers. M Sport Seats often feature a combination of high-quality materials, ergonomic design, and adjustable features. They are designed to provide improved lateral support during spirited driving, helping to keep the driver and passengers securely in place during cornering and dynamic maneuvers. The seats are usually contoured to match the body's natural posture, providing a snug fit that reduces fatigue during long drives. The sporty bolstering and padding contribute to the feeling of being connected to the vehicle, enhancing the driving experience and promoting a more engaged and responsive driving style. In addition to their performance-oriented design, M Sport Seats often come with various adjustments, such as height, tilt, and lumbar support, allowing drivers to find the optimal seating position for comfort and control. M Sport Seats are typically available as an option in a range of BMW models, showcasing the brand's commitment to delivering driving pleasure and a premium interior experience. These seats reflect BMW's dedication to engineering excellence and the desire to provide enthusiasts and drivers with the means to enjoy every aspect of their driving journey.", "https://trimtechnik.net/assets/images/content/129/bmw_e46_cab_m_sport_coral_red_leather_003__1000.jpg", "M Sport Seats", 123456789.0, null },
                    { 110, 5, 14, "The Audi RS4 B7 Recaro Seats are high-performance seats designed for the Audi RS4 B7 model. These seats are a collaboration between Audi and Recaro, a renowned manufacturer of racing and performance seats. They are specifically engineered to provide exceptional support, comfort, and a sporty driving experience. The RS4 B7 Recaro Seats often feature a combination of premium materials, ergonomic design, and aggressive bolstering. They are built to hold the driver and passengers securely in place during dynamic driving maneuvers, reducing lateral movement and ensuring maximum control. The contoured shape of the seats is designed to match the body's natural posture, providing a snug and supportive fit. This not only contributes to comfort during long drives but also enhances the driving experience by promoting a more connected and engaged feeling with the vehicle. RS4 B7 Recaro Seats are equipped with various adjustments, including height, tilt, and lumbar support, allowing drivers to customize their seating position for optimal comfort and control. The seats are often finished in high-quality materials that reflect the luxury and performance-oriented nature of the Audi RS4 B7. These seats are a distinctive feature of the Audi RS4 B7, highlighting the model's focus on performance and driving pleasure. The collaboration between Audi and Recaro underscores Audi's commitment to delivering an exceptional driving environment, tailored to the needs of enthusiasts who seek both comfort and sportiness.", "https://bringatrailer.com/wp-content/uploads/2019/01/1547765401b064a6f7f52ae3fPhoto-Jan-10-6-09-19-PM.jpg", "Audi RS4 B7 Recaro Seats", 1150.0, null },
                    { 111, 6, 14, "The Carbon Rear Wing or Rear Spoiler is a performance-enhancing aerodynamic component commonly found on high-performance and sports cars. Made from lightweight carbon fiber material, this wing is designed to improve vehicle stability, handling, and downforce by optimizing the airflow over the rear of the vehicle. The carbon rear wing is strategically positioned at the back of the vehicle to disrupt the airflow and create a high-pressure zone above it and a low-pressure zone below it. This pressure differential generates downforce, which helps improve traction and stability, especially at high speeds and during aggressive driving maneuvers. The use of carbon fiber in the construction of the rear wing offers several advantages. Carbon fiber is strong yet lightweight, which means the wing can provide the necessary aerodynamic benefits without adding excessive weight to the vehicle. This is crucial for maintaining a favorable power-to-weight ratio and overall performance. Carbon rear wings are often adjustable, allowing drivers to fine-tune the amount of downforce generated based on driving conditions. In some cases, the wing's angle can be modified to increase downforce for track use or reduce drag for highway cruising. This aerodynamic component is a key feature in the design of performance-oriented vehicles, enhancing both aesthetics and driving dynamics. The carbon rear wing showcases the brand's commitment to engineering excellence and performance optimization, offering enthusiasts and drivers a means to achieve better handling and a more exhilarating driving experience.", "https://luethen-motorsport.com/media/image/9f/42/ed/mercedes-c63-amg-coupe-c205-carbon-heckflugel-heckspoiler-ac2051200_600x600.jpg", "Carbon rear wing / rear spoiler", 600.0, null },
                    { 112, 6, 14, "LED Angel Eyes, also referred to as Halo Rings, are a distinctive lighting feature commonly found in modern vehicles, designed to enhance visibility, aesthetics, and recognition. These rings of LED lights are often positioned around the headlights and emit a bright and distinct white light. The LED Angel Eyes serve multiple purposes. Primarily, they provide an instantly recognizable and iconic look to a vehicle's front end, adding a touch of modernity and sophistication. They are especially prominent at night or in low-light conditions, contributing to a vehicle's visual appeal and presence on the road. From a functional standpoint, LED Angel Eyes can serve as daytime running lights, improving the vehicle's visibility to other road users. They create a recognizable light signature that helps drivers stand out and be noticed during the day, enhancing safety on the road. The use of LEDs in the construction of Angel Eyes offers several advantages. LEDs are energy-efficient, have a longer lifespan, and produce a more focused and intense light output compared to traditional halogen bulbs. LED Angel Eyes are often associated with premium and high-end vehicles, showcasing a commitment to innovative design and technology. They reflect the brand's attention to detail, aesthetics, and safety, all while adding a touch of visual flair that captures the essence of modern automotive lighting trends.", "https://nastarta-shop.com/wp-content/uploads/2022/02/led_halo.jpg", "LED Angel Eyes (white)", 2200.0, null },
                    { 113, 6, 14, "LCI LED Headlights are a lighting upgrade available for the BMW F10 M5 and 5 Series vehicles, offering improved illumination, energy efficiency, and modern styling. LCI stands for \"Life Cycle Impulse,\" indicating a mid-cycle refresh or update to a vehicle's design and features. These headlights feature Light Emitting Diode (LED) technology, which provides several benefits over traditional halogen or even xenon headlights. LED headlights offer a brighter and more focused beam, enhancing nighttime visibility and road illumination. They also consume less energy, contributing to better fuel efficiency and reduced strain on the vehicle's electrical system. The LED technology used in LCI LED Headlights allows for more precise control of light distribution. This often includes adaptive features that adjust the intensity and direction of the light based on factors such as vehicle speed, steering angle, and road conditions. Adaptive LED headlights can improve safety by providing better visibility around curves and corners. Visually, LCI LED Headlights offer a modern and distinctive appearance. The bright and crisp light produced by the LEDs enhances the vehicle's overall aesthetics and road presence. The LED elements are often arranged in eye-catching patterns, adding a touch of sophistication to the vehicle's front end. LCI LED Headlights are often associated with luxury and performance vehicles, such as the BMW F10 M5 and 5 Series. They reflect the brand's commitment to innovation, safety, and design excellence, offering owners an enhanced driving experience with improved visibility and a stylish lighting signature.", "https://bimmerplug.com/cdn/shop/products/LCI-LED-Headlights-BMW-F10-M5-5-Series-2_800x.jpg?v=1655094531", "LCI LED Headlights - BMW F10 M5 & 5 Series", 800.0, null },
                    { 114, 7, 14, "The Soundstage + Subwoofer System designed for the BMW 3-Series is an advanced audio upgrade that aims to provide an immersive and high-quality in-car audio experience. This system enhances the vehicle's sound system by offering improved clarity, depth, and bass response, transforming the cabin into a premium listening environment. The \"Soundstage\" aspect of the system refers to the technology used to create a more realistic and enveloping sound experience. This technology often involves strategically placing speakers throughout the vehicle to mimic the sensation of sound coming from different directions, similar to a live performance. The result is an audio environment that makes music feel more expansive and engaging. The addition of a subwoofer is a crucial component of this system. A subwoofer is responsible for reproducing deep and low-frequency bass sounds that regular speakers might struggle to deliver. The subwoofer adds a rich and impactful bass element to the audio, enhancing the overall quality of music playback. The Soundstage + Subwoofer System for the BMW 3-Series is typically designed to seamlessly integrate with the vehicle's existing audio components. This ensures that the upgraded audio system maintains compatibility with the vehicle's technology and controls. This audio upgrade is often tailored to the specific acoustics of the BMW 3-Series cabin, ensuring that the sound quality is optimized for the vehicle's interior. With improved clarity, a more immersive soundstage, and enhanced bass, the system delivers a premium audio experience that complements the driving journey and elevates the enjoyment of music and entertainment.", "https://integralaudio.com/media/catalog/product/cache/429f869d5d4fbd3e94a8a75b24ebea81/f/3/f30.soundstage.complete_2_1.jpg", "Soundstage + Subwoofer System for BMW 3-Series", 2599.0, null }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CategoryId", "DealerId", "Description", "ImageUrl", "Name", "Price", "PurchaserId" },
                values: new object[,]
                {
                    { 115, 7, 14, "The Performance Chip for the Audi A3 1.9 TDI with 110 horsepower is a tuning modification designed to enhance the engine's performance and overall driving experience. This chip, also known as an ECU (Engine Control Unit) remap, involves reprogramming the engine's computer to optimize various parameters and unlock additional power and torque. The stock ECU settings in vehicles are often calibrated to meet a variety of factors, including emissions regulations, fuel economy, and drivability. Performance chips allow for customization of these settings, focusing on improving power output, throttle response, and potentially fuel efficiency. When applied to the Audi A3 1.9 TDI with 110 horsepower, a performance chip can result in noticeable performance gains. These may include increased horsepower, torque, and acceleration. Throttle response and overall engine responsiveness may also be improved, providing a more engaging and dynamic driving experience. It's important to note that installing a performance chip should be done carefully by professionals who understand the intricacies of ECU tuning. Additionally, the choice of chip and the extent of the tuning should be aligned with the vehicle's existing condition and usage. Done properly, a performance chip can offer significant benefits to enthusiasts seeking a more spirited driving experience from their Audi A3 1.9 TDI.", "https://www.ptronic.com/files/images/boitiers/12/1.jpg", "Performance chip Audi A3 1.9 TDI 110hp", 300.0, null },
                    { 116, 7, 14, "The First Aid Kit is an essential safety item commonly found in vehicles, designed to provide basic medical supplies and assistance in the event of minor injuries or emergencies. It contains a range of items that can be used to provide immediate medical care before professional help arrives.\r\n\r\nA typical first aid kit for a vehicle may include items such as adhesive bandages, sterile gauze pads, adhesive tape, antiseptic wipes, scissors, tweezers, disposable gloves, and pain relief medication. Some kits may also include a CPR face shield, instant cold packs, and a basic first aid guide.\r\n\r\nThe first aid kit is designed to address common injuries like cuts, scrapes, burns, and minor sprains. It can prove invaluable in situations where immediate medical attention is needed, such as during a road trip, long drives, or in remote areas where medical facilities are not easily accessible.\r\n\r\nCarrying a first aid kit in a vehicle is a proactive safety measure that reflects responsible driving and consideration for the well-being of passengers and fellow road users. It provides a means to provide initial care and potentially minimize the impact of injuries until professional medical help can be obtained.", "https://cdn.autodoc.de/thumb?id=17857567&m=1&n=0&lng=bg&ccf=94077841", "First aid kit", 60.0, null },
                    { 117, 6, 14, "BBS CC-R Rims are premium aftermarket wheels designed to enhance the performance, aesthetics, and overall presence of vehicles. BBS is a renowned manufacturer known for producing high-quality wheels with innovative design and engineering. The CC-R series from BBS reflects a commitment to lightweight construction, durability, and style. These rims are often made from advanced materials such as aluminum alloy to reduce weight while maintaining structural integrity. The reduced unsprung weight contributes to improved handling, acceleration, and braking performance. BBS CC-R Rims are designed with aesthetics in mind. They often feature sleek and modern designs that add a touch of sportiness and sophistication to a vehicle's appearance. The attention to detail in the design process ensures that the rims complement the vehicle's lines and character. The choice of aftermarket rims like BBS CC-R can also impact the vehicle's stance and overall aesthetics. Different sizes, offsets, and finishes are available to suit various vehicle models and personal preferences. BBS is known for its rigorous manufacturing processes, quality control, and adherence to safety standards. BBS CC-R Rims are tested and engineered to meet high standards of performance and durability, making them a reliable and popular choice among automotive enthusiasts. The addition of BBS CC-R Rims not only enhances the visual appeal of a vehicle but also contributes to improved performance and driving experience, making them a sought-after upgrade for those who seek both style and functionality in their wheels.", "https://www.felgenoutlet.at/felgenbilder/10985_5/seo/bbs_cc-r_schwarz_matt.jpg?1589867390", "BBS CC-R Rims", 2400.0, null },
                    { 118, 1, 19, "The BMW S85 is a high-revving 5.0-liter V10 engine, primarily known for powering the iconic E60 M5 and E63 M6 models. With its distinctive exhaust note and impressive performance, the S85 remains a celebrated powerplant among automotive enthusiasts.", "https://upload.wikimedia.org/wikipedia/commons/f/f0/BMW_S85B50_Engine.JPG", "BMW S85", 2400.0, null },
                    { 119, 3, 18, "Audi S-line brakes offer enhanced stopping power and performance, designed to complement high-performance S-line models. With improved brake pads, calipers, and rotors, they provide precise control and confidence, making them ideal for spirited driving experiences.", "https://i.ebayimg.com/images/g/vHMAAOSwc6deV7Zx/s-l1600.jpg", "Audi S-line Brakes", 1700.0, null },
                    { 120, 6, 18, "The Mercedes-Benz C-Class side mirror features a sleek design with integrated turn signals and auto-dimming capabilities. Its power-adjustable function and heating element provide added convenience and safety, enhancing the driving experience.", "https://www.mercedes-benz.com.cy/passengercars/mercedes-benz-cars/models/c-class/coupe-c205/safety/safety-packages/mirror-package/_jcr_content/par/productinfotextimage/media2/slides/videoimageslide_3f5b/image.MQ6.12.20210515155216.jpeg", "Side Mirror C-Class", 390.0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 120);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53573b79-4d23-4a28-95eb-baf4709858c7", "AQAAAAEAACcQAAAAENCsaka8+kflLO1xlH6hwspN6O43TCC1+UaLHlMdR0aI/e4e4xKIkRc/T2Q8Ugmmqg==", "8fe152fe-02fa-4932-953e-eeb47aa6f58d" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Acceleration", "CategoryId", "Color", "DealerId", "Description", "EngineSize", "FuelConsumption", "FuelTypeId", "Horsepower", "ImageUrl", "Make", "Model", "Price", "RentPrice", "RentalEndDate", "RentalStartDate", "RenterId", "TopSpeed", "Torque", "TransmissionId", "Weight", "Year" },
                values: new object[,]
                {
                    { 178, 4.9000000000000004, 1, "Black", 14, "ToAdd", 2999.0, 0.69999999999999996, 4, 365.0, "https://www.auto-data.net/images/f94/Mercedes-Benz-S-class-W223.jpg", "Mercedes-Benz", "S-Class (W223)", 175000.0, 700.0, null, null, null, 250.0, 500.0, 1, 2345.0, 2022 },
                    { 179, 12.9, 3, "black", 14, "ToAddDescription", 1896.0, 6.5, 1, 90.0, "https://www.auto-data.net/images/f118/Volkswagen-Golf-V.jpg", "VW", "Golf 5", 6200.0, 40.0, null, null, null, 176.0, 210.0, 1, 1285.0, 2004 },
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
                    { 197, 3.6000000000000001, 1, "Black", 14, "ToAddDescription", 3996.0, 14.4, 2, 550.0, "https://www.auto-data.net/images/f15/file8561600.jpg", "Porsche", "Panamera G2", 175000.0, 100.0, null, null, null, 306.0, 770.0, 1, 1995.0, 2019 },
                    { 198, 4.4000000000000004, 2, "Black", 14, "The BMW E92 M3 is a high-performance sports coupe known for its powerful V8 engine, precise handling, and iconic design. With a perfect blend of luxury and exhilaration, it remains a favorite among car enthusiasts seeking a thrilling driving experience.", 4361.0, 18.5, 2, 450.0, "https://collectingcars.imgix.net/007137/19-ww-8.jpg?w=1263&fit=fillmax&crop=edges&auto=format,compress&cs=srgb&q=85", "BMW", "E92 M3", 66500.0, 600.0, null, null, null, 250.0, 440.0, 1, 1530.0, 2010 },
                    { 199, 3.6000000000000001, 2, "Black", 14, "The Mercedes CLS 63 AMG is a luxury four-door coupe that combines elegance with blistering performance. Powered by a potent V8 engine, it offers a comfortable yet exhilarating driving experience, setting new standards for high-end performance cars.", 5461.0, 14.4, 2, 585.0, "https://citycarrentals.ca/wp-content/uploads/2018/02/mercedes-benz-cls-63-amg-black-3.jpg", "Mercedes-Benz", "CLS 63 AMG", 67500.0, 680.0, null, null, null, 250.0, 800.0, 1, 1945.0, 2014 },
                    { 200, 5.0999999999999996, 2, "Black", 14, "The Audi S5 is a dynamic and sleek sports coupe, featuring a turbocharged V6 engine and Quattro all-wheel drive. Its blend of performance, comfort, and cutting-edge technology make it a compelling choice for driving enthusiasts with a taste for luxury.", 2999.0, 10.699999999999999, 2, 333.0, "https://i.pinimg.com/originals/4f/23/28/4f2328613a9577fef6f77eee198e5f65.jpg", "Audi", "S5", 64000.0, 510.0, null, null, null, 250.0, 440.0, 1, 1745.0, 2012 },
                    { 201, 1.1000000000000001, 1, "Black", 14, "Test1", 444.0, 11.0, 1, 333.0, "https://images.drive.com.au/driveau/image/upload/t_wp-default/v1/cms/uploads/jjslyagf8e3gcny2doyy", "Test1", "Test1", 1234.0, 111.0, null, null, null, 123.0, 333.0, 1, 1234.0, 2012 }
                });

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
                    { 89, 7, 14, "ToAddPartDescription", "https://integralaudio.com/media/catalog/product/cache/429f869d5d4fbd3e94a8a75b24ebea81/f/3/f30.soundstage.complete_2_1.jpg", "Soundstage + Subwoofer System for BMW 3-Series", 2599.0, null }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "CategoryId", "DealerId", "Description", "ImageUrl", "Name", "Price", "PurchaserId" },
                values: new object[,]
                {
                    { 90, 7, 14, "ToAddPartDescription", "https://www.ptronic.com/files/images/boitiers/12/1.jpg", "Performance chip Audi A3 1.9 TDI 110hp", 300.0, null },
                    { 91, 7, 14, "ToAddPartDescription", "https://cdn.autodoc.de/thumb?id=17857567&m=1&n=0&lng=bg&ccf=94077841", "First aid kit", 60.0, null },
                    { 92, 6, 14, "ToAddPartDescription", "https://www.felgenoutlet.at/felgenbilder/10985_5/seo/bbs_cc-r_schwarz_matt.jpg?1589867390", "BBS CC-R Rims", 2400.0, null },
                    { 93, 1, 14, "The BMW S85 is a high-revving 5.0-liter V10 engine, primarily known for powering the iconic E60 M5 and E63 M6 models. With its distinctive exhaust note and impressive performance, the S85 remains a celebrated powerplant among automotive enthusiasts.", "https://upload.wikimedia.org/wikipedia/commons/f/f0/BMW_S85B50_Engine.JPG", "BMW S85", 2400.0, null },
                    { 94, 3, 14, "Audi S-line brakes offer enhanced stopping power and performance, designed to complement high-performance S-line models. With improved brake pads, calipers, and rotors, they provide precise control and confidence, making them ideal for spirited driving experiences.", "https://i.ebayimg.com/images/g/vHMAAOSwc6deV7Zx/s-l1600.jpg", "Audi S-line Brakes", 1700.0, null },
                    { 95, 6, 14, "The Mercedes-Benz C-Class side mirror features a sleek design with integrated turn signals and auto-dimming capabilities. Its power-adjustable function and heating element provide added convenience and safety, enhancing the driving experience.", "https://www.mercedes-benz.com.cy/passengercars/mercedes-benz-cars/models/c-class/coupe-c205/safety/safety-packages/mirror-package/_jcr_content/par/productinfotextimage/media2/slides/videoimageslide_3f5b/image.MQ6.12.20210515155216.jpeg", "Side Mirror C-Class", 390.0, null }
                });
        }
    }
}
