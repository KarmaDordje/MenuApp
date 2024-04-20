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
    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, ErrorOr<IngredientDTO>>
    {

        private readonly IMapper _mapper;
        private readonly INutritionClient _nutriotionApiClient;
        private readonly IDeepLClient _deepLApiClient;
        private readonly INutritionCalculationService _nutritionCalculationService;
         private readonly IIngredientRepository _repository;

        public AddIngredientCommandHandler(
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

        public async Task<ErrorOr<IngredientDTO>> Handle(AddIngredientCommand command, CancellationToken cancellationToken)
        {
            var ingredient = await _repository.GetAsyncByIngredientName(command.IngredientName);

            if (ingredient != null)
            {
                return _mapper.Map<IngredientDTO>(ingredient);
            }
            else
            {
                 DeepLTranslationRequest request = new DeepLTranslationRequest().Create(command.IngredientName, "en");
                string translation = await _deepLApiClient.Translate(request);
                var nutrition = await _nutriotionApiClient.GetProductNutrition(translation);
                var newIngredient = _nutritionCalculationService.CalculateNutritionPerGramm(nutrition, command.IngredientName);
                await _repository.AddAsync(newIngredient);
                IngredientDTO dto = _mapper.Map<IngredientDTO>(ingredient);
                dto = _nutritionCalculationService.CalculateNutritionPerPortion(newIngredient, command.Quantity);
                return dto;
            }
        }
    }
}
