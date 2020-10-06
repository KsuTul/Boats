namespace Boatstorage.Data.DAO
{
    public partial class BoatSpecificParameters
    {
        public int Id { get; set; }

        public int BoatId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public virtual Boat Boat { get; set; }
    }
}
