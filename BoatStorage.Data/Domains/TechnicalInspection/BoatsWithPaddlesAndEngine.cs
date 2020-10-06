namespace BoatStorage.Data
{
    using System;
    using Boatstorage.Data.Mapping;

    public class BoatsWithPaddlesAndEngine : ICorpusStatus, IEngineStatus, IPaddlesState
    {
        public int CorpusStatus { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime LastDayInspection { get; set; }

        public DateTime LastDayOfOilChange { get; set; }

        public int PeriodOfOilChange { get; set; }

        public int PeriodOfWorkingHoursForNextCheckIn { get; set; }

        public int WorkingHoursOnLastCheckIn { get; set; }

        public bool HavePaddles { get; set; }

        public bool IsEngine { get; set; }
    }
}
