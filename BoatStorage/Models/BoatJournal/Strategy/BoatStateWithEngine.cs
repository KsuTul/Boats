namespace BoatStorage.Models.BoatJournal
{
    using FloatingLibrary.Models;

    public class BoatStateWithEngine : IBoatStateStrategy
    {
        public EngineStatus GetEngineStatus(IBoatStateParameters stateParameters, ICurrentParameters currentState)
        {
            var engineParameters = (IEngineStatus)stateParameters;
            var currentParams = (IEngineParameters)currentState;
            if ((engineParameters.LastDayOfOilChange.AddMonths(engineParameters.PeriodOfOilChange) > currentParams.CurrentDay) &&
                ((engineParameters.WorkingHoursOnLastCheckIn + engineParameters.PeriodOfOilChange) < currentParams.Distance))
            {
                return EngineStatus.Ok;
            }

            return EngineStatus.Change_Oil;
        }

        public BoatStatuses GetQualityStatus(IBoatStateParameters stateParameters, ICurrentParameters currentState)
        {
            var boatParameters = (ICorpusStatus)stateParameters;
            var engineParameters = (IEngineStatus)stateParameters;
            var currentParams = (IEngineParameters)currentState;
            var futureDayOfInspection = boatParameters.LastDayInspection.AddMonths(boatParameters.InspectionPeriod);
            if (boatParameters.CorpusStatus > 7 &&
                (futureDayOfInspection > currentParams.CurrentDay) &&
                (engineParameters.IsEngine == true && (this.GetEngineStatus(engineParameters, currentParams) == EngineStatus.Ok))
)
            {
                return BoatStatuses.Ok;
            }

            if ((boatParameters.CorpusStatus > 3 ||
                (boatParameters.CorpusStatus > 7 &&
                futureDayOfInspection < currentParams.CurrentDay)) && engineParameters.IsEngine == true)
            {
                return BoatStatuses.InCheckUp;
            }

            return BoatStatuses.InRepair;
        }
    }
}