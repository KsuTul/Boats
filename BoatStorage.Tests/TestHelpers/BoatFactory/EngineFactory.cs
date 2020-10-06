namespace FloatStorage.Tests.TestHelpers
{
    using Boatstorage.Data;

    public class EngineFactory
    {
        public Engine GetEngine(int? power, int? paramForDistance, int? dayForEngine, string engineManufacturer)
        {
            return new Engine()
            {
                Manufacturer = engineManufacturer,
                Power = power.Value,
            };
        }
    }
}
