namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data;

    public abstract class BoatsFactory
    {
        public int CorpsStatus { get; set; }

        public DateTime DayOfInspection { get; set; }

        public int InspectionPeriod { get; set; }

        public abstract FloatingCrafts CreateBoat();
    }
}
