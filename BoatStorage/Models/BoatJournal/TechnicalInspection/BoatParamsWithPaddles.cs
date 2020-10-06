﻿namespace BoatStorage.Models.BoatJournal
{
    using System;

    public class BoatParamsWithPaddles : ICorpusStatus, IPaddlesState
    {
        public int CorpusStatus { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime LastDayInspection { get; set; }

        public bool HavePaddles { get; set; }
    }
}
