namespace Boatstorage.Data.DAO
{
    using System.Collections.Generic;

    public partial class Boat
    {
        public Boat()
        {
            this.BoatsSpecificParameters = new HashSet<BoatSpecificParameters>();
            this.CurrentParamsJournal = new HashSet<CurrentParamsJournal>();
            this.InspectionJournal = new HashSet<InspectionJournal>();
        }

        public int Id { get; set; }

        public string BoatType { get; set; }

        public string Name { get; set; }

        public int Displacement { get; set; }

        public int Speed { get; set; }

        public string Manufacturer { get; set; }

        public int NumberOfSeats { get; set; }

        public virtual ICollection<BoatSpecificParameters> BoatsSpecificParameters { get; set; }

        public virtual ICollection<CurrentParamsJournal> CurrentParamsJournal { get; set; }

        public virtual ICollection<InspectionJournal> InspectionJournal { get; set; }
    }
}
