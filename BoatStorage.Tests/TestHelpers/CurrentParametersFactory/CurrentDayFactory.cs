namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data.Mapping;
    using BoatStorage.Data;
    using BoatStorage.Services;

    public class CurrentDayFactory : CurrentParametersFactory
    {
        public CurrentDayFactory()
        {
            this.CurrentDay = DateTime.Now;
        }

        private DateTime CurrentDay { get; set; }

        public override ICurrentParameters CreateCurrentParameters()
        {
            return new DayParameters()
            {
                CurrentDay = this.CurrentDay,
            };
        }
    }
}
