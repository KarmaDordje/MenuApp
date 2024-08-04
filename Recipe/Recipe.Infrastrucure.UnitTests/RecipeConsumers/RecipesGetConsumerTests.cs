namespace Recipe.Infrastructure.UnitTests.RecipeConsumers
{
    using System;
    using System.Threading.Tasks;
    using MassTransit;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Contracts.Recipes.ConsumerContracts;
    using Recipe.Infrastructure.Messaging;

    using Xunit;

    public class RecipesGetConsumerTests
    {
        private readonly Mock<IRecipeRepository> _recipeRepositoryMock;
        private readonly Mock<ILogger<GetRecipeConsumer>> _loggerMock;
        private readonly Mock<ConsumeContext<RecipeConsumerRequest>> _consumeContextMock;

        public RecipesGetConsumerTests()
        {
            _recipeRepositoryMock = new Mock<IRecipeRepository>();
            _loggerMock = new Mock<ILogger<GetRecipeConsumer>>();
            _consumeContextMock = new Mock<ConsumeContext<RecipeConsumerRequest>>();
        }

        [Fact]
        public async Task Consume_WhenCalled_ShouldCallGetAllUserRecipes()
        {
            // Arrange
            var userId = "b4bd504b-032e-4d20-a061-a305635f4804";
            var consumer = new GetRecipeConsumer(_recipeRepositoryMock.Object, _loggerMock.Object);
            var request = new RecipeConsumerRequest { UserId = userId };
            _consumeContextMock.Setup(x => x.Message).Returns(request);

            // Act
            await consumer.Consume(_consumeContextMock.Object);

            // Assert
            _recipeRepositoryMock.Verify(x => x.GetAllUserRecipes(userId), Times.Once);
        }
    }
}