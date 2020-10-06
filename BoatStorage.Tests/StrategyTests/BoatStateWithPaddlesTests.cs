namespace FloatStorage.Tests.StrategyTests
{
    using Boatstorage.Data;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class BoatStateWithPaddlesTests
    {
        [Theory]
        [InlineData(10, 1, true)]
        [InlineData(9, 1, true)]
        [InlineData(8, 1, true)]
        public void GetQualityStatus_BoatStatuses_ReturnOk(int corpusStatus, int dayToAdd, bool havePaddles)
        {
            // Arrange
            var boatParametersFactory = new BoatParamsWithPaddlesFactory(corpusStatus, dayToAdd, havePaddles);
            var paddlesParameters = boatParametersFactory.CreateBoatParameters();
            var curentParametrsFactory = new CurrentDayFactory();
            var currentDayParameter = curentParametrsFactory.CreateCurrentParameters();
            var strategyFactory = new BoatStateWithPaddlesFactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(paddlesParameters, currentDayParameter);

            // Assert
            Assert.Equal(BoatStatus.Ok, boatStatus);
        }

        [Theory]
        [InlineData(10, -1, true)]
        [InlineData(9, -1, true)]
        [InlineData(8, -1, true)]
        [InlineData(7, -1, true)]
        [InlineData(6, 1, true)]
        [InlineData(5, -1, true)]
        [InlineData(4, 1, true)]
        public void GetQualityStatus_BoatStatuses_ReturnInCheckUp(int corpusStatus, int dayToadd, bool havePaddles)
        {
            // Arrange
            var boatParametersFactory = new BoatParamsWithPaddlesFactory(corpusStatus, dayToadd, havePaddles);
            var corpusParameters = boatParametersFactory.CreateBoatParameters();
            var curentParametrsFactory = new CurrentDayFactory();
            var currentDayParameter = curentParametrsFactory.CreateCurrentParameters();
            var strategyFactory = new BoatStateWithPaddlesFactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(corpusParameters, currentDayParameter);

            // Assert
            Assert.Equal(BoatStatus.InCheckUp, boatStatus);
        }

        [Theory]
        [InlineData(10, 1, false)]
        [InlineData(9, 1, false)]
        [InlineData(8, 1, false)]
        [InlineData(7, -1, false)]
        [InlineData(5, -1, false)]
        [InlineData(4, 1, false)]
        [InlineData(1, 1, true)]
        [InlineData(2, -1, false)]
        [InlineData(3, 1, true)]
        public void GetQualityStatus_BoatStatuses_ReturnInRepair(int corpusStatus, int dayToadd, bool havePaddles)
        {
            // Arrange
            var boatParametersFactory = new BoatParamsWithPaddlesFactory(corpusStatus, dayToadd, havePaddles);
            var corpusParameters = boatParametersFactory.CreateBoatParameters();
            var curentParametrsFactory = new CurrentDayFactory();
            var currentDayParameter = curentParametrsFactory.CreateCurrentParameters();
            var strategyFactory = new BoatStateWithPaddlesFactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(corpusParameters, currentDayParameter);

            // Assert
            Assert.Equal(BoatStatus.InRepair, boatStatus);
        }
    }
}
