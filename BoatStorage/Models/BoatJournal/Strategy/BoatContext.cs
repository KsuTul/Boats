namespace BoatStorage.Models.BoatJournal
{
    using FloatingLibrary.Models;
    using System;

    public class BoatContext
    {
        public int Id { get; set; }

        public IBoatStateParameters BoatStateParameters { get; set; }

        public ICurrentParameters CurrentParameters { get; set; }

        public IBoatStateStrategy Strategy { get; set; }

        public static IBoatStateStrategy ChooseStrategy(FloatingCrafts boatType)
        {
            if (boatType is Canoe || boatType is HuntingBoat)
            {
                return new BoatStateWithPaddles();
            }

            if (boatType is Catamaran)
            {
                return new BoatState();
            }

            if (boatType is Motorboat)
            {
                return new BoatStateWithEngine();
            }

            if (boatType is InflatableBoat)
            {
                return new BoatStateWithPaddlesAndEngine();
            }

            throw new ArgumentException("Ошибка");
        }

        public BoatStatuses GetQualityStatus()
        {
            return Strategy.GetQualityStatus(this.BoatStateParameters, this.CurrentParameters);
        }
    }
}
