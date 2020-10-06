namespace FloatStorage.Tests.TestHelpers
{
    using System;
    using Boatstorage.Data.Mapping;
    using BoatStorage.Data;

    public class BoatCorpusParamsFactory : BoatParametersFactory
    {
        public BoatCorpusParamsFactory(int corpusStatus, int dayToAdd)
        {
            this.CorpusStatus = corpusStatus;
            this.DayToAdd = dayToAdd;
        }

        private int CorpusStatus { get; set; }

        private int DayToAdd { get; set; }

        public override IBoatStateParameters CreateBoatParameters()
        {
            return new BoatParams()
            {
                CorpusStatus = this.CorpusStatus,
                InspectionPeriod = TestsHelpersConsts.InspectionPeriod,
                LastDayInspection = DateTime.Now.AddMonths(-TestsHelpersConsts.InspectionPeriod).AddDays(this.DayToAdd),
            };
        }
    }
}
