namespace BoatStorage.Models.BoatJournal
{
    public class TechnicalInspection : IBoatStateParameters
    {
        public int Id { get; set; }

        public IBoatStateParameters BoatStateParameters { get; set; }
    }
}
