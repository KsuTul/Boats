namespace BoatStorage.Services.Tests
{
    using System;
    using Boatstorage.Data;
    using FloatStorage.Tests.TestHelpers;

    public class FloatingCraftsFactory : IFloatingCraftFactory
    {
        public FloatingCraftsFactory(BoatType type)
        {
            this.BoatType = type;
        }

        private BoatType BoatType { get; set; }

        public FloatingCrafts CreateAndInitBoat()
        {
            var rnd = new Random();
            switch (this.BoatType)
            {
                case BoatType.Catamaran:
                    return new Catamaran()
                    {
                        Name = "Boat_" + Guid.NewGuid().ToString(),
                        Displacement = rnd.Next(800, 1000),
                        Speed = rnd.Next(20, 50),
                        NumberOfSeats = rnd.Next(1, 5),
                        Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                    };

                case BoatType.Canoe:
                    return new Canoe()
                    {
                        Id = 1,
                        Name = "Boat",
                        Displacement = 1000,
                        Speed = 20,
                        NumberOfSeats = 3,
                        Manufacturer = "Yamaha",
                        NumberOfPaddles = 2,
                    };

                case BoatType.HuntingBoat:
                    return new HuntingBoat()
                    {
                        Name = "Boat_" + Guid.NewGuid().ToString(),
                        Displacement = rnd.Next(800, 1000),
                        Speed = rnd.Next(20, 50),
                        NumberOfSeats = rnd.Next(1, 5),
                        Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                        NumberOfPaddles = 2,
                    };

                case BoatType.Motorboat:
                    return new Motorboat()
                    {
                        Name = "Boat_" + Guid.NewGuid().ToString(),
                        Displacement = rnd.Next(800, 1000),
                        Speed = rnd.Next(20, 50),
                        NumberOfSeats = rnd.Next(1, 5),
                        Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                        Engine = new Engine
                        {
                            Power = 60,
                            Manufacturer = "Yamaha",
                        },
                    };

                case BoatType.InflatableBoat:
                    return new InflatableBoat()
                    {
                        Name = "Boat_" + Guid.NewGuid().ToString(),
                        Displacement = rnd.Next(800, 1000),
                        Speed = rnd.Next(20, 50),
                        NumberOfSeats = rnd.Next(1, 5),
                        Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                        NumberOfPaddles = 2,
                        Engine = new Engine
                        {
                              Power = 60,
                              Manufacturer = "Yamaha",
                        },
                    };
            }

            throw new ArgumentException("Danger! Error!");
        }
    }
}
