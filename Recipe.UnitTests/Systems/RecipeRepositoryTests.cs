using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Recipe.Domain.Entities;
using Recipe.Infrastructure.Context;
using Recipe.Infrastructure.Repositories;
using Recipe.UnitTests.Helpers;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace Recipe.UnitTests.Systems
{
    public class RecipeRepositoryTests
    {
        private readonly Fixture _fixture;

        public RecipeRepositoryTests() 
        { 
            _fixture = new Fixture();
        }


        [Fact]
        public async Task GetAllAsync_Should_Return_AllIngidientsAsync()
        {
            // Arrange
            var ingidients = _fixture.CreateMany<Ingredient>();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var recipeContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            recipeContext.Setup(x => x.Set<Ingredient>()).ReturnsDbSet(ingidients);
            var sut = new IngredientRepository(recipeContext.Object);

            //Act
            var result = await sut.GetAllAsync();

            //Assert
            result.Should().NotBeNull().And.HaveCount(3);
        }

        [Theory]
        [InlineData(2)]
        public async Task GetByIdAsync_Should_Return_Single_Row(int id)
        {
            // Arrange
            int[] ids = { 1, 2, 3, 4};
            var queue = new Queue<int>(ids);

            var ingedients = _fixture.Build<Ingredient>()
               .With(f => f.Id, () => queue.Dequeue())
               .CreateMany(ids.Length);
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var recipeContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            recipeContext.Setup(x => x.Set<Ingredient>()).ReturnsDbSet(ingedients);
            var sut = new IngredientRepository(recipeContext.Object);

            //Act
            var result = await sut.GetByIdAsync(id);

            //Assert
            result.Should().BeOfType<Ingredient>();
        }

        [Fact]
        public async Task InsertRecordAsync_Should_InsertRecord()
        {   
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var recipeContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            recipeContext.Setup(x => x.Set<Ingredient>()).ReturnsDbSet(new List<Ingredient>());

            var ingredient = _fixture.Create<Ingredient>();
            ingredient.Id = 1;
            var sut = new IngredientRepository(recipeContext.Object);

            //Act
            var result = await sut.InsertAsync(ingredient);

            //Assert
            result.Should().BeTrue();
            recipeContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

        }

        [Fact]
        public async Task UpdateSingleRow_Should_Return_True()
        {
            //Arrange
            var ingidients = _fixture.CreateMany<Ingredient>();
            ingidients.First().Id = 2;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var recipeContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            var dbSetMock = DbMock.CreateDbSetMock(ingidients);
            recipeContext.Setup(x => x.Set<Ingredient>()).Returns(dbSetMock.Object);
            recipeContext.Setup(x => x.Ingredients).Returns(dbSetMock.Object);


            var sut = new IngredientRepository(recipeContext.Object);
            //recipeContext.Setup(x => x.Ingredients.Find(It.IsAny<int>())).Returns(ingidients.First());


            //Act
            var entity = await sut.GetByIdAsync(2);
            
            entity.Name = "Test";
            var result = await sut.UpdateAsync(entity);

            result.Should().BeTrue();
            dbSetMock.Verify(x => x.Update(It.IsAny<Ingredient>()), Times.Once());
            recipeContext.Object.Ingredients.FirstOrDefault(x => x.Name == "Test").Should().NotBeNull();
            recipeContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task DeleteRow_Should_Return_True()
        {
            //Arrange
            var ingidients = _fixture.CreateMany<Ingredient>();
            ingidients.First().Id = 2;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var recipeContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            var dbSetMock = DbMock.CreateDbSetMock(ingidients);
            recipeContext.Setup(x => x.Set<Ingredient>()).Returns(dbSetMock.Object);
            recipeContext.Setup(x => x.Ingredients).Returns(dbSetMock.Object);

            var sut = new IngredientRepository(recipeContext.Object);

            //Act
            var result = await sut.DeleteAsync(ingidients.First());

            result.Should().BeTrue();
            dbSetMock.Verify(x => x.Remove(It.IsAny<Ingredient>()), Times.Once());
            recipeContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}