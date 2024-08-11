namespace Recipe.Application.Services
{
    using AutoMapper;
    using ErrorOr;

    using Microsoft.Extensions.Logging;


    using Recipe.Application.ApiModels;
    using Recipe.Application.Interfaces;
    using Recipe.Domain.Dtos;
    using Recipe.Domain.IngredientAggregate;
    using Recipe.Domain.IngredientAggregate.ValueObjects;
    using Recipe.Domain.ValueObjects;

    public class NutritionCalculationService : INutritionCalculationService
    {
        private readonly IMapper _mapper;
        private readonly IDeepLClient _deepLApiClient;
        private readonly INutritionClient _nutriotionApiClient;
        private readonly ILogger<NutritionCalculationService> _logger;

        public NutritionCalculationService(
            IMapper mapper,
            IDeepLClient deepLApiClient,
            INutritionClient nutriotionApiClient,
            ILogger<NutritionCalculationService> logger)
        {
            _mapper = mapper;
            _deepLApiClient = deepLApiClient;
            _nutriotionApiClient = nutriotionApiClient;
            _logger = logger;
        }

        public async Task<Product> CalculateNutritionPerGramm(string polishName)
        {   
            _logger.LogInformation("Calculating nutrition for {polishName}", polishName);
            
            string translation = TranslateToEnglish(polishName);
            var nutrition = await _nutriotionApiClient.GetProductNutrition(translation);
            _logger.LogInformation($"Nutrition for {polishName} calculated");
            nutrition = ConvertToPerGramNutritionData(nutrition);

            var result = Product.Create(
                ProductId.CreateUnique(),
                nutrition.Name,
                polishName,
                nutrition.CaloriesG,
                nutrition.CholesterolMg,
                nutrition.FatSaturatedG,
                nutrition.FatTotalG,
                nutrition.PotassiumMg,
                nutrition.ProteinG,
                nutrition.SodiumMg,
                nutrition.SugarG,
                new Measurement(1, QuantityType.Grams));

            return result;
        }

        public ProductDTO CalculateNutritionPerPortion(Product ingredient, decimal portion)
        {
            var r = _mapper.Map<ProductDTO>(ingredient);
            foreach (var property in r.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(decimal))
                {
                    var value = (decimal?)property.GetValue(r);
                    if (value != null)
                    {
                        property.SetValue(r, value * portion);
                    }
                }
            }

            r.Measurement.Quantity = portion;
            return r;
        }

        private Item ConvertToPerGramNutritionData(Item response)
        {
            var result = new Item()
            {
                CaloriesG = response.CaloriesG / response.ServingSize,
                CholesterolMg = response.CholesterolMg / response.ServingSize / 1000,
                FatSaturatedG = response.FatSaturatedG / response.ServingSize / 1000,
                FatTotalG = response.FatTotalG / response.ServingSize,
                Name = response.Name,
                PotassiumMg = response.PotassiumMg / response.ServingSize / 1000,
                ProteinG = response.ProteinG / response.ServingSize,
                SodiumMg = response.SodiumMg / response.ServingSize / 1000,
                SugarG = response.SugarG / response.ServingSize,
                FiberG = response.FiberG / response.ServingSize,
                CarbohydratesTotalG = response.CarbohydratesTotalG / response.ServingSize,
            };
            return result;
        }

        private string TranslateToEnglish(string polishName)
        {
            DeepLTranslationRequest request = new DeepLTranslationRequest().Create(polishName, "en");
            return _deepLApiClient.Translate(request).Result;
        }
    }
}