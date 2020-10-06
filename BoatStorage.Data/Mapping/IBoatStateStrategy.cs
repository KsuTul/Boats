namespace Boatstorage.Data.Mapping
{
    public interface IBoatStateStrategy
    {
        BoatStatus GetQualityStatus(IBoatStateParameters model, ICurrentParameters currentState);
    }
}
