namespace CarParts.Services.Tests.UnitTests
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using Mocks;
    using static CarParts.Common.GlobalConstants;
    using Car = CarParts.Data.Models.Car;
    using Dealer = CarParts.Data.Models.Dealer;
    using Part = CarParts.Data.Models.Part;

    public class UnitTestsBase
    {
        protected ApplicationDbContext _data;

        public ApplicationUser DealerUser { get; private set; }
        public ApplicationUser RenterUser { get; private set; }
        public Dealer Dealer { get; private set; }
        public Car Car { get; private set; }
        public Part Part { get; private set; }

        [OneTimeSetUp]
        public void SetUpBase()
        {
            _data = DatabaseMock.Instance;

            SeedDatabase();
        }


        public void SeedDatabase()
        {
            DealerUser = new ApplicationUser
            {
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@agents.com",
                NormalizedEmail = "PESHO@AGENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = "DealerUserId",
                Balance = 123
            };
            _data.Users.Add(DealerUser);

            RenterUser = new ApplicationUser
            {
                UserName = "Gosho",
                NormalizedUserName = "GOSHO",
                Email = "gosho@renters.com",
                NormalizedEmail = "GOSHO@RENTERS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
                FirstName = "Gosho",
                LastName = "Goshov",
                Id = "RenterUserId",
                Balance = 123
            };
            _data.Users.Add(RenterUser);

            Dealer = new Dealer
            {
                Address = "St. Stolipin 13",
                User = DealerUser
            };
            _data.Dealers.Add(Dealer);

            RenterUser = new ApplicationUser
            {
                UserName = "Gosho",
                NormalizedUserName = "GOSHO",
                Email = "gosho@renters.com",
                NormalizedEmail = "GOSHO@RENTERS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
                FirstName = "Renter2",
                LastName = "Renterov2",
                Id = "RenterId2",
                Balance = 123
            };
            _data.Users.Add(RenterUser);

             Car = new Car
            {
                CarId = 20,
                Make = "Kia",
                Model = "Optima IV",
                Year = 2018,
                Description =
                    "The Kia Optima IV, introduced in 2018, is a midsize sedan that showcases Kia's commitment to style, technology, and value. With its modern exterior design, the Optima IV captures attention on the road. Sleek lines and a bold front grille create an assertive presence, while the attention to aerodynamics contributes to its efficiency. Inside the Optima IV, the cabin offers a blend of comfort and technology. High-quality materials and well-crafted surfaces create an inviting atmosphere. The intuitive infotainment system provides connectivity and entertainment features that enhance the driving experience. Under the hood, the Optima IV offers a range of engine options, catering to different preferences for performance and fuel efficiency. The sedan's well-balanced suspension and responsive steering contribute to a confident and enjoyable driving dynamic. In terms of safety, the Optima IV is equipped with a suite of features, including adaptive cruise control, automatic emergency braking, lane departure warning, and more. These features work together to enhance driver confidence and mitigate potential risks. As a part of Kia's lineup, the Optima IV represents the brand's commitment to delivering value without compromising on style and technology. It's a practical choice for drivers seeking a midsize sedan that offers a combination of comfort, performance, and safety. In conclusion, the 2018 Kia Optima IV reflects Kia's dedication to providing a well-rounded midsize sedan. With its modern design, comfortable interior, and advanced safety and technology features, the Optima IV remains a relevant choice for drivers who prioritize style and practicality in their daily commute.",
                Price = 3900,
                Color = "Red",
                EngineSize = 2993,
                FuelTypeId = 2,
                TransmissionId = 1,
                CategoryId = 5,
                Weight = 1625,
                TopSpeed = 205,
                Acceleration = 10.7,
                Horsepower = 163,
                Torque = 196,
                FuelConsumption = 10.1,
                ImageUrl = "https://www.auto-data.net/images/f56/Kia-Optima-IV-Sportswagon-facelift-2018.jpg",
                 RentPrice = 360
            };
             _data.Cars.Add(Car);

            Car = new Car
            {
                CarId = 21,
                Make = "BMW",
                Model = "E60",
                Year = 2010,
                Description =
                    "The BMW E60, introduced in 2010, is a representation of BMW's commitment to luxury, performance, and driving pleasure in the midsize sedan category. With its iconic design, the E60 carries BMW's distinctive styling cues. The elegant yet dynamic lines of the exterior showcase a timeless aesthetic that blends sophistication with athleticism. Inside, the cabin of the E60 offers a driver-focused environment. High-quality materials, precision craftsmanship, and ergonomic design create a space that exudes luxury and comfort. The intuitive controls and advanced infotainment system contribute to an engaging driving experience. Under the hood, the E60 offers a range of powerful engine options, each delivering the performance and refinement expected from a BMW. The sedan's responsive handling and well-tuned suspension system provide a dynamic driving experience that balances comfort and sportiness. Safety features in the E60 include airbags, stability control, and advanced braking systems, which contribute to occupant protection and peace of mind while on the road. As part of BMW's lineup, the E60 upholds the brand's legacy of engineering excellence and driving dynamics. It's an appealing choice for drivers who seek a midsize sedan that offers a blend of luxury, performance, and prestige. In summary, the 2010 BMW E60 continues to embody BMW's commitment to creating vehicles that deliver an exceptional driving experience. With its iconic design, luxurious interior, and engaging performance, the E60 remains a symbol of BMW's dedication to producing vehicles that cater to enthusiasts and luxury-seekers alike.",
                Price = 18500,
                Color = "Black",
                EngineSize = 2993,
                FuelTypeId = 1,
                TransmissionId = 1,
                CategoryId = 1,
                Weight = 1660,
                TopSpeed = 250,
                Acceleration = 6.4,
                Horsepower = 286,
                Torque = 580,
                FuelConsumption = 9,
                ImageUrl = "https://i.pinimg.com/originals/51/62/d5/5162d58a4f273c8ce26544da15659b5d.jpg",
                RentPrice = 190
            };
            _data.Cars.Add(Car);

            Car = new Car
            {
                CarId = 22,
                Make = "Toyota",
                Model = "Supra",
                Year = 1993,
                Description =
                    "The Toyota Supra, introduced in 1993, is an iconic sports car that embodies Toyota's pursuit of performance, style, and innovation. With its distinctive design, the Supra carries an unmistakable presence on the road. The sleek and aerodynamic body lines reflect both form and function, showcasing a blend of elegance and sportiness. Inside the Supra, the driver-focused cockpit emphasizes a connection between the driver and the road. High-quality materials, supportive seating, and intuitive controls create an environment that caters to both performance and comfort. Under the hood, the Supra offers a robust and turbocharged engine, delivering exhilarating acceleration and a thrilling driving experience. The precise handling and balanced suspension system make it a joy to navigate winding roads and tracks alike. While safety features in the 1993 Supra might not be as advanced as those in modern cars, it offers essential features like airbags and anti-lock brakes to ensure a level of occupant protection. As a part of Toyota's lineup, the Supra remains a symbol of the brand's dedication to engineering excellence and innovation. It's a coveted choice for enthusiasts and drivers seeking a sports car that offers both performance and prestige. In conclusion, the 1993 Toyota Supra stands as a testament to Toyota's commitment to creating a sports car that excites and inspires. With its iconic design, thrilling performance, and driver-focused interior, the Supra continues to hold a special place in the hearts of automotive enthusiasts and remains a timeless representation of Toyota's dedication to delivering excitement on the road.",
                Price = 60000,
                Color = "White",
                EngineSize = 2997,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 2,
                Weight = 1570,
                TopSpeed = 250,
                Acceleration = 5.1,
                Horsepower = 330,
                Torque = 440,
                FuelConsumption = 14.6,
                ImageUrl = "https://media.suara.com/pictures/653x366/2019/05/23/91189-toyota-supra-mk4.jpg",
                RentPrice = 300,
                DealerId = Dealer.Id
            };
            _data.Cars.Add(Car);

           


            Part = new Part
            {
                PartId = 20,
                Name = "BMW N54",
                Description =
                    "The BMW N54 is a twin-turbocharged inline-six engine that emerged as a significant milestone in BMW's engine lineup. Introduced in the mid-2000s, the N54 engine represented a departure from traditional naturally aspirated designs, embracing forced induction for enhanced performance. With its twin-turbocharging setup, the N54 engine achieved impressive power output and torque. The turbochargers provided quicker throttle response and increased power across a broad RPM range. This allowed for exhilarating acceleration and dynamic driving experiences. The N54 engine was fitted with direct fuel injection, which improved fuel efficiency and combustion efficiency. The aluminum-alloy block and cylinder head helped reduce weight without compromising durability. A notable feature of the N54 engine was its adaptability to aftermarket tuning and modifications. Enthusiasts found the engine's design to be receptive to performance enhancements, contributing to its popularity in the tuning community. The N54 engine found its place in various BMW models, including performance-oriented vehicles. Its introduction marked a shift in BMW's approach to achieving higher power levels while maintaining efficiency. The legacy of the N54 engine continues to influence BMW's engine development, particularly in the realm of turbocharging and direct injection. This engine highlighted BMW's commitment to pushing boundaries in pursuit of power, performance, and driving pleasure.",
                Price = 17000,
                ImageUrl = "https://images-stag.jazelc.com/uploads/theautopian-m2en/335i-engine-bay.jpg",
                CategoryId = 1,
                DealerId = Dealer.Id
            };

            _data.Parts.Add(Part);

            Part = new Part()
            {
                PartId = 21,
                Name = "S tronic (DSG) Audi",
                Description =
                    "The S tronic, also known as DSG (Direct-Shift Gearbox), is an innovative dual-clutch automatic transmission technology developed by Audi. This transmission system combines the convenience of an automatic transmission with the quick and precise gear changes of a manual gearbox. The S tronic/DSG transmission utilizes two separate clutches and gear sets, one for even-numbered gears and the other for odd-numbered gears. This design allows for seamless gear changes without the interruption of power delivery, resulting in lightning-fast shifts and improved acceleration. Drivers can experience the S tronic/DSG transmission in two primary modes: automatic mode and manual mode. In automatic mode, the transmission optimizes gear changes based on driving conditions, while manual mode enables drivers to take control of gear selection using paddle shifters or the gear lever. The benefits of the S tronic/DSG transmission include improved fuel efficiency, rapid gear changes, and enhanced driving dynamics. Its ability to predict gear changes and pre-select the next gear contributes to a smoother and more responsive driving experience. Audi has incorporated the S tronic/DSG technology across various models in its lineup, showcasing the brand's commitment to offering cutting-edge transmission solutions that cater to both performance and efficiency. This transmission technology has redefined the driving experience, providing a seamless blend of convenience and sportiness for Audi enthusiasts and drivers.",
                Price = 19000,
                ImageUrl =
                    "https://static.wixstatic.com/media/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png/v1/fill/w_640,h_400,al_c,q_85,usm_4.00_1.00_0.00,enc_auto/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png",
                CategoryId = 2
            };

            _data.Parts.Add(Part);

            Part = new Part()
            {
                PartId = 2,
                Name = "aa",
                Description = "bb",
                Price = 123,
                ImageUrl = "image",
                CategoryId = 1,
                PurchaserId = "Purchaser2Id",
                DealerId = 1,
                UserFavoriteParts = new List<UserFavoritePart>()
            };

            _data.Parts.Add(Part);


            _data.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            _data.Dispose();
        }
    }
}