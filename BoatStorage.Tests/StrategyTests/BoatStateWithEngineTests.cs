namespace FloatStorage.Tests.StrategyTests
{
    using Boatstorage.Data;
    using BoatStorage.Data;
    using BoatStorage.Services;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class BoatStateWithEngineTests
    {
        [Fact]
        public void GetEngineStatus_EngineStatus_ReturnOk()
        {
            // Arrange
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithEngineFactory(10, 1, currentEngineParameter.Distance, 1, true);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithEngineFactory();
            var boatState = (BoatStateWithEngine)strategyFactory.CreateBoatStrategy();

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
            var boatParametersFactory = new BoatParamsWithEngineFactory(10, -1, 50, -1, true);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithEngineFactory();
            var boatState = (BoatStateWithEngine)strategyFactory.CreateBoatStrategy();

            // Act
            var engineStatus = boatState.GetEngineStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(EngineStatus.Change_Oil, engineStatus);
        }

        [Theory]
        [InlineData(10, 1, 1, true)]
        [InlineData(9, 1, 1, true)]
        [InlineData(8, 1, 1, true)]
        public void GetQualityStatus_BoatStatuses_ReturnOk(int corpusStatus, int dayToAdd, int engineParams, bool isEngine)
        {
            // Arrange
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithEngineFactory(corpusStatus, dayToAdd, currentEngineParameter.Distance, engineParams, isEngine);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithEngineFactory();
            var boatState = (BoatStateWithEngine)strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(BoatStatus.Ok, boatStatus);
        }

        [Theory]
        [InlineData(10, -1, 1, true)]
        [InlineData(9, -1, 1, true)]
        [InlineData(8, -1, 1, true)]
        [InlineData(7, -1, -1, true)]
        [InlineData(6, 1, 1, true)]
        [InlineData(5, -1, -1, true)]
        [InlineData(4, 1, 1, true)]
        public void GetQualityStatus_BoatStatuses_ReturnInCheckUp(int corpusStatus, int dayToadd, int paramsForDistance, bool isEngine)
        {
            // Arrange
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithEngineFactory(corpusStatus, dayToadd, currentEngineParameter.Distance, paramsForDistance, isEngine);
            var engineParameters = boatParametersFactory.CreateBoatParameters();
            var strategyFactory = new BoatStateWithEngineFactory();
            var boatState = (BoatStateWithEngine)strategyFactory.CreateBoatStrategy();

            // Act
            var boatStatus = boatState.GetQualityStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(BoatStatus.InCheckUp, boatStatus);
        }

        [Theory]
        [InlineData(10, 1, -1, false, 1)]
        [InlineData(9, 1, -1, false, 1)]
        [InlineData(8, -1, 1, false, 1)]
        [InlineData(7, 1, 1, false, 1)]
        [InlineData(6, 1, -1, false, -1)]
        [InlineData(5, 1, -1, false, 1)]
        [InlineData(4, 1, -1, false, 1)]
        [InlineData(1, 1, 1, true, 50)]
        [InlineData(2, -1, -1, true, 50)]
        [InlineData(3, 1, 1, true, 50)]
        public void GetQualityStatus_BoatStatuses_ReturnInRepair(int corpusStatus, int dayToadd, int paramsForDistance, bool isEngine, int dist)
        {
            // Arrange
            var strategyFactory = new BoatStateWithEngineFactory();
            var boatState = (BoatStateWithEngine)strategyFactory.CreateBoatStrategy();
            var curentParametrsFactory = new CurrentParamsForEngineFactory();
            var currentEngineParameter = (EngineParameters)curentParametrsFactory.CreateCurrentParameters();
            var boatParametersFactory = new BoatParamsWithEngineFactory(corpusStatus, dayToadd, dist, paramsForDistance, isEngine);
            var engineParameters = boatParametersFactory.CreateBoatParameters();

            // Act
            var boatStatus = boatState.GetQualityStatus(engineParameters, currentEngineParameter);

            // Assert
            Assert.Equal(BoatStatus.InRepair, boatStatus);
        }
    }
}
