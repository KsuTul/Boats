namespace Boatstorage.Data.Mapping
{
    using System;

    public interface IDayParameters : ICurrentParameters
    {
       DateTime CurrentDay { get; set; }
    }
}
