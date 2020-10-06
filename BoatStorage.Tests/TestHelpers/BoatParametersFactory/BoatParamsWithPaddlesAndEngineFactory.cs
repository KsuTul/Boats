namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data.Mapping;
    using BoatStorage.Data;
    using BoatStorage.Services;

    public class BoatParamsWithPaddlesAndEngineFactory : BoatParametersFactory
    {
        public BoatParamsWithPaddlesAndEngineFactory(int corpusStatus, int dayToAdd, int currentDistance, int paramForDistance, bool engine, bool havePaddles)
        {
            this.CorpusStatus = corpusStatus;
            this.HavePaddles = havePaddles;
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

        private bool HavePaddles { get; set; }

        public override IBoatStateParameters CreateBoatParameters()
        {
            return new BoatParamsWithPaddlesAndEngine()
            {
                CorpusStatus = this.CorpusStatus,
                InspectionPeriod = TestsHelpersConsts.InspectionPeriod,
                LastDayInspection = DateTime.Now.AddMonths(-TestsHelpersConsts.InspectionPeriod).AddDays(this.DayToAdd),
                WorkingHoursOnLastCheckIn = (this.CurrentDistance - TestsHelpersConsts.PeriodOfWorkingHours) + this.ParamsForDistante,
                PeriodOfWorkingHoursForNextCheckIn = TestsHelpersConsts.PeriodOfWorkingHours,
                PeriodOfOilChange = TestsHelpersConsts.PeriodOfOilChange,
                LastDayOfOilChange = DateTime.Now.AddMonths(-TestsHelpersConsts.PeriodOfOilChange).AddDays(this.DayToAdd),
                IsEngine = this.IsEngine,
                HavePaddles = this.HavePaddles,
            };
        }
    }
}
