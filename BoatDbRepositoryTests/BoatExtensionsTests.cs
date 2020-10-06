namespace BoatStorage.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Boatstorage.Data;
    using Boatstorage.Data.DAO;
    using BoatStorage.Services;
    using FloatStorage.Tests.TestHelpers;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Xunit;

    public class BoatExtensionsTests
    {
        [Theory]
        [InlineData(BoatType.Catamaran, ConstsForTests.CatamaranType)]
        public void MapToBaseDomainBoat_CheckMapAllBaseParams_MapAllBaseParams(BoatType boatType, string type )
        {
            // Arrange
            var boatFactory = new BoatUniversalFactory(boatType);
            var domainBoat = boatFactory.CreateBoat();
            var daoBoat = ListsOfBoats.GetBoatbyType(type);

            // Act
            BoatExtensions.MapToBaseDomainBoat(daoBoat, domainBoat);

            // Assert
            Assert.Equal(daoBoat.Id, domainBoat.Id);
            Assert.Equal(daoBoat.Manufacturer, domainBoat.Manufacturer);
            Assert.Equal(daoBoat.Displacement, domainBoat.Displacement);
            Assert.Equal(daoBoat.Speed, domainBoat.Speed);
            Assert.Equal(daoBoat.NumberOfSeats, domainBoat.NumberOfSeats);
        }

        [Theory]
        [InlineData(nameof(Int32), ConstsForTests.PaddlesKey, ConstsForTests.PaddlesValue)]
        [InlineData(nameof(Nullable<int>), ConstsForTests.EnginePowerKey, ConstsForTests.EnginePowerValue)]
        [InlineData(nameof(String), ConstsForTests.EngineManufacturerKey, ConstsForTests.EngineManufacturerValue)]
        public void GetSpecParameter_CheckGetSpecParam_GetSpecParam(string type, string key, string value)
        {
            // Arrange
            var boatFactory = new BoatFactory(key, value, ConstsForTests.InflatableBoatType);
            var boat = boatFactory.CreateAndInitBoat();
            var comparassionValue = HelpersForTests.GetValue( type, value);

            // Act
            var parameter = HelpersForTests.GetSpecParameter(boat, key, type);

            // Assert
            Assert.Equal(comparassionValue, parameter);
        }

        [Theory]
        [InlineData(nameof(Int32), 0)]
        [InlineData(nameof(Nullable<int>), null)]
        public void GetSpecParameter_CheckGetSpecParam_GetDefaultNull(string type, object value)
        {
            // Arrange
            var boatFactory = new BoatFactory(null, null, ConstsForTests.InflatableBoatType);
            var boat = boatFactory.CreateAndInitBoat();

            // Act
            var parameter = HelpersForTests.GetSpecParameter(boat, null, type);

            // Assert
            Assert.Equal(value, parameter);
        }

        [Theory]
        [InlineData(ConstsForTests.EnginePowerKey, ConstsForTests.EnginePowerValue, ConstsForTests.EngineManufacturerKey, ConstsForTests.EngineManufacturerValue)]
        public void GetEngineParameters_CheckGetEngineParameters_GetEngine(string powereKey, string powerValue, string manufacturerKey, string manufacturerValue)
        {
            // Arrange
            Engine engine;
            var boatFactory = new BoatFactoryForEngine(powereKey, powerValue, manufacturerKey, manufacturerValue);
            var boat = boatFactory.CreateAndInitBoat();

            // Act
            engine = boat.GetEngineParameters();

            // Assert
            Assert.Equal(HelpersForTests.GetValue(nameof(String), ConstsForTests.EngineManufacturerValue), engine.Manufacturer);
            Assert.Equal(HelpersForTests.GetValue(nameof(Nullable<int>), powerValue), engine.Power);
        }

        [Fact]
        public void GetEngineParameters_CheckGetEnginParameters_GetNull()
        {
            // Arrange
            Engine engine;
            var boatFactory = new BoatFactory(null, null, null);
            var boat = boatFactory.CreateAndInitBoat();

            // Act
            engine = boat.GetEngineParameters();

            // Assert
            Assert.Null(engine);
        }

        [Theory]
        [InlineData(nameof(Catamaran), ConstsForTests.CatamaranType)]
        [InlineData(nameof(Canoe), ConstsForTests.CanoeType)]
        [InlineData(nameof(HuntingBoat), ConstsForTests.HuntingBoatType)]
        [InlineData(nameof(Motorboat), ConstsForTests.MotorboatType)]
        [InlineData(nameof(InflatableBoat), ConstsForTests.InflatableBoatType)]

        public void MapToDomainBoat_CheckToReturnFloatingCraft_ReturnFloatingCraft(string type, string boatType)
        {
            // Arrange
            var boatFactory = new BoatFactory(null, null, boatType);
            var boat = boatFactory.CreateAndInitBoat();
            var comparassionBoatType = HelpersForTests.GetType(type);

            // Act
            var floatingCrafts = boat.MapToDomainBoat();

            // Assert
            Assert.IsType(comparassionBoatType, floatingCrafts);
        }

        [Fact]
        public void MapToDomainBoat_CheckToReturnExeption_ReturnExeption()
        {
            // Arrange
            var boatFactory = new BoatFactory(null, null, "Boat");
            var boat = boatFactory.CreateAndInitBoat();

            // Act
            var retException = Assert.Throws<ArgumentException>(() => BoatExtensions.MapToDomainBoat(boat));

            // Assert
            Assert.IsType<ArgumentException>(retException);
            Assert.Equal(BoatExtensions.ErrorMessage, retException.Message);
        }

        /// <summary>
        /// Testing MapToBaseDAOBoat to check that method returns all base params in Boat.
        /// </summary>
        [Theory]
        [InlineData(BoatType.Catamaran, ConstsForTests.CatamaranType)]
        [InlineData(BoatType.Canoe, ConstsForTests.CanoeType)]
        [InlineData(BoatType.HuntingBoat, ConstsForTests.HuntingBoatType)]
        [InlineData(BoatType.Motorboat, ConstsForTests.MotorboatType)]
        [InlineData(BoatType.InflatableBoat, ConstsForTests.InflatableBoatType)]
        public void MapToBaseDAOBoat_CheckToMapAllBaseParams_MapAllBaseParams(BoatType boatType, string comparedBoatType)
        {
            // Arrange
            var boatFactory = new FloatingCraftsFactory(boatType);
            var domainBoat = boatFactory.CreateAndInitBoat();
            var daoBoat = new Boat();

            // Act
            daoBoat.MapToBaseDAOBoat(domainBoat);

            // Assert
            Assert.Equal(domainBoat.Manufacturer, daoBoat.Manufacturer);
            Assert.Equal(domainBoat.Displacement, daoBoat.Displacement);
            Assert.Equal(domainBoat.Speed, daoBoat.Speed);
            Assert.Equal(domainBoat.NumberOfSeats, daoBoat.NumberOfSeats);
            Assert.Equal(comparedBoatType, daoBoat.BoatType);
        }

        [Theory]
        [InlineData(ConstsForTests.PaddlesKey, ConstsForTests.PaddlesValue)]
        [InlineData(ConstsForTests.EngineManufacturerKey, ConstsForTests.EngineManufacturerValue)]
        [InlineData(ConstsForTests.EnginePowerKey, ConstsForTests.EnginePowerValue)]
        public void MapSpecParam_CheckToCreateSpecParamsWithValue_CreateSpecParamsWithValue(string keyParam, string valueParam)
        {
            // Arrange
            var daoBoat = new Boat() { BoatsSpecificParameters = new List<BoatSpecificParameters>(), };

            // Act
            daoBoat.MapSpecParam(keyParam, valueParam);

            // Assert
            Assert.Equal(keyParam, daoBoat.BoatsSpecificParameters.First(x => x.Value == valueParam).Key);
            Assert.Equal(valueParam, daoBoat.BoatsSpecificParameters.First(x => x.Key == keyParam).Value);
        }

        [Theory]
        [InlineData(ConstsForTests.PaddlesKey, ConstsForTests.PaddlesValue, ConstsForTests.Paddles)]
        [InlineData(ConstsForTests.EngineManufacturerKey, ConstsForTests.EngineManufacturerValue, ConstsForTests.SpecParamManufacturer)]
        [InlineData(ConstsForTests.EnginePowerKey, ConstsForTests.EnginePowerValue, ConstsForTests.SpecParamPower)]
        public void MapSpecParam_CheckToMapSpecParamWithNewValue_MapSpecParamWithNewValue(string keyParam, string valueParam, string valueDAO)
        {
            // Arrange
            var daoBoat = new Boat() { BoatsSpecificParameters = new List<BoatSpecificParameters>() { new BoatSpecificParameters() { Key = keyParam, Value = valueDAO } }, };

            // Act
            daoBoat.MapSpecParam(keyParam, valueParam);

            // Assert
            Assert.Equal(keyParam, daoBoat.BoatsSpecificParameters.First(x => x.Value == valueParam).Key);
            Assert.Equal(valueParam, daoBoat.BoatsSpecificParameters.First(x => x.Key == keyParam).Value);
        }

        [Theory]
        [InlineData(BoatType.Canoe)]
        [InlineData(BoatType.HuntingBoat)]
        [InlineData(BoatType.InflatableBoat)]
        public void MapToDaoModels_CheckToReturnBoatWithPaddles_ReturnBoatWithPaddles(BoatType boatType)
        {
            // Arrange
            var boatFactory = new FloatingCraftsFactory(boatType);
            var domainBoat = boatFactory.CreateAndInitBoat();
            var daoBoat = new Boat() { BoatsSpecificParameters = new List<BoatSpecificParameters>(), };

            // Act
            daoBoat.MapToDaoModels(domainBoat);

            // Assert
            Assert.Equal(ConstsForTests.NumberOfPaddles.ToString(), daoBoat.BoatsSpecificParameters.First(x => x.Key == nameof(Canoe.NumberOfPaddles)).Value);
        }

        [Theory]
        [InlineData(BoatType.Motorboat)]
        [InlineData(BoatType.InflatableBoat)]
        public void MapToDaoModels_CheckToReturnBoatWithEngine_ReturnBoatWithEngine(BoatType boatType)
        {
            // Arrange
            var boatFactory = new FloatingCraftsFactory(boatType);
            var domainBoat = boatFactory.CreateAndInitBoat();
            var daoBoat = new Boat() { BoatsSpecificParameters = new List<BoatSpecificParameters>(), };

            // Act
            daoBoat.MapToDaoModels(domainBoat);

            // Assert
            Assert.Equal(ConstsForTests.Power.ToString(), daoBoat.BoatsSpecificParameters.First(x => x.Key == nameof(Engine) + nameof(Engine.Power)).Value);
            Assert.Equal(ConstsForTests.EngineManufacturerValue, daoBoat.BoatsSpecificParameters.First(x => x.Key == nameof(Engine) + nameof(Engine.Manufacturer)).Value);
        }

        [Theory]
        [InlineData(BoatType.Catamaran)]
        [InlineData(BoatType.Canoe)]
        [InlineData(BoatType.InflatableBoat)]
        [InlineData(BoatType.Motorboat)]
        [InlineData(BoatType.HuntingBoat)]
        public void MapToDaoModels_CheckToReturnBoatWithoutSpecParams_ReturnBoatWithoutSpecParams(BoatType boatType)
        {
            // Arrange
            var boatFactory = new BoatUniversalFactory(boatType);
            var domainBoat = boatFactory.CreateBoat();
            var daoBoat = new Boat() { BoatsSpecificParameters = new List<BoatSpecificParameters>(), };

            // Act
            daoBoat.MapToDaoModels(domainBoat);

            // Assert
            Assert.Empty(daoBoat.BoatsSpecificParameters);
        }
    }
}
