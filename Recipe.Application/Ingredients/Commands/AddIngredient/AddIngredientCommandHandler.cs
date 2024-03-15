
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
        private readonly IIngredientRepository _IngredientRepository;
        private readonly INutritionClient _nutriotionApiClient;
        private readonly IDeepLClient _deepLApiClient;
        private readonly INutritionCalculationService _nutritionCalculationService;

        public AddIngredientCommandHandler(
            IMapper mapper,
            IIngredientRepository IngredientRepository,
            INutritionClient nutritionService,
            IDeepLClient deepLApiClient,
            INutritionCalculationService nutritionCalculationService
            )
        {
            _mapper = mapper;
            _IngredientRepository = IngredientRepository;
            _nutriotionApiClient = nutritionService;
            _deepLApiClient = deepLApiClient;
            _nutritionCalculationService = nutritionCalculationService;
        }
        
        async Task<IngredientDTO> IRequestHandler<AddIngredientCommand, IngredientDTO>.Handle(AddIngredientCommand command, CancellationToken cancellationToken)
        {   
            DeepLTranslationRequest request = new DeepLTranslationRequest().Create(command.IngredientName, "en");
            string translation = await _deepLApiClient.Translate(request);
            var nutrition = await _nutriotionApiClient.GetProductNutrition(translation);
            var ingredient = _nutritionCalculationService.CalculateNutritionPerGramm(nutrition);
            throw new NotImplementedException();
        }
    }
}