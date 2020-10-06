namespace BoatStorage.Data
{
    using System;
    using Boatstorage.Data.Mapping;

    public class BoatsSimple : ICorpusStatus
    {
        public int CorpusStatus { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime LastDayInspection { get; set; }
    }
}
