namespace FloatStorage.Tests.StrategyTests
{
    using Boatstorage.Data;
    using BoatStorage.Data;
    using BoatStorage.Services;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class BoatStateWithPaddlesAndEngineTests
    {
        [Fact]
        public void GetEngineStatus_EngineStatus_ReturnOk()
        {
            // Arrange
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithPaddlesAndEngineFactory(10, 1, currentEngineParameter.Distance, 1, true, true);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithPaddlesAndEnginefactory();
            var boatState = (BoatStateWithPaddlesAndEngine)strategyFactory.CreateBoatStrategy();

            // Act
            var engineStatus = boatState.GetEngineStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(EngineStatus.Ok, engineStatus);
        }

        [Fact]
        public void GetEngineStatus_EngineStatus_ReturnChangeOil()
        {
            // Arrange
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithPaddlesAndEngineFactory(10, -1, currentEngineParameter.Distance, -1, true, true);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithPaddlesAndEnginefactory();
            var boatState = (BoatStateWithPaddlesAndEngine)strategyFactory.CreateBoatStrategy();

            // Act
            var engineStatus = boatState.GetEngineStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(EngineStatus.Change_Oil, engineStatus);
        }

        [Theory]
        [InlineData(10, 1, true, 1, false)]
        [InlineData(9, 1, true, 1, false)]
        [InlineData(8, 1, true, 1, false)]
        [InlineData(10, 1, false, 1, true)]
        [InlineData(9, 1, false, 1, true)]
        [InlineData(8, 1, false, 1, true)]
        public void GetQualityStatus_BoatStatuses_ReturnOk(int corpusStatus, int dayToAdd, bool haveEngine, int engineParams, bool havePaddles)
        {
            // Arrange
            var strategyFactory = new BoatStateWithPaddlesAndEnginefactory();
            var boatState = strategyFactory.CreateBoatStrategy();
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithPaddlesAndEngineFactory(corpusStatus, dayToAdd, currentEngineParameter.Distance, engineParams, haveEngine, havePaddles);
            var engineParameters = boatParametersFactory.CreateBoatParameters();

            // Act
            var boatStatus = boatState.GetQualityStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(BoatStatus.Ok, boatStatus);
        }

        [Theory]
        [InlineData(10, -1, true, -1, false)]
        [InlineData(9, -1, true, 1, false)]
        [InlineData(8, -1, true, -1, false)]
        [InlineData(10, -1, false, 1, true)]
        [InlineData(9, -1, false, -1, true)]
        [InlineData(8, -1, false, -1, true)]
        [InlineData(7, -1, true, -1, false)]
        [InlineData(6, -1, true, 1, false)]
        [InlineData(5, -1, true, -1, false)]
        [InlineData(4, -1, false, 1, true)]
        [InlineData(7, 1, true, -1, false)]
        [InlineData(6, -1, false, 1, true)]
        [InlineData(5, -1, false, -1, true)]
        [InlineData(4, -1, true, 1, true)]

        public void GetQualityStatus_BoatStatuses_ReturnInCheckUp(int corpusStatus, int dayToAdd, bool haveEngine, int paramForEngine, bool havePaddles)
        {
            // Arrange
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithPaddlesAndEngineFactory(corpusStatus, dayToAdd, currentEngineParameter.Distance, paramForEngine, haveEngine, havePaddles);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithPaddlesAndEnginefactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(BoatStatus.InCheckUp, boatStatus);
        }

        [Theory]
        [InlineData(10, -1, false, -1, false)]
        [InlineData(9, -1, false, 1, false)]
        [InlineData(8, -1, false, -1, false)]
        [InlineData(10, -1, false, 1, false)]
        [InlineData(9, -1, false, -1, false)]
        [InlineData(8, -1, false, 1, false)]
        [InlineData(7, -1, false, -1, false)]
        [InlineData(6, -1, false, 1, false)]
        [InlineData(5, -1, false, -1, false)]
        [InlineData(4, -1, false, 1, false)]
        [InlineData(3, -1, false, 1, true)]
        [InlineData(2, 1, true, -1, false)]
        [InlineData(1, -1, false, 1, false)]

        public void GetQualityStatus_BoatStatuses_ReturnInRepair(int corpusStatus, int dayToAdd, bool haveEngine, int paramForEngine, bool havePaddles)
        {
            // Arrange
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithPaddlesAndEngineFactory(corpusStatus, dayToAdd, currentEngineParameter.Distance, paramForEngine, haveEngine, havePaddles);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithPaddlesAndEnginefactory();
            var boatState = strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(BoatStatus.InRepair, boatStatus);
        }
    }
}
