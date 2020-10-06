namespace BoatStorage.Models.BoatJournal
{
    using System;

    public class BoatsSimple : ICorpusStatus
    {
        public int CorpusStatus { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime LastDayInspection { get; set; }
    }
}
