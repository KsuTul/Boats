namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data;

    public class HuntingBoatFactory : BoatsFactory
    {
        public HuntingBoatFactory(int paddles)
        {
            this.NumberOfPaddles = paddles;
        }

        private int NumberOfPaddles { get; set; }

        public override FloatingCrafts CreateBoat()
        {
            var rnd = new Random();
            return new HuntingBoat
            {
                Name = "Boat_" + Guid.NewGuid().ToString(),
                Displacement = rnd.Next(800, 1000),
                Speed = rnd.Next(20, 50),
                NumberOfSeats = rnd.Next(1, 5),
                Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                NumberOfPaddles = this.NumberOfPaddles,
            };
        }
    }
}
