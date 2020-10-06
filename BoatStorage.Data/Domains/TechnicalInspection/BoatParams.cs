namespace BoatStorage.Data
{
    using System;
    using Boatstorage.Data.Mapping;

    public class BoatParams : ICorpusStatus
    {
        public int CorpusStatus { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime LastDayInspection { get; set; }
    }
}
