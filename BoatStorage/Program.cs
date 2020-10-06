namespace BoatStorage
{
    using Boatstorage.Data;
    using BoatStorage.Data;
    using Boatstorage.Data.Mapping;
    using Boatstorage.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var canoe = new Canoe() { Id = 21, Name = "Grace", Displacement = 1500, Speed = 30, NumberOfSeats = 5, Manufacturer = "Boat Marine", NumberOfPaddles = 3, };
            var catamaran = new Catamaran() { Name = "Seas the Day", Displacement = 1500, Speed = 15, NumberOfSeats = 2, Manufacturer = "Aurora", };
            var motorboat = new Motorboat() { Name = "Therapy", Displacement = 2000, Speed = 40, NumberOfSeats = 10, Manufacturer = "Corsair Mar", Engine = new Engine() { Power = 80, Manufacturer = "Jamaha" }, };
            var huntingBoat = new HuntingBoat() { Name = "Serenity", Displacement = 1450, Speed = 35, NumberOfSeats = 3, Manufacturer = "Discovery", NumberOfPaddles = 0 };
            var inflatableBoat = new InflatableBoat() { Id = 35, Name = "Perseverance", Displacement = 2000, Speed = 40, NumberOfSeats = 8, Manufacturer = "Boat Marine", NumberOfPaddles = 2 };

            // setup our DI
            // TODO Interface
            var services = new ServiceCollection();
            services
                .AddSingleton<IBoatDbContextFactory>(new BoatDbContextFactory("Server=(localdb)\\mssqllocaldb;Database=C:\\USERS\\XENIA\\SOURCE\\WORKSPACES\\LEARNINGPROJECTS\\MAIN\\SOURCE\\XENIA\\BOATSTORAGE\\DATA\\BOATS.MDF;Trusted_Connection=True;"))
                .AddSingleton<IBoatRepository, BoatRepository>();

            var serviceProvider = services.BuildServiceProvider();
            var boatRepository = serviceProvider.GetService<IBoatRepository>();

            var list = boatRepository.GetAll();
            await foreach (var x in list)
            {
                Console.WriteLine(x.Name);
            }
           
        }
    }
}