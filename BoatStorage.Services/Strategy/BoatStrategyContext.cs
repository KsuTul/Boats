namespace BoatStorage.Services
{
    using System;
    using Boatstorage.Data;
    using Boatstorage.Data.Mapping;

    public class BoatStrategyContext
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

        public BoatStatus GetQualityStatus()
        {
            return this.Strategy.GetQualityStatus(this.BoatStateParameters, this.CurrentParameters);
        }
    }
}
