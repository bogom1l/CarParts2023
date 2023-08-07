namespace CarParts.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using static Common.GlobalConstants.AdminUser;

    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedCarFuelTypes(modelBuilder);
            SeedCarTransmissions(modelBuilder);
            SeedCarCategories(modelBuilder);

            SeedPartCategories(modelBuilder);

            SeedAdministrator(modelBuilder);

            SeedCars(modelBuilder);
            SeedParts(modelBuilder);
        }

        private static void SeedCarFuelTypes(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CarFuelType>()
                .HasData(
                    new CarFuelType { Id = 1, Name = "Diesel" },
                    new CarFuelType { Id = 2, Name = "Petrol" },
                    new CarFuelType { Id = 3, Name = "Electric" },
                    new CarFuelType { Id = 4, Name = "Hybrid" });
        }

        private static void SeedCarTransmissions(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CarTransmission>()
                .HasData(
                    new CarTransmission { Id = 1, Name = "Automatic" },
                    new CarTransmission { Id = 2, Name = "Manual" });
        }

        private static void SeedCarCategories(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CarCategory>()
                .HasData(
                    new CarCategory { Id = 1, Name = "Sedan" },
                    new CarCategory { Id = 2, Name = "Coupe" },
                    new CarCategory { Id = 3, Name = "Hatchback" },
                    new CarCategory { Id = 4, Name = "SUV" },
                    new CarCategory { Id = 5, Name = "Wagon" },
                    new CarCategory { Id = 6, Name = "Cabrio" },
                    new CarCategory { Id = 7, Name = "Pickup Truck" },
                    new CarCategory { Id = 8, Name = "Minivan" },
                    new CarCategory { Id = 9, Name = "Jeep" });
        }

        private static void SeedPartCategories(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PartCategory>()
                .HasData(
                    new PartCategory { CategoryId = 1, Name = "Engine" },
                    new PartCategory { CategoryId = 2, Name = "Transmission" },
                    new PartCategory { CategoryId = 3, Name = "Brakes" },
                    new PartCategory { CategoryId = 4, Name = "Suspension" },
                    new PartCategory { CategoryId = 5, Name = "Interior" },
                    new PartCategory { CategoryId = 6, Name = "Exterior" },
                    new PartCategory { CategoryId = 7, Name = "Electrical" });
        }

        private static void SeedAdministrator(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                FirstName = AdminFirstName,
                LastName = AdminLastName,
                Balance = 9_999_999
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, AdminPassword);

            modelBuilder
                .Entity<ApplicationUser>()
                .HasData(adminUser);

            modelBuilder
                .Entity<Dealer>()
                .HasData(
                    new Dealer
                    {
                        Id = 14, //TODO: careful, what is my last 
                        Address = AdminAddress,
                        UserId = adminUser.Id
                    });
        }

        private static void SeedCars(ModelBuilder modelBuilder)
        {
            // To be careful with CarId, and DealerId !!!
            // Copy the first added car here and use it for template when adding new cars

            var cars = new List<Car>();
            Car car;
            var currentCarId =
                178; //TODO: Change this to the last CarId in the database <=> _seedHelper.GetLastCarId() + 1;

            car = new Car
            {
                CarId = currentCarId, // [!]
                Make = "Mercedes-Benz",
                Model = "S-Class (W223)",
                Year = 2022,
                DealerId = 14, // [!] The ID of the dealer (you need to set this based on your database)
                Description = "ToAdd",
                Price = 175000,
                Color = "Black",
                EngineSize = 2999,
                FuelTypeId = 4,
                TransmissionId = 1,
                CategoryId = 1,
                Weight = 2345,
                TopSpeed = 250,
                Acceleration = 4.9,
                Horsepower = 365,
                Torque = 500,
                FuelConsumption = 0.7,
                ImageUrl = "https://www.auto-data.net/images/f94/Mercedes-Benz-S-class-W223.jpg",
                RentPrice = 700,
                Dealer = null, //DO NOT TOUCH
                FuelType = null, //DO NOT TOUCH
                Transmission = null, //DO NOT TOUCH
                Category = null, //DO NOT TOUCH
                RentalStartDate = null, //DO NOT TOUCH
                RentalEndDate = null, //DO NOT TOUCH
                RenterId = null, //DO NOT TOUCH
                Renter = null, //DO NOT TOUCH
                UserFavoriteCars = new List<UserFavoriteCar>(), //DO NOT TOUCH
                Reviews = new List<Review>(), //DO NOT TOUCH
                UserComparisonCars = new List<UserComparisonCar>() //DO NOT TOUCH
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "VW",
                Model = "Golf 5",
                Year = 2004,
                Description = "ToAddDescription",
                Price = 6200,
                Color = "black",
                EngineSize = 1896,
                FuelTypeId = 1,
                TransmissionId = 1,
                CategoryId = 3,
                Weight = 1285,
                TopSpeed = 176,
                Acceleration = 12.9,
                Horsepower = 90,
                Torque = 210,
                FuelConsumption = 6.5,
                ImageUrl = "https://www.auto-data.net/images/f118/Volkswagen-Golf-V.jpg",
                RentPrice = 40
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Skoda",
                Model = "Fabia III",
                Year = 2018,
                Description = "ToAddDescription",
                Price = 24000,
                Color = "Red",
                EngineSize = 2993,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 3,
                Weight = 1957,
                TopSpeed = 195,
                Acceleration = 10.1,
                Horsepower = 110,
                Torque = 200,
                FuelConsumption = 5.6,
                ImageUrl = "https://www.auto-data.net/images/f76/Skoda-Fabia-III-facelift-2018.jpg",
                RentPrice = 130
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Lexus",
                Model = "RX IV",
                Year = 2016,
                Description = "ToAddDescription",
                Price = 85000,
                Color = "Dark blue",
                EngineSize = 3456,
                FuelTypeId = 2,
                TransmissionId = 1,
                CategoryId = 4,
                Weight = 2025,
                TopSpeed = 200,
                Acceleration = 6.8,
                Horsepower = 290,
                Torque = 363,
                FuelConsumption = 11.7,
                ImageUrl = "https://www.auto-data.net/images/f28/file9510003.jpg",
                RentPrice = 220
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Volvo",
                Model = "S40 II",
                Year = 2011,
                Description = "ToAddDescription",
                Price = 4800,
                Color = "White",
                EngineSize = 1999,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 1,
                Weight = 1370,
                TopSpeed = 200,
                Acceleration = 9.5,
                Horsepower = 145,
                Torque = 185,
                FuelConsumption = 10.8,
                ImageUrl = "https://www.auto-data.net/images/f88/Volvo-S40-II-facelift-2007.jpg",
                RentPrice = 75
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Kia",
                Model = "Optima IV",
                Year = 2018,
                Description = "ToAddDescription",
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
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "BMW",
                Model = "E60",
                Year = 2010,
                Description = "ToAddDescription",
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
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Toyota",
                Model = "Supra",
                Year = 1993,
                Description = "ToAddDescription",
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
                RentPrice = 300
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Audi",
                Model = "S3 8P",
                Year = 2006,
                Description = "ToAddDescription",
                Price = 15400,
                Color = "Black",
                EngineSize = 1984,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 3,
                Weight = 1455,
                TopSpeed = 250,
                Acceleration = 5.7,
                Horsepower = 265,
                Torque = 350,
                FuelConsumption = 12.4,
                ImageUrl =
                    "https://www.ilr-carbon.com/1603-large_default/audi-a3-s3-8p-3-dr-rear-spoiler-rs3-style.jpg",
                RentPrice = 210
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "BMW",
                Model = "E64",
                Year = 2007,
                Description = "ToAddDescription",
                Price = 24000,
                Color = "Black",
                EngineSize = 2996,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 6,
                Weight = 1740,
                TopSpeed = 250,
                Acceleration = 6.9,
                Horsepower = 272,
                Torque = 320,
                FuelConsumption = 11.8,
                ImageUrl = "https://www.auto-data.net/images/f37/BMW-6-Series-Convertible-E64-facelift-2007.jpg",
                RentPrice = 260
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "BMW",
                Model = "E46",
                Year = 2003,
                Description = "ToAddDescription 330cd",
                Price = 8100,
                Color = "Black",
                EngineSize = 2993,
                FuelTypeId = 1,
                TransmissionId = 2,
                CategoryId = 2,
                Weight = 1540,
                TopSpeed = 250,
                Acceleration = 7.2,
                Horsepower = 204,
                Torque = 410,
                FuelConsumption = 9.1,
                ImageUrl =
                    "https://cloud.leparking.fr/2021/09/07/00/14/bmw-serie-3-coupe-bmw-e46-330cd-coupe-manual-rare-colour-xenons-satnav-heated-seats-bleu_8263957425.jpg",
                RentPrice = 150
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Toyota",
                Model = "Corolla Verso II",
                Year = 2004,
                Description = "ToAddDescription",
                Price = 6800,
                Color = "White",
                EngineSize = 2231,
                FuelTypeId = 1,
                TransmissionId = 2,
                CategoryId = 8,
                Weight = 1575,
                TopSpeed = 250,
                Acceleration = 10.2,
                Horsepower = 136,
                Torque = 310,
                FuelConsumption = 8.3,
                ImageUrl =
                    "https://d1gymyavdvyjgt.cloudfront.net/drive/images/made/drive/images/remote/https_ssl.caranddriving.com/f2/images/used/big/toycorollaverso%202006_750_500_70.jpg",
                RentPrice = 70
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Mercedes-Benz",
                Model = "C-Class",
                Year = 2016,
                Description = "ToAddDescription C300",
                Price = 5200,
                Color = "Grey",
                EngineSize = 1991,
                FuelTypeId = 2,
                TransmissionId = 1,
                CategoryId = 2,
                Weight = 1490,
                TopSpeed = 250,
                Acceleration = 6,
                Horsepower = 245,
                Torque = 370,
                FuelConsumption = 8.3,
                ImageUrl = "https://www.auto-data.net/images/f22/file8603854.jpg",
                RentPrice = 135
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Toyota",
                Model = "Land Cruiser",
                Year = 2003,
                Description = "ToAddDescription",
                Price = 85000,
                Color = "White",
                EngineSize = 3444,
                FuelTypeId = 2,
                TransmissionId = 1,
                CategoryId = 4,
                Weight = 2520,
                TopSpeed = 250,
                Acceleration = 6.8,
                Horsepower = 415,
                Torque = 650,
                FuelConsumption = 18.5,
                ImageUrl = "https://www.auto-data.net/images/f109/Toyota-Land-Cruiser-J300.jpg",
                RentPrice = 190
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------


            car = new Car
            {
                CarId = currentCarId,
                Make = "BMW",
                Model = "E91",
                Year = 2005,
                Description = "ToAddDescription",
                Price = 8200,
                Color = "Blue",
                EngineSize = 1995,
                FuelTypeId = 1,
                TransmissionId = 2,
                CategoryId = 5,
                Weight = 1510,
                TopSpeed = 223,
                Acceleration = 8.6,
                Horsepower = 163,
                Torque = 340,
                FuelConsumption = 8.1,
                ImageUrl = "https://www.auto-data.net/images/f41/BMW-3-Series-Touring-E91.jpg",
                RentPrice = 140
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------


            car = new Car
            {
                CarId = currentCarId,
                Make = "Dodge",
                Model = "Ram",
                Year = 2005,
                Description = "ToAddDescription",
                Price = 3700,
                Color = "Yellow",
                EngineSize = 5657,
                FuelTypeId = 2,
                TransmissionId = 1,
                CategoryId = 7,
                Weight = 1880,
                TopSpeed = 250,
                Acceleration = 6.8,
                Horsepower = 345,
                Torque = 529,
                FuelConsumption = 18.1,
                ImageUrl = "https://www.auto-data.net/images/f46/Dodge-Ram-1500-III-DR-DH.jpg",
                RentPrice = 330
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------


            car = new Car
            {
                CarId = currentCarId,
                Make = "Dacia",
                Model = "Sandero II Stepway",
                Year = 2013,
                Description = "ToAddDescription",
                Price = 9999,
                Color = "Red",
                EngineSize = 2999,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 4,
                Weight = 1023,
                TopSpeed = 170,
                Acceleration = 11.1,
                Horsepower = 90,
                Torque = 135,
                FuelConsumption = 6.7,
                ImageUrl =
                    "https://cdn3.focus.bg/autodata/i/dacia/sandero/sandero-ii-stepway/large/675829b961ab0a61241270896e202b87.jpg",
                RentPrice = 199
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Mercedes-Benz",
                Model = "A-Class (W168)",
                Year = 1999,
                Description = "ToAddDescription",
                Price = 4400,
                Color = "Black",
                EngineSize = 1598,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 3,
                Weight = 1135,
                TopSpeed = 180,
                Acceleration = 10.8,
                Horsepower = 102,
                Torque = 150,
                FuelConsumption = 10.2,
                ImageUrl =
                    "https://static-eu.cargurus.com/images/forsale/2023/05/16/15/02/2003_mercedes-benz_a-class-pic-3974413017599453644-1024x768.jpeg",
                RentPrice = 110
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Audi",
                Model = "A4",
                Year = 2011,
                Description = "ToAddDescription",
                Price = 12400,
                Color = "Grey",
                EngineSize = 1798,
                FuelTypeId = 2,
                TransmissionId = 2,
                CategoryId = 1,
                Weight = 1430,
                TopSpeed = 230,
                Acceleration = 8.1,
                Horsepower = 170,
                Torque = 320,
                FuelConsumption = 7.4,
                ImageUrl = "https://www.auto-data.net/images/f93/Audi-A4-B8-8K-facelift-2011.jpg",
                RentPrice = 180
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------

            car = new Car
            {
                CarId = currentCarId,
                Make = "Porsche",
                Model = "Panamera G2",
                Year = 2019,
                Description = "ToAddDescription",
                Price = 175000,
                Color = "Black",
                EngineSize = 3996,
                FuelTypeId = 2,
                TransmissionId = 1,
                CategoryId = 1,
                Weight = 1995,
                TopSpeed = 306,
                Acceleration = 3.6,
                Horsepower = 550,
                Torque = 770,
                FuelConsumption = 14.4,
                ImageUrl = "https://www.auto-data.net/images/f15/file8561600.jpg",
                RentPrice = 100
            };
            cars.Add(car);
            currentCarId += 1;
            //--------------------------------------


            //---------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------

            //------------------------------------\\
            cars.ForEach(c => c.DealerId = 14); //Usually the ADMIN for simplicity
            cars.ForEach(c => c.Dealer = null);
            cars.ForEach(c => c.FuelType = null);
            cars.ForEach(c => c.Transmission = null);
            cars.ForEach(c => c.Category = null);
            cars.ForEach(c => c.RentalStartDate = null);
            cars.ForEach(c => c.RentalEndDate = null);
            cars.ForEach(c => c.RenterId = null);
            cars.ForEach(c => c.Renter = null);
            cars.ForEach(c => c.UserFavoriteCars = new List<UserFavoriteCar>());
            cars.ForEach(c => c.Reviews = new List<Review>());
            cars.ForEach(c => c.UserComparisonCars = new List<UserComparisonCar>());
            //------------------------------------\\
            modelBuilder.Entity<Car>().HasData(cars);
        }

        private static void SeedParts(ModelBuilder modelBuilder)
        {
            // To be careful with PartId, and DealerId !!!
            // Copy the first added part here and use it for template when adding new parts

            var parts = new List<Part>();
            Part part;
            var currentPartId = 73; //TODO: Change this to the last PartId in the database

            part = new Part
            {
                PartId = currentPartId,
                Name = "BMW M52",
                Description = "ToAddPartDescription",
                Price = 15000,
                ImageUrl = "https://www.bimmerarchive.org/images/5177-114-bmw-m52@2x.jpg",
                CategoryId = 1
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "BMW M54",
                Description = "ToAddPartDescription",
                Price = 13000,
                ImageUrl = "https://i.ytimg.com/vi/4yw4_1bI63I/maxresdefault.jpg",
                CategoryId = 1
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "BMW N54",
                Description = "ToAddPartDescription",
                Price = 17000,
                ImageUrl = "https://images-stag.jazelc.com/uploads/theautopian-m2en/335i-engine-bay.jpg",
                CategoryId = 1
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "S tronic (DSG) Audi",
                Description = "ToAddPartDescription",
                Price = 19000,
                ImageUrl =
                    "https://static.wixstatic.com/media/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png/v1/fill/w_640,h_400,al_c,q_85,usm_4.00_1.00_0.00,enc_auto/c3e527_eeac5846b92f4c5a839e8f5b8a02021b~mv2.png",
                CategoryId = 2
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Tiptronic Audi",
                Description = "ToAddPartDescription",
                Price = 21000,
                ImageUrl = "https://www.audi-technology-portal.de/en/download?file=813",
                CategoryId = 2
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "DSG (Direct Shift Gearbox) VW",
                Description = "ToAddPartDescription",
                Price = 9000,
                ImageUrl =
                    "https://b1936034.smushcdn.com/1936034/wp-content/uploads/2020/01/DL382.png?lossy=1&strip=1&webp=1",
                CategoryId = 2
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "6-speed Manual VW",
                Description = "ToAddPartDescription",
                Price = 7500,
                ImageUrl = "https://images.hgmsites.net/hug/volkswagen_100708189_h.jpg",
                CategoryId = 2
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Mercedes-Benz AMG Ceramic Composite Brakes (CCB)",
                Description = "ToAddPartDescription",
                Price = 4500,
                ImageUrl = "https://tro-nik.com/wp-content/uploads/2021/07/Mercedes-Benz-W167-brakes.-pic.-1.jpg",
                CategoryId = 3
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Mercedes-Benz AMG Performance Brakes",
                Description = "ToAddPartDescription",
                Price = 8700,
                ImageUrl =
                    "https://www.kunzmann.de/image/replacement-and-wearparts-brake-equipment-brake-di-29847-xl.jpg",
                CategoryId = 3
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Adaptive M Suspension",
                Description = "ToAddPartDescription",
                Price = 16000,
                ImageUrl =
                    "https://www.bmw.ie/en/shop/ls/images/connected-drive/xl/VDC_Offer/images/Adaptives_M_Fahrwerk_902x508.jpg",
                CategoryId = 4
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------
            part = new Part
            {
                PartId = currentPartId,
                Name = "Audi Dynamic Ride Control (DRC)",
                Description = "ToAddPartDescription",
                Price = 9500,
                ImageUrl =
                    "https://audimediacenter-a.akamaihd.net/system/production/media/84119/images/7e6b0f01721320da20eade10395735ebf282c6a1/A1912000_x500.jpg?1582560882",
                CategoryId = 4
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "M Sport Seats",
                Description = "BMW E46 Cab M Sport Dakota Coral Red Leather",
                Price = 123456789,
                ImageUrl =
                    "https://trimtechnik.net/assets/images/content/129/bmw_e46_cab_m_sport_coral_red_leather_003__1000.jpg",
                CategoryId = 5
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Audi RS4 B7 Recaro Seats",
                Description = "ToAddPartDescription",
                Price = 1150,
                ImageUrl =
                    "https://bringatrailer.com/wp-content/uploads/2019/01/1547765401b064a6f7f52ae3fPhoto-Jan-10-6-09-19-PM.jpg",
                CategoryId = 5
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Carbon rear wing / rear spoiler",
                Description = "ToAddPartDescription",
                Price = 600,
                ImageUrl =
                    "https://luethen-motorsport.com/media/image/9f/42/ed/mercedes-c63-amg-coupe-c205-carbon-heckflugel-heckspoiler-ac2051200_600x600.jpg",
                CategoryId = 6
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "LED Angel Eyes (white)",
                Description = "ToAddPartDescription",
                Price = 2200,
                ImageUrl = "https://nastarta-shop.com/wp-content/uploads/2022/02/led_halo.jpg",
                CategoryId = 6
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "LCI LED Headlights - BMW F10 M5 & 5 Series",
                Description = "ToAddPartDescription",
                Price = 800,
                ImageUrl =
                    "https://bimmerplug.com/cdn/shop/products/LCI-LED-Headlights-BMW-F10-M5-5-Series-2_800x.jpg?v=1655094531",
                CategoryId = 6
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Soundstage + Subwoofer System for BMW 3-Series",
                Description = "ToAddPartDescription",
                Price = 2599,
                ImageUrl =
                    "https://integralaudio.com/media/catalog/product/cache/429f869d5d4fbd3e94a8a75b24ebea81/f/3/f30.soundstage.complete_2_1.jpg",
                CategoryId = 7
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "Performance chip Audi A3 1.9 TDI 110hp",
                Description = "ToAddPartDescription",
                Price = 300,
                ImageUrl = "https://www.ptronic.com/files/images/boitiers/12/1.jpg",
                CategoryId = 7
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "First aid kit",
                Description = "ToAddPartDescription",
                Price = 60,
                ImageUrl = "https://cdn.autodoc.de/thumb?id=17857567&m=1&n=0&lng=bg&ccf=94077841",
                CategoryId = 7
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------

            part = new Part
            {
                PartId = currentPartId,
                Name = "BBS CC-R Rims",
                Description = "ToAddPartDescription",
                Price = 2400,
                ImageUrl = "https://www.felgenoutlet.at/felgenbilder/10985_5/seo/bbs_cc-r_schwarz_matt.jpg?1589867390",
                CategoryId = 6
            };
            parts.Add(part);
            currentPartId += 1;
            //--------------------------------------


            //---------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------

            //------------------------------------\\
            parts.ForEach(c => c.DealerId = 14); //Usually the ADMIN for simplicity
            parts.ForEach(c => c.Dealer = null);
            parts.ForEach(c => c.Category = null);
            parts.ForEach(c => c.PurchaserId = null);
            parts.ForEach(c => c.Purchaser = null);
            parts.ForEach(c => c.UserFavoriteParts = new List<UserFavoritePart>());
            //------------------------------------\\
            modelBuilder.Entity<Part>().HasData(parts);
        }
    }
}

/*
//public int GetLastCarId() 
//{
//    var lastCar = _dbContext
//        .Cars
//        .OrderByDescending(c => c.CarId)
//        .FirstOrDefault();

//    if (lastCar == null)
//    {
//        return 0;
//    }

//    return lastCar.CarId;
//}
 */


/*
TEMPLATE Car
 
car = new Car
{
    CarId = currentCarId,
    Make = "make",
    Model = "model",
    Year = 2022,
    Description = "ToAddDescription",
    Price = 175000,
    Color = "Color",
    EngineSize = 2999,
    FuelTypeId = 4,
    TransmissionId = 1,
    CategoryId = 1,
    Weight = 2345,
    TopSpeed = 250,
    Acceleration = 4.9,
    Horsepower = 365,
    Torque = 500,
    FuelConsumption = 5.5,
    ImageUrl = "image",
    RentPrice = 100
};
cars.Add(car);
currentCarId += 1;
//--------------------------------------

*/

/*
TEMPLATE Part

part = new Part
{
    PartId = currentPartId,
    Name = "NAMENAMENAMENAME",
    Description = "ToAddPartDescription",
    Price = 123456789,
    ImageUrl = "IMAGEIMAGEIMAGE",
    CategoryId = 1
};
parts.Add(part);
currentPartId += 1;
//--------------------------------------


*/