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
            Assert.Contains("��� : " + boat.Name, stringResult);
            Assert.Contains("������������� : " + boat.Displacement + "�", stringResult);
            Assert.Contains("�������� : " + boat.Speed + " ��/�", stringResult);
            Assert.Contains("���������� ���� : " + boat.NumberOfSeats, stringResult);
            Assert.Contains("������������� : " + boat.Manufacturer, stringResult);
        }
    }
}
