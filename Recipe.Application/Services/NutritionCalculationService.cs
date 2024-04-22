using AutoMapper;
using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using Recipe.Domain.Dtos;
using Recipe.Domain.IngredientAggregate;
using Recipe.Domain.IngredientAggregate.ValueObjects;
using Recipe.Domain.ValueObjects;

namespace Recipe.Application.Services
{
    public class NutritionCalculationService : INutritionCalculationService
    {
        private readonly IMapper _mapper;

        public NutritionCalculationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Ingredient CalculateNutritionPerGramm(NutritionResponse nutrition, string polishName)
        {
            nutrition = ConvertToPerGramNutritionData(nutrition);
            var result = Ingredient.Create(
                IngredientId.CreateUnique(),
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

        public IngredientDTO CalculateNutritionPerPortion(Ingredient ingredient, decimal portion)
        {
            var r = _mapper.Map<IngredientDTO>(ingredient);
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

        private NutritionResponse ConvertToPerGramNutritionData(NutritionResponse response)
        {
            var result = new NutritionResponse()
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
    }
}