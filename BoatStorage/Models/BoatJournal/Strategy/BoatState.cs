namespace BoatStorage.Models.BoatJournal
{
    using FloatingLibrary.Models;

    public class BoatState : IBoatStateStrategy
    {
        public BoatStatuses GetQualityStatus(IBoatStateParameters stateParameters, ICurrentParameters currentState)
        {
            var boatParameters = (ICorpusStatus)stateParameters;
            var currentParams = (IDayParameters)currentState;
            var futureDayOfInspection = boatParameters.LastDayInspection.AddMonths(boatParameters.InspectionPeriod);
            if (boatParameters.CorpusStatus > 7 && (futureDayOfInspection > currentParams.CurrentDay))
            {
                return BoatStatuses.Ok;
            }

            if ((boatParameters.CorpusStatus > 3) ||
                (boatParameters.CorpusStatus > 7
                && (futureDayOfInspection < currentParams.CurrentDay)))
            {
                return BoatStatuses.InCheckUp;
            }

            return BoatStatuses.InRepair;
        }
    }
}
