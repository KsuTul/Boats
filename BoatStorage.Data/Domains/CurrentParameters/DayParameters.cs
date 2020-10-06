namespace BoatStorage.Data
{
    using System;
    using Boatstorage.Data.Mapping;

    public class DayParameters : IDayParameters
    {
        public DateTime CurrentDay { get; set; }
    }
}
