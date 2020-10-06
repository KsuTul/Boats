namespace BoatStorage.Services.Tests
{
    using Boatstorage.Data;

    public class ConstsForTests
    {
        public const string CatamaranType = nameof(Catamaran);
        public const string CanoeType = nameof(Canoe);
        public const string MotorboatType = nameof(Motorboat);
        public const string HuntingBoatType = nameof(HuntingBoat);
        public const string InflatableBoatType = nameof(InflatableBoat);
        public const string PaddlesKey = nameof(Canoe.NumberOfPaddles);
        public const string EnginePowerKey = nameof(Engine) + "." + nameof(Engine.Power);
        public const string EngineManufacturerKey = nameof(Engine) + "." + nameof(Engine.Manufacturer);
        public const string EngineManufacturerValue = "Yamaha";
        public const string EnginePowerValue = "60";
        public const string PaddlesValue = "2";
        public const int Id = 1;
        public const int NotExisistId = 9;
        public const int NumberOfPaddles = 2;
        public const int NumOfPaddles = 3;
        public const int Power = 60;
        public const string Paddles = "1";
        public const string SpecParamPower = "80";
        public const string SpecParamManufacturer = "BoatMarine";
    }
}
