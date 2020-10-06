namespace BoatStorage.Models.BoatJournal
{
    using System;

    public class BoatParams : ICorpusStatus
    {
        public int CorpusStatus { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime LastDayInspection { get; set; }
    }
}
