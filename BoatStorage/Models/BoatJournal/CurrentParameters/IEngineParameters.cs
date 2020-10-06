namespace BoatStorage.Models.BoatJournal
{
    using System;

    public interface IEngineParameters : ICurrentParameters
    {
        DateTime CurrentDay { get; set; }

        int Distance { get; set; }
    }
}
