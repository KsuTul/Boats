namespace BoatStorage.Services
{
    using Boatstorage.Data;
    using Boatstorage.Data.Mapping;

    public class BoatState : IBoatStateStrategy
    {
        public BoatStatus GetQualityStatus(IBoatStateParameters stateParameters, ICurrentParameters currentState)
        {
            var boatParameters = (ICorpusStatus)stateParameters;
            var currentParams = (IDayParameters)currentState;
            var futureDayOfInspection = boatParameters.LastDayInspection.AddMonths(boatParameters.InspectionPeriod);
            if (boatParameters.CorpusStatus > 7 && (futureDayOfInspection > currentParams.CurrentDay))
            {
                return BoatStatus.Ok;
            }

            if ((boatParameters.CorpusStatus > 3) ||
                (boatParameters.CorpusStatus > 7
                && (futureDayOfInspection < currentParams.CurrentDay)))
            {
                return BoatStatus.InCheckUp;
            }

            return BoatStatus.InRepair;
        }
    }
}
