namespace FloatStorage.Tests.TestHelpers
{
    using Boatstorage.Data.Mapping;
    using BoatStorage.Services;

    public class BoatStateFactory : BoatStrategyFactory
    {
        public override IBoatStateStrategy CreateBoatStrategy()
        {
            return new BoatState();
        }
    }
}
