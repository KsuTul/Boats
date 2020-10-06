namespace Boatstorage.Data.Mapping
{
    using System;

    public interface IEngineParameters : ICurrentParameters
    {
        DateTime CurrentDay { get; set; }

        int Distance { get; set; }
    }
}
