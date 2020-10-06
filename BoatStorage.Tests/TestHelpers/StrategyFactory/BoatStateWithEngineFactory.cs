namespace FloatStorage.Tests.TestHelpers
{
    using Boatstorage.Data.Mapping;
    using BoatStorage.Services;

    class BoatStateWithEngineFactory : BoatStrategyFactory
    {
        public override IBoatStateStrategy CreateBoatStrategy()
        {
            return new BoatStateWithEngine();
        }
    }
}
