namespace BoatStorage.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Boatstorage.Data.Mapping;

    public interface IBoatRepository
    {
        Task<IBoat> GetById(int id);

        IAsyncEnumerable<IBoat> GetAll();

        Task Insert(IBoat domainModels);

        Task Update(IBoat domainModels);

        Task Delete(int id);
    }
}
