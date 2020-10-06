namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data;

    public class CatamaranFactory : BoatsFactory
    {
        public override FloatingCrafts CreateBoat()
        {
            var rnd = new Random();
            return new Catamaran
            {
                Name = "Boat_" + Guid.NewGuid().ToString(),
                Displacement = rnd.Next(800, 900),
                Speed = rnd.Next(20, 30),
                NumberOfSeats = rnd.Next(1, 3),
                Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
            };
        }
    }
}
