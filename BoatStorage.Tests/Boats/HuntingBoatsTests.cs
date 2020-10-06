namespace FloatStorage.Tests
{
    using Boatstorage.Data;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class HuntingBoatsTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(0)]
        public void ToString_CheckBoatInAllEquipment_AllEquipment(int paddles)
        {
            // Arrange
            var boatFactory = new HuntingBoatFactory(paddles);
            var boat = (HuntingBoat)boatFactory.CreateBoat();

            // Act
            var stringResult = boat.ToString();

            // Assert
            Assert.Contains("Тип : " + boat.Name, stringResult);
            Assert.Contains("Водоизмещение : " + boat.Displacement + "л", stringResult);
            Assert.Contains("Скорость : " + boat.Speed + " км/ч", stringResult);
            Assert.Contains("Количество мест : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("Производитель : " + boat.Manufacturer, stringResult);
            Assert.Contains("Количество весел: " + boat.NumberOfPaddles, stringResult);
        }
    }
}