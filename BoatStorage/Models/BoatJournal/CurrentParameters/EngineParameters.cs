namespace BoatStorage.Models.BoatJournal
{
    using System;

    public class EngineParameters : IEngineParameters
    {
        public DateTime CurrentDay { get; set; }

        public int Distance { get; set; }
    }
}
