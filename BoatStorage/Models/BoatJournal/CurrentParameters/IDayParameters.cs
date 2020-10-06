namespace BoatStorage.Models.BoatJournal
{
    using System;

    public interface IDayParameters : ICurrentParameters
    {
       DateTime CurrentDay { get; set; }
    }
}
