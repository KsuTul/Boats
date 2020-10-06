namespace Boatstorage.Data.DAO
{
    public partial class InspectionJournalsSpecParams
    {
        public int Id { get; set; }

        public int TechnicalJournalId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public virtual InspectionJournal TechnicalJournal { get; set; }
    }
}
