namespace Boatstorage.Data.Mapping
{
    public interface IBoat
    {
        int Id { get; set; }

        string Manufacturer { get; set; }

        string Name { get; set; }

        int Speed { get; set; }

        int NumberOfSeats { get; set; }

        int Displacement { get; set; }
    }
}
