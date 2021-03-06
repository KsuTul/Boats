﻿namespace BoatStorage.Models.BoatJournal
{
    using System;

    public interface ICorpusStatus : IBoatStateParameters
    {
        int CorpusStatus { get; set; }

        int InspectionPeriod { get; set; }

        DateTime LastDayInspection { get; set; }
    }
}
