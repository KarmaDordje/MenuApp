namespace Recipe.Application.Mappings
{
    using AutoMapper;
    using Recipe.Application.ApiModels;
    using Recipe.Domain.Dtos;
    using Recipe.Domain.IngredientAggregate;
    using Recipe.Domain.ValueObjects;

    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PolishName));

            CreateMap<NutritionResponse, Product>()
            .ForMember(dest => dest.Calories, opt => opt.MapFrom(src => src.CaloriesG / 100))
            .ForMember(dest => dest.Cholesterol, opt => opt.MapFrom(src => src.CholesterolMg / 100 / 1000))
            .ForMember(dest => dest.FatSaturated, opt => opt.MapFrom(src => src.FatSaturatedG / 100))
            .ForMember(dest => dest.FatTotal, opt => opt.MapFrom(src => src.FatTotalG / 100))
            .ForMember(dest => dest.Potassium, opt => opt.MapFrom(src => src.PotassiumMg / 100 / 1000))
            .ForMember(dest => dest.Protein, opt => opt.MapFrom(src => src.ProteinG / 100 / 1000))
            .ForMember(dest => dest.Sodium, opt => opt.MapFrom(src => src.SodiumMg / 100 / 1000))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Measurement, opt => opt.MapFrom(src => new Measurement(1m, QuantityType.Grams)));
        }
    }
}
