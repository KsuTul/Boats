namespace FloatStorage.Tests.StrategyTests
{
    using Boatstorage.Data;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class BoatStateTests
    {
        [Theory]
        [InlineData(10, 1)]
        [InlineData(9, 1)]
        [InlineData(8, 1)]
        public void GetQualityStatus_BoatStatuses_ReturnOk(int corpusStatus, int dayAdd)
        {
            // Arrange
            var boatParametersFactory = new BoatCorpusParamsFactory(corpusStatus, dayAdd);
            var corpusParameters = boatParametersFactory.CreateBoatParameters();
            var curentParametrsFactory = new CurrentDayFactory();
            var currentDayParameter = curentParametrsFactory.CreateCurrentParameters();
            var strategyFactory = new BoatStateFactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(corpusParameters, currentDayParameter);

            // Assert
            Assert.Equal(BoatStatus.Ok, boatStatus);
        }

        [Theory]
        [InlineData(10, -1)]
        [InlineData(9, -1)]
        [InlineData(8, -1)]
        [InlineData(7, -1)]
        [InlineData(6, 1)]
        [InlineData(5, -1)]
        [InlineData(4, 1)]
        public void GetQualityStatus_BoatStatuses_ReturnInCheckUp(int corpusStatus, int dayToadd)
        {
            // Arrange
            var boatParametersFactory = new BoatCorpusParamsFactory(corpusStatus, dayToadd);
            var corpusParameters = boatParametersFactory.CreateBoatParameters();
            var curentParametrsFactory = new CurrentDayFactory();
            var currentDayParameter = curentParametrsFactory.CreateCurrentParameters();
            var strategyFactory = new BoatStateFactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(corpusParameters, currentDayParameter);

            // Assert
            Assert.Equal(BoatStatus.InCheckUp, boatStatus);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, -1)]
        [InlineData(3, 1)]
        public void GetQualityStatus_BoatStatuses_ReturnInRepair(int corpusStatus, int dayToadd)
        {
            // Arrange
            var boatParametersFactory = new BoatCorpusParamsFactory(corpusStatus, dayToadd);
            var corpusParameters = boatParametersFactory.CreateBoatParameters();
            var curentParametrsFactory = new CurrentDayFactory();
            var currentDayParameter = curentParametrsFactory.CreateCurrentParameters();
            var strategyFactory = new BoatStateFactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(corpusParameters, currentDayParameter);

            // Assert
            Assert.Equal(BoatStatus.InRepair, boatStatus);
        }
    }
}
