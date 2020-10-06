namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data.Mapping;
    using BoatStorage.Data;
    using BoatStorage.Services;

    public class BoatParamsWithPaddlesFactory : BoatParametersFactory
    {
        public BoatParamsWithPaddlesFactory(int corpusStatus, int dayToAdd, bool havePaddles)
        {
            this.CorpusStatus = corpusStatus;
            this.DayToAdd = dayToAdd;
            this.HavePaddles = havePaddles;
        }

        private int CorpusStatus { get; set; }

        private int DayToAdd { get; set; }

        private bool HavePaddles { get; set; }

        public override IBoatStateParameters CreateBoatParameters()
        {
            return new BoatParamsWithPaddles()
            {
                CorpusStatus = this.CorpusStatus,
                InspectionPeriod = TestsHelpersConsts.InspectionPeriod,
                LastDayInspection = DateTime.Now.AddMonths(-TestsHelpersConsts.InspectionPeriod).AddDays(this.DayToAdd),
                HavePaddles = this.HavePaddles,
            };
        }
    }
}
