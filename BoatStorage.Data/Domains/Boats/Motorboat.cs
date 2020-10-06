namespace Boatstorage.Data
{
    using Boatstorage.Data.Mapping;
    using System.Text;

    public class Motorboat : FloatingCrafts, IBoat
    {
        public Engine Engine { get; set; }

        public override string ToString()
        {
            var retVal = new StringBuilder();
            retVal.AppendLine("Тип : " + this.Name)
            .AppendLine("Водоизмещение : " + this.Displacement + "л")
            .AppendLine("Скорость : " + this.Speed + " км/ч")
            .AppendLine("Количество мест : " + this.NumberOfSeats)
            .AppendLine("Производитель : " + this.Manufacturer);
            if (this.Engine != null)
            {
                retVal.AppendLine("Мотор : " + this.Engine.Manufacturer + this.Engine.Power);
            }
            else
            {
                retVal.AppendLine("Мотор отсутствует");
            }

            return retVal.ToString();
        }
    }
}
