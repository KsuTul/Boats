namespace Boatstorage.Data
{
    using Boatstorage.Data.Mapping;
    using System.Text;

    public class HuntingBoat : FloatingCrafts, IBoat
    {
        public int NumberOfPaddles { get; set; }

        public override string ToString()
        {
            var retVal = new StringBuilder();
            retVal.AppendLine("Тип : " + this.Name)
            .AppendLine("Водоизмещение : " + this.Displacement + "л")
            .AppendLine("Скорость : " + this.Speed + " км/ч")
            .AppendLine("Количество мест : " + this.NumberOfSeats)
            .AppendLine("Производитель : " + this.Manufacturer)
            .AppendLine("Количество весел: " + this.NumberOfPaddles);
            return retVal.ToString();
        }
    }
}
