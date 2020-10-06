namespace BoatStorage.Models.BoatJournal
{
    using FloatingLibrary.Models;

    public interface IBoatStateStrategy
    {
        BoatStatuses GetQualityStatus(IBoatStateParameters model, ICurrentParameters currentState);
    }
}
