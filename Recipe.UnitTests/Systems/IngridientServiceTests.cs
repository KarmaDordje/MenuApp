using AutoFixture;
using AutoMapper;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Recipe.Domain.Services;
using Recipe.Infrastructure.Context.Entities;
using Recipe.Infrastructure.External;
using Recipe.Infrastructure.External.Models;
using Recipe.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.UnitTests.Systems
{
    public class IngridientServiceTests
    {

        private readonly Fixture _fixture;
        private readonly Mock<ILogger<IngredientService>> _loggerMock;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IIngredientRepository> _repositoryMock;
        private readonly Mock<INutritionClient> _nutritionMock;
        private readonly Mock<IDeepLClient> _deepLClientMock;
        private readonly IngredientService _sut;

        public IngridientServiceTests()
        {
            _fixture = new Fixture();
            _loggerMock = new Mock<ILogger<IngredientService>>();
            _mapper = new Mock<IMapper>();
            _repositoryMock = new Mock<IIngredientRepository>();
            _nutritionMock = new Mock<INutritionClient>();
            _deepLClientMock = new Mock<IDeepLClient>();
            _sut = new IngredientService(_mapper.Object, _repositoryMock.Object, _nutritionMock.Object, _deepLClientMock.Object, _loggerMock.Object);

        }

        [Theory]
        [InlineData("Ziemniak")]
        public async Task Should_Add_Ingridient_ToTheDb(string productName)
        {
            // Arrange
            var fakeNutrition = _fixture.Create<Ingredient>();

            _deepLClientMock.Setup(x => x.Translate(It.IsAny<DeepLTranslationRequest>())).ReturnsAsync("Patato");
            _nutritionMock.Setup(x => x.GetProductNutrition(It.IsAny<string>())).ReturnsAsync(fakeNutrition);
            _repositoryMock.Setup(x => x.InsertAsync(It.IsAny<Ingredient>())).ReturnsAsync(true);
            var sut = new IngredientService(_mapper.Object, _repositoryMock.Object, _nutritionMock.Object, _deepLClientMock.Object, _loggerMock.Object);
            
            //Act
            var r = await _sut.AddIngridient(productName);

            //Assert
            _deepLClientMock.Verify(x => x.Translate(It.IsAny<DeepLTranslationRequest>()), Times.Once());
            _nutritionMock.Verify(x => x.GetProductNutrition(It.IsAny<string>()), Times.Once());
            _repositoryMock.Verify(x => x.InsertAsync(It.IsAny<Ingredient>()), Times.Once());
            r.Should().BeTrue();
        }




    }
}
