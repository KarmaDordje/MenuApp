using AutoMapper;
using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using Recipe.Domain.Dtos;
using Recipe.Domain.IngredientAggregate;

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
            var result = _mapper.Map<Ingredient>(nutrition);
            //result.PolishName = polishName;
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
    }
}