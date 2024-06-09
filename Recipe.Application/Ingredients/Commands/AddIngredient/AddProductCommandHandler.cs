using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using ErrorOr;

using MediatR;

using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using Recipe.Application.Interfaces.Persistence;
using Recipe.Domain.Dtos;
using Recipe.Domain.Persistence;

namespace Recipe.Application.Ingredients.Commands.AddIngredient
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ErrorOr<ProductDTO>>
    {

        private readonly IMapper _mapper;
        private readonly INutritionClient _nutriotionApiClient;
        private readonly IDeepLClient _deepLApiClient;
        private readonly INutritionCalculationService _nutritionCalculationService;
         private readonly IIngredientRepository _repository;

        public AddProductCommandHandler(
            IMapper mapper,
            INutritionClient nutritionService,
            IDeepLClient deepLApiClient,
            INutritionCalculationService nutritionCalculationService,
            IIngredientRepository repository)
        {
            _mapper = mapper;
            _nutriotionApiClient = nutritionService;
            _deepLApiClient = deepLApiClient;
            _nutritionCalculationService = nutritionCalculationService;
            _repository = repository;
        }

        public async Task<ErrorOr<ProductDTO>> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var ingredient = await _repository.GetAsyncByIngredientName(command.IngredientName);

            if (ingredient == null)
            {
                try
                {
                    ingredient = await _nutritionCalculationService.CalculateNutritionPerGramm(command.IngredientName);
                    await _repository.AddAsync(ingredient);
                }
                catch (Exception e)
                {
                    if (e.Message == "Sequence contains no elements")
                    {
                        return Domain.Common.Errors.IngredientErrors.IngredientNotFound;
                    }
                }
            }

            ProductDTO dto = _mapper.Map<ProductDTO>(ingredient);
            dto = _nutritionCalculationService.CalculateNutritionPerPortion(ingredient, command.Quantity);
            return dto;
        }
    }
}
