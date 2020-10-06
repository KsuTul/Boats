namespace BoatStorage.Models.BoatJournal
{
    using FloatingLibrary.Models;

    public class BoatQualityStatus
    {
        public int Id { get; set; }

        public IBoatStateParameters BoatStateParameters { get; set; }

        public ICurrentParameters CurrentParameters { get; set; }

        public IBoatStateStrategy BoatState { private get; set; }

        public BoatStatuses GetQualityStatus(IBoatStateParameters model, ICurrentParameters currentState)
        {
            return this.BoatState.GetQualityStatus(this.BoatStateParameters, this.CurrentParameters);
        }
}
}
