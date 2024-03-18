
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using Recipe.Domain.Dtos;
using Recipe.Domain.Persistence;

namespace Recipe.Application.Ingredients.Commands.AddIngredient
{
    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, IngredientDTO>
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
            IIngredientRepository repository
            )
        {
            _mapper = mapper;
            _nutriotionApiClient = nutritionService;
            _deepLApiClient = deepLApiClient;
            _nutritionCalculationService = nutritionCalculationService;
            _repository = repository;
        }
        
        async Task<IngredientDTO> IRequestHandler<AddIngredientCommand, IngredientDTO>.Handle(AddIngredientCommand command, CancellationToken cancellationToken)
        {   
            DeepLTranslationRequest request = new DeepLTranslationRequest().Create(command.IngredientName, "en");
            string translation = await _deepLApiClient.Translate(request);
            var nutrition = await _nutriotionApiClient.GetProductNutrition(translation);
            var ingredient = _nutritionCalculationService.CalculateNutritionPerGramm(nutrition, command.IngredientName);
            await _repository.InsertAsync(ingredient);
            IngredientDTO dto = _mapper.Map<IngredientDTO>(ingredient);
            dto = _nutritionCalculationService.CalculateNutritionPerPortion(ingredient, command.Quantity);
            return dto;
        }
    }
}
