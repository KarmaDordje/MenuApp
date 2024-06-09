using AutoMapper;

using FluentAssertions;

using Moq;

using Recipe.Application.ApiModels;

using Recipe.Application.Ingredients.Commands.AddIngredient;
using Recipe.Application.Interfaces;

using Recipe.Application.Interfaces.Persistence;
using Recipe.Application.Mappings;
using Recipe.Application.UnitTests.Ingredients.Commands.TestUtils;

namespace Recipe.Application.UnitTests.Ingredients.Commands.AddIngredient;

public class AddIngredientCommandHandlerTests
{

    private readonly Mock<IIngredientRepository> _mockIngredientRepository;
    private readonly AddProductCommandHandler _handler;
    private readonly Mock<INutritionClient> _mockNutritionClient;
    private readonly Mock<IDeepLClient> _mockDeepLClient;
    private readonly IMapper _mapper;

    private readonly Mock<INutritionCalculationService> _mockNutritionCalculationService;

    public AddIngredientCommandHandlerTests()
    {
        _mockIngredientRepository = new Mock<IIngredientRepository>();
        _mockNutritionClient = new Mock<INutritionClient>();
        _mockDeepLClient = new Mock<IDeepLClient>();
        _mockNutritionCalculationService = new Mock<INutritionCalculationService>();
        _mapper = new MapperConfiguration(cfg => cfg.AddProfile<DomainToDtoMappingProfile>()).CreateMapper();
        _handler = new AddProductCommandHandler(
            _mapper,
            _mockNutritionClient.Object,
            _mockDeepLClient.Object,
            _mockNutritionCalculationService.Object,
            _mockIngredientRepository.Object);
    }

    [Theory]
    [MemberData(nameof(ValidCreateRecipeCommands))]
    public async Task HandleAddIngredient_WhenIngredientNotInDb_ShouldCreateAndReturnIngredient(AddProductCommand command)
    {
        // Arrange
        _mockDeepLClient.Setup(x => x.Translate(It.IsAny<DeepLTranslationRequest>())).ReturnsAsync("patato");
        _mockNutritionClient.Setup(x => x.GetProductNutrition(It.IsAny<string>())).ReturnsAsync(AddIngredientCommandUtils.CreateNutritionResponse());
        
        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse();
        //_mockIngredientRepository.Verify(x => x.AddAsync(ingredient), Times.Once);
    }
    
    public static IEnumerable<object[]> ValidCreateRecipeCommands()
    {
        yield return new object[] { AddIngredientCommandUtils.CreateCommand() };
    }
}