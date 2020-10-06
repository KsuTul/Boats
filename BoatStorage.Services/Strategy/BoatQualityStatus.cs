namespace BoatStorage.Services
{
    using Boatstorage.Data;
    using Boatstorage.Data.Mapping;

    public class BoatQualityStatus
    {
        public int Id { get; set; }

        public IBoatStateParameters BoatStateParameters { get; set; }

        public ICurrentParameters CurrentParameters { get; set; }

        public IBoatStateStrategy BoatState { private get; set; }

        public BoatStatus GetQualityStatus(IBoatStateParameters model, ICurrentParameters currentState)
        {
            return this.BoatState.GetQualityStatus(this.BoatStateParameters, this.CurrentParameters);
        }
}
}
