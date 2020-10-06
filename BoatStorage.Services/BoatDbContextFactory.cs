namespace Boatstorage.Services
{
    using Boatstorage.Data;
    using Boatstorage.Data.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class BoatDbContextFactory : IBoatDbContextFactory
    {
        private readonly DbContextOptions<BoatDbContext> dbOptions;

        public BoatDbContextFactory(string connectionString)
            {
            var optionsBuilder = new DbContextOptionsBuilder<BoatDbContext>();
            this.dbOptions = optionsBuilder
            .UseSqlServer(connectionString)
            .Options;
            }

        public BoatDbContext Create()
        {
            return new BoatDbContext(this.dbOptions);
        }
    }
}
