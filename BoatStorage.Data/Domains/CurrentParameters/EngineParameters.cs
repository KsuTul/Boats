namespace BoatStorage.Data
{
    using System;
    using Boatstorage.Data.Mapping;

    public class EngineParameters : IEngineParameters
    {
        public DateTime CurrentDay { get; set; }

        public int Distance { get; set; }
    }
}
