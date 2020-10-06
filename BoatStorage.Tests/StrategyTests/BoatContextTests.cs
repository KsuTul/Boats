namespace FloatStorage.Tests.StrategyTests
{
    using System;
    using Boatstorage.Data;
    using BoatStorage.Services;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class Boats : FloatingCrafts
    {
    }

    public class BoatContextTests
    {
        [Fact]
        public void ChooseStrategy_IBoatStateStrategy_ReturnBoatStateStrategy()
        {
            // Arrange
            var boatFactory = new BoatUniversalFactory(BoatType.Catamaran);
            var boat = boatFactory.CreateBoat();

            // Act
            var strategy = BoatStrategyContext.ChooseStrategy(boat);

            // Assert
            Assert.NotNull(strategy);
            Assert.IsType<BoatState>(strategy);
        }

        [Fact]
        public void ChooseStrategy_IBoatStateStrategy_ReturnBoatStateWithEngineStrategy()
        {
            // Arrange
            var boatFactory = new BoatUniversalFactory(BoatType.Motorboat);
            var boat = boatFactory.CreateBoat();

            // Act
            var strategy = BoatStrategyContext.ChooseStrategy(boat);

            // Assert
            Assert.NotNull(strategy);
            Assert.IsType<BoatStateWithEngine>(strategy);
        }

        [Fact]
        public void ChooseStrategy_IBoatStateStrategy_ReturnBoatStateWithPaddlesAndEngineStrategy()
        {
            // Arrange
            var boatFactory = new BoatUniversalFactory(BoatType.InflatableBoat);
            var boat = boatFactory.CreateBoat();

            // Act
            var strategy = BoatStrategyContext.ChooseStrategy(boat);

            // Assert
            Assert.NotNull(strategy);
            Assert.IsType<BoatStateWithPaddlesAndEngine>(strategy);
        }

        [Theory]
        [InlineData(BoatType.Canoe)]
        [InlineData(BoatType.HuntingBoat)]
        public void ChooseStrategy_IBoatStateStrategy_ReturnBoatStateWithPaddles(BoatType boatType)
        {
            // Arrange
            var boatFactory = new BoatUniversalFactory(boatType);
            var boat = boatFactory.CreateBoat();

            // Act
            var strategy = BoatStrategyContext.ChooseStrategy(boat);

            // Assert
            Assert.NotNull(strategy);
            Assert.IsType<BoatStateWithPaddles>(strategy);
        }

        [Fact]
        public void ChooseStrategy_IBoatStateStrategy_ReturnException()
        {
            // Arrange
            Boats boat = new Boats();
            Exception ex = new ArgumentException("Ошибка");

            // Act
            try
            {
                var strategy = BoatStrategyContext.ChooseStrategy(boat);
            }
            catch
            {
                ex = Assert.Throws<ArgumentException>(() => BoatStrategyContext.ChooseStrategy(boat));
            }

            // Assert
            Assert.Equal("Ошибка", ex.Message);
        }
    }
}
