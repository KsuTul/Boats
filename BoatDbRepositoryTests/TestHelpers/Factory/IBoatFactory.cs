namespace BoatStorage.Services.Tests.TestHelpers
{
    using Boatstorage.Data.DAO;

    public interface IBoatFactory
    {
        public abstract Boat CreateAndInitBoat();
    }
}
