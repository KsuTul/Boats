namespace Boatstorage.Data.Mapping
{
    using Boatstorage.Data;

    public interface IBoatDbContextFactory
    {
        public BoatDbContext Create();
    }
}
