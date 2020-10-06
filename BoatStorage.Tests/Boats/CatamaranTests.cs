namespace FloatStorage.Tests.Boats
{
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class CatamaranTests
    {
        [Fact]
        public void ToString_CheckBoatInAllEquipment_AllEquipment()
        {
            // Arrange
            var boatFactory = new CatamaranFactory();
            var boat = boatFactory.CreateBoat();

            // Act
            var stringResult = boat.ToString();

            // Assert
            Assert.Contains("Тип : " + boat.Name, stringResult);
            Assert.Contains("Водоизмещение : " + boat.Displacement + "л", stringResult);
            Assert.Contains("Скорость : " + boat.Speed + " км/ч", stringResult);
            Assert.Contains("Количество мест : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("Производитель : " + boat.Manufacturer, stringResult);
        }
    }
}
