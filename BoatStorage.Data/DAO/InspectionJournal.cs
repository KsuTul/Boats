namespace Boatstorage.Data.DAO
{
    using System;
    using System.Collections.Generic;

    public partial class InspectionJournal
    {
        public InspectionJournal()
        {
            this.InspectionJournalsSpecParams = new HashSet<InspectionJournalsSpecParams>();
        }

        public int Id { get; set; }

        public int BoatId { get; set; }

        public int CorpusStatus { get; set; }

        public int InspectionPeriod { get; set; }

        public DateTime LastDate { get; set; }

        public virtual Boat Boat { get; set; }

        public virtual ICollection<InspectionJournalsSpecParams> InspectionJournalsSpecParams { get; set; }
    }
}
