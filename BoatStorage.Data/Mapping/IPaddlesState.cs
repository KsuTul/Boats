namespace Boatstorage.Data.Mapping
{
    public interface IPaddlesState : IBoatStateParameters
    {
        bool HavePaddles { get; set; }
    }
}
