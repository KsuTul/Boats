namespace FloatStorage.Tests
{
    using Boatstorage.Data;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class InflatableBoatTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(0)]
        public void ToString_CheckBoatInAllEquipment_AllEquipment(int paddles)
        {
            // Arrange
            var boatFactory = new InflatableBoatFactory(true, paddles);
            var boat = (InflatableBoat)boatFactory.CreateBoat();

            // Act
            var stringResult = boat.ToString();

            // Assert
            Assert.Contains("Тип : " + boat.Name, stringResult);
            Assert.Contains("Водоизмещение : " + boat.Displacement + "л", stringResult);
            Assert.Contains("Скорость : " + boat.Speed + " км/ч", stringResult);
            Assert.Contains("Количество мест : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("Производитель : " + boat.Manufacturer, stringResult);
            Assert.Contains("Количество весел: " + boat.NumberOfPaddles, stringResult);
            Assert.Contains("Мотор : " + boat.Engine.Manufacturer + boat.Engine.Power, stringResult);
        }

        [Fact]
        public void ToString_CheckBoatInPartialEquipment_ExceptEngineAndPaddles()
        {
            // Arrange
            var boatFactory = new InflatableBoatFactory(false, 0);
            var boat = (InflatableBoat)boatFactory.CreateBoat();

            // Act
            var stringResult = boat.ToString();

            // Assert
            Assert.Contains("Тип : " + boat.Name, stringResult);
            Assert.Contains("Водоизмещение : " + boat.Displacement + "л", stringResult);
            Assert.Contains("Скорость : " + boat.Speed + " км/ч", stringResult);
            Assert.Contains("Количество мест : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("Производитель : " + boat.Manufacturer, stringResult);
            Assert.Contains("Количество весел: " + boat.NumberOfPaddles, stringResult);
            Assert.Contains("Мотор отсутствует", stringResult);
        }

        [Fact]
        public void ToString_CheckBoatInPartialEquipment_ExceptEngine()
        {
            // Arrange
            var boatFactory = new InflatableBoatFactory(false, 2);
            var boat = (InflatableBoat)boatFactory.CreateBoat();

            // Act
            var stringResult = boat.ToString();

            // Assert
            Assert.Contains("Тип : " + boat.Name, stringResult);
            Assert.Contains("Водоизмещение : " + boat.Displacement + "л", stringResult);
            Assert.Contains("Скорость : " + boat.Speed + " км/ч", stringResult);
            Assert.Contains("Количество мест : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("Производитель : " + boat.Manufacturer, stringResult);
            Assert.Contains("Количество весел: " + boat.NumberOfPaddles, stringResult);
            Assert.Contains("Мотор отсутствует", stringResult);
        }
    }
}
