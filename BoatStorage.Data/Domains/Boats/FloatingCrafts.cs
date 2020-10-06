namespace Boatstorage.Data
{
    using System.Text;
    using Boatstorage.Data.Mapping;

    public class FloatingCrafts : IBoat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BoatType { get; set; }

        public int Displacement { get; set; }

        public int Speed { get; set; }

        public int NumberOfSeats { get; set; }

        public string Manufacturer { get; set; }

        public override string ToString()
        {
           var retVal = new StringBuilder();
           retVal.AppendLine("Тип : " + this.Name)
           .AppendLine("Водоизмещение : " + this.Displacement + "л")
           .AppendLine("Скорость : " + this.Speed + " км/ч")
           .AppendLine("Количество мест : " + this.NumberOfSeats)
           .AppendLine("Производитель : " + this.Manufacturer);
           return retVal.ToString();
        }
    }
}