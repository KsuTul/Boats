namespace BoatStorage.Services.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Boatstorage.Data;
    using Boatstorage.Data.DAO;

    public class ListsOfBoats
    {
        public static List<FloatingCrafts> GetFloatingCraftsLists()
        {
           return new List<FloatingCrafts>()
            {
                    new Canoe() { Id = 1,  Name = "Grace", Displacement = 1000, Speed = 30, NumberOfSeats = 5, Manufacturer = "Boat Marine" },
                    new Catamaran() { Id = 2, Name = "Seas the Day", Displacement = 1500, Speed = 15, NumberOfSeats = 2, Manufacturer = "Aurora" },
                    new Motorboat() { Id = 3,  Name = "Therapy", Displacement = 2000, Speed = 40, NumberOfSeats = 10, Manufacturer = "Corsair Mar" },
                    new HuntingBoat() { Id = 4, Name = "Serenity", Displacement = 1450, Speed = 35, NumberOfSeats = 3, Manufacturer = "Discovery"},
                    new InflatableBoat() { Id = 5, Name = "Perseverance", Displacement = 2000, Speed = 40, NumberOfSeats = 8, Manufacturer = "Boat Marine" },
            };
        }

        public static IEnumerable<Boat> GetBoatLists()
        {
            return new List<Boat>()
            {
                    new Boat() { Id = 1, BoatType = "Canoe" },
                    new Boat() { Id = 2, BoatType = "Catamaran" },
                    new Boat() { Id = 3, BoatType = "Motorboat" },
                    new Boat() { Id = 4, BoatType = "HuntingBoat" },
                    new Boat() { Id = 5, BoatType = "InflatableBoat" },
            };
        }

        public static Boat GetBoatbyType(string type)
        {
            return ListsOfBoats.GetBoatLists().FirstOrDefault(b => b.BoatType == type);
        }

        public static void Initialization(BoatDbContext dbContext)
        {
            dbContext.AddRange(ListsOfBoats.GetBoatLists());
            dbContext.SaveChanges();
        }
    }
}
