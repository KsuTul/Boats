namespace BoatStorage.Models.BoatJournal
{
    public class JournalEntryAboutCurrentState
    {
        public int Id { get; set; }

        public ICurrentParameters CurrentParameters { get; set; }
    }
}
