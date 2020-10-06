namespace Boatstorage.Data.DAO
{
    using System;
    using System.Collections.Generic;

    public partial class CurrentParamsJournal
    {
        public CurrentParamsJournal()
        {
            this.CurrentParamsJournalSpecParams = new HashSet<CurrentParamsJournalSpecParams>();
        }

        public int Id { get; set; }

        public int BoatId { get; set; }

        public DateTime LastDate { get; set; }

        public virtual Boat Boat { get; set; }

        public virtual ICollection<CurrentParamsJournalSpecParams> CurrentParamsJournalSpecParams { get; set; }
    }
}
