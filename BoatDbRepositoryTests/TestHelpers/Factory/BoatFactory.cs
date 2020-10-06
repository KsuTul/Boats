namespace BoatStorage.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using Boatstorage.Data.DAO;
    using BoatStorage.Services.Tests.TestHelpers;

    public class BoatFactory : IBoatFactory
    {
        public BoatFactory(string key, string value, string boatType)
        {
            this.Key = key;
            this.Value = value;
            this.BoatType = boatType;
        }

        public string BoatType { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public Boat CreateAndInitBoat()
        {
            var rnd = new Random();
            return new Boat()
            {
                 Id = rnd.Next(1,10),
                 BoatType = this.BoatType,
                 BoatsSpecificParameters = this.Key == null ? new List<BoatSpecificParameters>()
                  : new List<BoatSpecificParameters>()
                  {
                   new BoatSpecificParameters() { Key = this.Key, Value = this.Value},
                  },
            };
        }
    }
}
