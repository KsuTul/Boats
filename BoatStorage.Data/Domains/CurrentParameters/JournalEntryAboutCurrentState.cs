namespace BoatStorage.Data
{
    using Boatstorage.Data.Mapping;

    public class JournalEntryAboutCurrentState
    {
        public int Id { get; set; }

        public ICurrentParameters CurrentParameters { get; set; }
    }
}
