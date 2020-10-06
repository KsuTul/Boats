namespace BoatStorage.Services.Tests
{
    using System;
    using System.Linq;
    using Boatstorage.Data;
    using BoatStorage.Data;
    using Boatstorage.Data.Mapping;
    using Boatstorage.Services;
    using FloatStorage.Tests.TestHelpers;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Xunit;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class BoatRepositoryTests
    {
        [Fact]
        public async Task GetById_CheckReturnExistingBoat_ReturnExistingBoat()
        {
            // Arrange
            var domainfactory = new BoatFactoryInit().CreateAndInitBoat();
            var contextFactory = new BoatDbContextInMemoryFactory(Guid.NewGuid().ToString());
            var context = contextFactory.Create();
            context.Boats.Add(domainfactory);
            context.SaveChanges();
            var repository = new BoatRepository(contextFactory);

            // Act
            var boat = await repository.GetById(ConstsForTests.Id);

            // Assert
            Assert.Equal(context.Boats.FirstOrDefault(b => b.Id == ConstsForTests.Id).Id, boat.Id);
        }

        [Fact]
        public async Task GetById_CheckReturnUnexistingBoat_ReturnNull()
        {
            // Arrange
            var domainfactory = new BoatFactoryInit().CreateAndInitBoat();
            var contextFactory = new BoatDbContextInMemoryFactory(Guid.NewGuid().ToString());
            var context = contextFactory.Create();
            context.Boats.Add(domainfactory);
            context.SaveChanges();
            var repository = new BoatRepository(contextFactory);

            // Act
            var boat = await repository.GetById(ConstsForTests.NotExisistId);

            // Assert
            Assert.Null(boat);
        }

        [Fact]
        public async Task GetById_CheckReturnListOfBoats_ReturnListOfBoats()
        {
            // Arrange
            var domainfactory = new BoatFactoryInit().CreateAndInitBoat();
            var contextFactory = new BoatDbContextInMemoryFactory(Guid.NewGuid().ToString());
            var context = contextFactory.Create();
            ListsOfBoats.Initialization(context);
            var repository = new BoatRepository(contextFactory);
            var result = new List<IBoat>();

            // Act
            await foreach (var update in repository.GetAll())
            {
                result.Add(update);
            }

            // Assert
            Assert.Equal(context.Boats.Count(), result.Count);
            Assert.Equal(context.Boats.First().Id, result.First().Id);
            Assert.Equal(context.Boats.Last().Id, result.Last().Id);
        }

        [Fact]
        public async Task Insert_CheckToAddUnexistingBoat_AddUnexistingBoat()
        {
            // Arrange
            var factory = new FloatingCraftsFactory(BoatType.Canoe);
            var domainModel = (Canoe)factory.CreateAndInitBoat();
            var contextFactory = new Mock<BoatDbContextInMemoryFactory>(Guid.NewGuid().ToString());
            var context = contextFactory.Object.Create();
            var repository = new BoatRepository(contextFactory.Object);

            // Act
            await repository.Insert(domainModel);

            // Assert
            Assert.Equal(domainModel.Id, context.Boats.First().Id);
            Assert.Equal(nameof(Canoe), context.Boats.First().BoatType);
            Assert.Equal(domainModel.NumberOfPaddles.ToString(), context.BoatsSpecificParameters.First().Value);
        }

        [Fact]
        public async Task Update_CheckUpdateExistingBoat_UpdateExistingBoat()
        {
            // Arrange
            var daoBoat = new BoatFactoryInit().CreateAndInitBoat();
            var updateBoat = (Canoe)new CanoeFactory(ConstsForTests.NumOfPaddles).CreateBoat();
            var contextFactory = new BoatDbContextInMemoryFactory(Guid.NewGuid().ToString());
            var context = contextFactory.Create();
            context.Boats.Add(daoBoat);
            context.SaveChanges();
            var repository = new BoatRepository(contextFactory);

            // Act
            await repository.Update(updateBoat);

            // Assert
            Assert.Equal(updateBoat.NumberOfPaddles.ToString(), context.BoatsSpecificParameters.First().Value);
        }

        [Fact]
        public async Task Delete_CheckDeleteExistingBoat_DeleteExistingBoat()
        {
            // Arrange
            var domainfactory = new BoatFactoryInit().CreateAndInitBoat();
            var contextFactory = new BoatDbContextInMemoryFactory(Guid.NewGuid().ToString());
            var context = contextFactory.Create();
            context.Boats.Add(domainfactory);
            context.SaveChanges();
            var repository = new BoatRepository(contextFactory);

            // Act
            await repository.Delete((int)BoatsId.CanoeId);

            // Assert
            Assert.Empty(context.Boats);
        }
    }
}
