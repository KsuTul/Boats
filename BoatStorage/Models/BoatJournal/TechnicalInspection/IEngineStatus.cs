namespace BoatStorage.Models.BoatJournal
{
    using System;

    public interface IEngineStatus : IBoatStateParameters
    {
        DateTime LastDayOfOilChange { get; set; }

        int PeriodOfOilChange { get; set; }

        int PeriodOfWorkingHoursForNextCheckIn { get; set; }

        public int WorkingHoursOnLastCheckIn { get; set; }

        public bool IsEngine { get; set; }
    }
}
