namespace Menu.API.Common.Mapping;
using AutoMapper;

using Menu.Application.Menu.Commands;
using Menu.Contracts.Menu;
using Menu.Domain.Common.Shared;


using SharedCore.Contracts.Consumers.Recipe;
using SharedCore.Enums;

public class MenuMappingConfig : Profile
    {
        public MenuMappingConfig()
        {
            CreateMap<CreateMenuRequest, CreateMenuCommand>();
            CreateMap<Category, MealCategory>().ConvertUsing(c => (MealCategory)c);
            CreateMap<Recipe, RecipeDTO>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        }

    }
