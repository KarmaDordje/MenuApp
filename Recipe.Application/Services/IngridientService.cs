using AutoMapper;
using Microsoft.Extensions.Logging;
using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using Recipe.Domain.Dtos;
using Recipe.Domain.Entities;
using Recipe.Domain.Interfaces;
using Recipe.Domain.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _IngredientRepository;
        private readonly INutritionClient _nutriotionApiClient;
        private readonly IDeepLClient _deepLApiClient;
        private readonly ILogger<IngredientService> _logger;


        public IngredientService(
            IMapper mapper,
            IIngredientRepository IngredientRepository,
            INutritionClient nutritionService,
            IDeepLClient deepLApiClient,
            ILogger<IngredientService> logger
            )
        {
            _mapper = mapper;
            _IngredientRepository = IngredientRepository;
            _nutriotionApiClient = nutritionService;
            _deepLApiClient = deepLApiClient;
            _logger = logger;
        }

        public async Task<bool> AddIngridient(string ingredientName)
        {

            _logger.LogInformation($"Translating product {ingredientName}");
            DeepLTranslationRequest request = new DeepLTranslationRequest().Create(ingredientName, "en");

            _logger.LogInformation($"Getting nutrition information for product {request.Text}");
            string translation = await _deepLApiClient.Translate(request);

            var nutrition = await _nutriotionApiClient.GetProductNutrition(translation);

            throw new Exception("Product is not found here");
            return false;//await _IngredientRepository.InsertAsync(nutrition);




        }

        public async Task<IEnumerable<IngredientDTO>> GetAllIngredientsAsync()
        {
            var result = await _IngredientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<IngredientDTO>>(result);
        }
    }
}
