namespace Boatstorage.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BoatStorage.Data;
    using Boatstorage.Data.DAO;
    using Boatstorage.Data.Mapping;
    using BoatStorage.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Cryptography.X509Certificates;

    public class BoatRepository  : IBoatRepository
    {
        private IBoatDbContextFactory _contextFactory;

        public BoatRepository(IBoatDbContextFactory contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        public async Task<IBoat> GetById(int id)
        {
            using var dbContext = this._contextFactory.Create();

            return await dbContext.Boats
               .Include(x => x.BoatsSpecificParameters)
               .AsNoTracking()
               .Where(p => p.Id == id)
               .Select(p => BoatExtensions.MapToDomainBoat(p))
               .FirstOrDefaultAsync();
        }

        public async IAsyncEnumerable<IBoat> GetAll()
        {
            using var dbContext = this._contextFactory.Create();
            var boats = dbContext.Boats
                     .Include(x => x.BoatsSpecificParameters)
                     .AsNoTracking()
                     .Select(p => BoatExtensions.MapToDomainBoat(p)).AsAsyncEnumerable();
            await foreach (var items in boats)
            {
                yield return items;
            }
        }

        public async Task Insert(IBoat domainModels)
        {
            using var dbContext = this._contextFactory.Create();
            var boat = new Boat() { BoatsSpecificParameters = new List<BoatSpecificParameters>() };
            var model = BoatExtensions.MapToDaoModels(boat, domainModels);
            dbContext.Boats.Add(model);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(IBoat domainModels)
        {
            using var dbContext = this._contextFactory.Create();
            var boat = dbContext.Boats.Include(x => x.BoatsSpecificParameters).First(x => x.Id == domainModels.Id);
            var model = BoatExtensions.MapToDaoModels(boat, domainModels);
            dbContext.Boats.Update(boat);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var dbContext = this._contextFactory.Create();
            var entity = dbContext.Boats.First(b => b.Id == id);
            dbContext.Boats.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
