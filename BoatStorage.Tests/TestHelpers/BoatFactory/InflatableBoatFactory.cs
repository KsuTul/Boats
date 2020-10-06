namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data;

    public class InflatableBoatFactory : BoatsFactory
    {
        public InflatableBoatFactory(bool isEngine, int paddles)
        {
            this.NumberOfPaddles = paddles;
            this.IsEngine = isEngine;
        }

        private bool IsEngine { get; set; }

        private int NumberOfPaddles { get; set; }

        public override FloatingCrafts CreateBoat()
        {
            var rnd = new Random();
            return new InflatableBoat
            {
                Name = "Boat_" + Guid.NewGuid().ToString(),
                Displacement = rnd.Next(1000, 3000),
                Speed = rnd.Next(30, 80),
                NumberOfSeats = rnd.Next(3, 10),
                Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                NumberOfPaddles = this.NumberOfPaddles,
                Engine = this.IsEngine == false ? null : new Engine()
                {
                    Power = rnd.Next(6, 30),
                    Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                },
            };
        }
    }
}
