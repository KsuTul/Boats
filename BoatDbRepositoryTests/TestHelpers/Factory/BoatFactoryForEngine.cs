namespace BoatStorage.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using Boatstorage.Data.DAO;
    using BoatStorage.Services.Tests.TestHelpers;

    public class BoatFactoryForEngine : IBoatFactory
    {
        public BoatFactoryForEngine(string powereKey, string powerValue, string manufacturerKey, string manufacturerValue)
        {
            this.PowerKey = powereKey;
            this.PowerValue = powerValue;
            this.ManufacturerKey = manufacturerKey;
            this.ManufacturerValue = manufacturerValue;
        }

        public string PowerKey { get; set; }

        public string PowerValue { get; set; }

        public string ManufacturerKey { get; set; }

        public string ManufacturerValue { get; set; }

        public Boat CreateAndInitBoat()
        {
            var rnd = new Random();
            return new Boat()
            {
                Id = rnd.Next(1, 10),
                BoatsSpecificParameters = this.PowerValue == null ? null : new List<BoatSpecificParameters>()
                 {
                   new BoatSpecificParameters() { Key = this.PowerKey, Value = this.PowerValue},
                   new BoatSpecificParameters() { Key = this.ManufacturerKey, Value = this.ManufacturerValue},
                 },
            };
        }
    }
}
