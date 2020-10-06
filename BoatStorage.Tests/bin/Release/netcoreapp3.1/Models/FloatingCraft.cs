namespace FloatingLibrary.Models
{
    using System;
    using System.Text;
    using FloatingLibrary.Helpers;

    public class FloatingCraft : IBoat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Displacement { get; set; }

        public int Speed { get; set; }

        public int NumberOfSeats { get; set; }

        public string Manufacturer { get; set; }

        public int CorpusStatus { get; set; }

        public DateTime LastDayInspection { get; set; }

        public int InspectionPeriod { get; set; }

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

        public DateTime GetFutureInspection()
        {
            return this.LastDayInspection.AddMonths(this.InspectionPeriod);
        }

        public BoatStatuses GetStatusInspection(DateTime today)
        {
            if (this.CorpusStatus > 7 && (this.GetFutureInspection() > today))
            {
                return BoatStatuses.Ok;
            }

            if (((this.GetFutureInspection() <= today) && this.CorpusStatus > 7) || (this.CorpusStatus > 3 && (this.GetFutureInspection() <= today || this.GetFutureInspection() > today)))
            {
                return BoatStatuses.InCheckUp;
            }

            return BoatStatuses.InRepair;
        }

        public virtual BoatStatuses GetQualityState(IQualityStateParameters statusParameters)
        {
           var boatParameters = statusParameters;
           return this.GetStatusInspection(boatParameters.DateToday);
        }
    }
}