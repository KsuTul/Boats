namespace FloatStorage.Tests.TestHelpers
{
    using Boatstorage.Data.Mapping;
    using BoatStorage.Services;

    public class BoatStateWithPaddlesFactory : BoatStrategyFactory
    {
        public override IBoatStateStrategy CreateBoatStrategy()
        {
            return new BoatStateWithPaddles();
        }
    }
}
