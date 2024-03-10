using AutoMapper;
using Microsoft.Extensions.Logging;
using Recipe.Domain.Dtos;
using Recipe.Domain.Interfaces;
using Recipe.Infrastructure.Context.Entities;
using Recipe.Infrastructure.External;
using Recipe.Infrastructure.External.Models;
using Recipe.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Services
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
            try
            {
                _logger.LogInformation($"Translating product {ingredientName}");
                DeepLTranslationRequest request = new DeepLTranslationRequest().Create(ingredientName, "en");

                _logger.LogInformation($"Getting nutrition information for product {request.Text}");
                string translation = await _deepLApiClient.Translate(request);

                Ingredient nutrition = await _nutriotionApiClient.GetProductNutrition(translation);
                return await _IngredientRepository.InsertAsync(nutrition);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"\rError while trying to add ingredient to DB \n\rError: {ex}");
                return false;
            }
            
        }

        public async Task<IEnumerable<IngredientDTO>> GetAllIngredientsAsync()
        {
            var result = await _IngredientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<IngredientDTO>>(result);
        }
    }
}
