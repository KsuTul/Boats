namespace BoatStorage.Models.BoatJournal
{
    public interface IPaddlesState : IBoatStateParameters
    {
        bool HavePaddles { get; set; }
    }
}
