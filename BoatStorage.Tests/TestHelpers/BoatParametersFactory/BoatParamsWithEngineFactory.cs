namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data.Mapping;
    using BoatStorage.Data;
    using BoatStorage.Services;

    public class BoatParamsWithEngineFactory : BoatParametersFactory
    {
        public BoatParamsWithEngineFactory(int corpusStatus, int dayToAdd, int currentDistance, int paramForDistance, bool engine)
        {
            this.CorpusStatus = corpusStatus;
            this.IsEngine = engine;
            this.DayToAdd = dayToAdd;
            this.CurrentDistance = currentDistance;
            this.ParamsForDistante = paramForDistance;
        }

        private int CorpusStatus { get; set; }

        private int DayToAdd { get; set; }

        private int CurrentDistance { get; set; }

        private int ParamsForDistante { get; set; }

        private bool IsEngine { get; set; }

        public override IBoatStateParameters CreateBoatParameters()
        {
            return new BoatParamsWithEngine()
            {
                CorpusStatus = this.CorpusStatus,
                InspectionPeriod = TestsHelpersConsts.InspectionPeriod,
                IsEngine = this.IsEngine,
                LastDayInspection = DateTime.Now.AddMonths(-TestsHelpersConsts.InspectionPeriod).AddDays(this.DayToAdd),
                WorkingHoursOnLastCheckIn = (this.CurrentDistance - TestsHelpersConsts.PeriodOfWorkingHours) + this.ParamsForDistante,
                PeriodOfWorkingHoursForNextCheckIn = TestsHelpersConsts.PeriodOfWorkingHours,
                PeriodOfOilChange = TestsHelpersConsts.PeriodOfOilChange,
                LastDayOfOilChange = DateTime.Now.AddMonths(-TestsHelpersConsts.PeriodOfOilChange).AddDays(this.DayToAdd),
            };
        }
    }
}
