namespace FloatStorage.Tests.TestHelpers
{
    using Boatstorage.Data.Mapping;
    using BoatStorage.Services;

    public class BoatStateWithPaddlesAndEnginefactory : BoatStrategyFactory
    {
        public override IBoatStateStrategy CreateBoatStrategy()
        {
            return new BoatStateWithPaddlesAndEngine();
        }
    }
}
