namespace BoatStorage.Services
{
    using Boatstorage.Data;
    using Boatstorage.Data.Mapping;

    public class BoatStateWithPaddles : IBoatStateStrategy
    {
        public BoatStatus GetQualityStatus(IBoatStateParameters stateParameters, ICurrentParameters currentState)
        {
            var boatParameters = (ICorpusStatus)stateParameters;
            var currentParams = (IDayParameters)currentState;
            var paddlesParameters = (IPaddlesState)stateParameters;
            var futureDayOfInspection = boatParameters.LastDayInspection.AddMonths(boatParameters.InspectionPeriod);
            if (boatParameters.CorpusStatus > 7 &&
                futureDayOfInspection > currentParams.CurrentDay &&
                paddlesParameters.HavePaddles == true)
            {
                return BoatStatus.Ok;
            }

            if (((boatParameters.CorpusStatus > 3) ||
                (boatParameters.CorpusStatus > 7 && futureDayOfInspection < currentParams.CurrentDay)) &&
                paddlesParameters.HavePaddles == true)
            {
                return BoatStatus.InCheckUp;
            }

            return BoatStatus.InRepair;
        }
    }
}
