namespace Boatstorage.Data.DAO
{
    public partial class CurrentParamsJournalSpecParams
    {
        public int Id { get; set; }

        public int CurrentParamsJournalId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public virtual CurrentParamsJournal CurrentParamsJournal { get; set; }
    }
}
