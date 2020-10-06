namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data;

    public class BoatUniversalFactory : BoatsFactory
    {
        public BoatUniversalFactory(BoatType type)
        {
            this.BoatType = type;
        }

        private BoatType BoatType { get; set; }

        public override FloatingCrafts CreateBoat()
        {

            switch (this.BoatType)
            {
                case BoatType.Catamaran:
                    return new Catamaran();

                case BoatType.Canoe:
                    return new Canoe();

                case BoatType.HuntingBoat:
                    return new HuntingBoat();

                case BoatType.Motorboat:
                    return new Motorboat();

                case BoatType.InflatableBoat:
                    return new InflatableBoat();
            }

            throw new ArgumentException("Danger! Error!");
        }
    }
}
