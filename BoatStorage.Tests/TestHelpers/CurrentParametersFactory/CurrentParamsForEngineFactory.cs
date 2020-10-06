namespace FloatStorage.Tests.TestHelpers
{
    using Boatstorage.Data.Mapping;
    using BoatStorage.Data;
    using System;

    class CurrentParamsForEngineFactory : CurrentParametersFactory
    {
        public CurrentParamsForEngineFactory()
        {
            this.CurrentDay = DateTime.Now;
            this.Distance = TestsHelpersConsts.CurrentDistance;
        }

        private DateTime CurrentDay { get; set; }

        private int Distance { get; set; }

        public override ICurrentParameters CreateCurrentParameters()
        {
            return new EngineParameters()
            {
                CurrentDay = this.CurrentDay,
                Distance = this.Distance,
            };
        }
    }
}
