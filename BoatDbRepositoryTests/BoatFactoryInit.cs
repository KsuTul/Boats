using Boatstorage.Data;
using Boatstorage.Data.DAO;
using BoatStorage.Services.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoatStorage.Services.Tests
{
    public class BoatFactoryInit: IBoatFactory
    {
        public Boat CreateAndInitBoat()
        {
            return new Boat()
            {
                Id = 1,
                BoatType = nameof(Canoe),
                Name = "Boat",
                Displacement = 1000,
                Speed = 20,
                NumberOfSeats = 3,
                Manufacturer = "Yamaha",
                BoatsSpecificParameters = new List<BoatSpecificParameters>()
                {
                    new BoatSpecificParameters()
                    {
                        Key = nameof(Canoe.NumberOfPaddles),
                        Value = "3",
                    },
                },
            };
        }
    }
}
