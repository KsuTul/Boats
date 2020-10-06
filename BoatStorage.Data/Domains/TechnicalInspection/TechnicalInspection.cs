namespace BoatStorage.Data
{
    using Boatstorage.Data.Mapping;

    public class TechnicalInspection : IBoatStateParameters
    {
        public int Id { get; set; }

        public IBoatStateParameters BoatStateParameters { get; set; }
    }
}
