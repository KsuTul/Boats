namespace FloatStorage.Tests.TestHelpers
{
    using Boatstorage.Data.Mapping;

    public abstract class BoatStrategyFactory
    {
        public abstract IBoatStateStrategy CreateBoatStrategy();
    }
}
