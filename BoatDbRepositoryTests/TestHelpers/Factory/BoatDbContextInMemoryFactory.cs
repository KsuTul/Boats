namespace BoatStorage.Services.Tests
{

    using Boatstorage.Data;
    using Boatstorage.Data.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class BoatDbContextInMemoryFactory : IBoatDbContextFactory
    {
        private readonly DbContextOptions<BoatDbContext> dbOptions;

        public BoatDbContextInMemoryFactory(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BoatDbContext>();
            this.dbOptions = optionsBuilder
            .UseInMemoryDatabase(connectionString)
            .Options;
        }

        public BoatDbContext Create()
        {
            return new BoatDbContext(this.dbOptions);
        }
    }
}
