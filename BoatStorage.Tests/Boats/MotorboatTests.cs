namespace FloatStorage.Tests
{
    using Boatstorage.Data;
    using FloatStorage.Tests.TestHelpers;
    using Xunit;

    public class MotorboatTests
    {
        [Fact]
        public void ToString_CheckBoatInAllEquipment_AllEquipment()
        {
            // Arrange
            var boatFactory = new MotorboatFactory(true);
            var boat = (Motorboat)boatFactory.CreateBoat();

            // Act
            var stringResult = boat.ToString();

            // Assert
            Assert.Contains("Тип : " + boat.Name, stringResult);
            Assert.Contains("Водоизмещение : " + boat.Displacement + "л", stringResult);
            Assert.Contains("Скорость : " + boat.Speed + " км/ч", stringResult);
            Assert.Contains("Количество мест : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("Производитель : " + boat.Manufacturer, stringResult);
            Assert.Contains("Мотор : " + boat.Engine.Manufacturer + boat.Engine.Power, stringResult);
        }

        [Fact]
        public void ToString_CheckBoatInPartialEquipment_ExceptEngine()
        {
            // Arrange
            var boatFactory = new MotorboatFactory(false);
            var boat = (Motorboat)boatFactory.CreateBoat();

            // Act
            var stringResult = boat.ToString();

            // Assert
            Assert.Contains("Тип : " + boat.Name, stringResult);
            Assert.Contains("Водоизмещение : " + boat.Displacement + "л", stringResult);
            Assert.Contains("Скорость : " + boat.Speed + " км/ч", stringResult);
            Assert.Contains("Количество мест : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("Производитель : " + boat.Manufacturer, stringResult);
            Assert.Contains("Мотор отсутствует", stringResult);
        }
    }
}
