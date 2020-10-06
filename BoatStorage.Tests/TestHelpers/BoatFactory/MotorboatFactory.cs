namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data;

    public class MotorboatFactory : BoatsFactory
    {
        public MotorboatFactory(bool isEngine)
        {
            this.IsEngine = isEngine;
        }

        private bool IsEngine { get; set; }

        public override FloatingCrafts CreateBoat()
        {
            var rnd = new Random();
            return new Motorboat
            {
                Name = "Boat_" + Guid.NewGuid().ToString(),
                Displacement = rnd.Next(1500, 2000),
                Speed = rnd.Next(20, 60),
                NumberOfSeats = rnd.Next(1, 4),
                Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                Engine = this.IsEngine == false ? null : new Engine()
                {
                    Power = rnd.Next(6, 30),
                    Manufacturer = "Manufacturer_" + rnd.Next(1, 100).ToString(),
                },
            };
        }
    }
}