namespace Recipe.Application.Recipes.Queries
{   
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Dapper;
    using ErrorOr;
    using MediatR;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Application.Interfaces.Persistence;
    using Recipe.Contracts.Recipes;
    using Recipe.Domain.ValueObjects;
    using SharedCore.Data;


    public class RecipeQueryHandler : IRequestHandler<RecipeQuery, ErrorOr<RecipeGetResponse>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public RecipeQueryHandler(
            IRecipeRepository recipeRepository,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _recipeRepository = recipeRepository;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ErrorOr<RecipeGetResponse>> Handle(RecipeQuery command, CancellationToken cancellationToken)
        {
            var recipeId = RecipeId.Create(command.RecipeId);
            var connection = _sqlConnectionFactory.GetOpenConnection();

            List<RecipeSectionResponse> recipeSections = new List<RecipeSectionResponse>();
            List<RecipeStepResponse> recipeSteps = new List<RecipeStepResponse>();

            string sql = $"""
                SELECT "Id", "Name", "Description", "UserId", "AvarageRating", "CreatedAt", "Category", "VideoUrl", "ImageUrl"
                FROM "Recipes"
                WHERE "Id" = @RecipeId;
                
                SELECT  
                    "RecipeSectionId" as {nameof(RecipeSectionResponse.RecipeSectionId)}, 
                    "Title" as {nameof(RecipeSectionResponse.Title)}
                FROM "RecipeSections"
                WHERE "RecipeId" = @RecipeId;

                SELECT
                    ri."RecipeSectionId" ,
                    ri."RecipeIngredientId",
                    ri."Quantity",
                    p."Name" ,
                    p."PolishName" ,
                    p."Calories" * ri."Quantity" as {nameof(RecipeIngredientResponse.Calories)},
                    p."Cholesterol" * ri."Quantity" as {nameof(RecipeIngredientResponse.Cholesterol)},
                    p."FatSaturated" * ri."Quantity" as {nameof(RecipeIngredientResponse.FatSaturated)},
                    p."FatTotal" * ri."Quantity" as {nameof(RecipeIngredientResponse.FatTotal)},
                    p."Potassium" * ri."Quantity" as {nameof(RecipeIngredientResponse.Potassium)},
                    p."Protein" * ri."Quantity" as {nameof(RecipeIngredientResponse.Protein)},
                    p."Sodium" * ri."Quantity" as  {nameof(RecipeIngredientResponse.Sodium)},
                    p."Sugar" * ri."Quantity" as {nameof(RecipeIngredientResponse.Sugar)}
                FROM "RecipeIngredients" as ri
                JOIN "Products" as p on p."Id" = ri."RecipeIngredientId"
                WHERE ri."RecipeId" = @RecipeId;

                SELECT 
                    rs."RecipeStepId", 
                    rs."Order", 
                    rs."Name", 
                    rs."ImgUrl", 
                    rs."VideoUrl" 
                FROM "RecipeSteps" as rs 
                WHERE rs."RecipeId"  = @RecipeId;;
            """;

            var multi = await connection.QueryMultipleAsync(sql, new { command.RecipeId });
            var recipeR = await multi.ReadFirstAsync<RecipeResponse>();
            var sections = multi.ReadAsync<RecipeSectionResponse>().Result.ToList();
            var ingredients = multi.ReadAsync<RecipeIngredientResponse>().Result.ToList();
            var steps = multi.ReadAsync<RecipeStepResponse>().Result.ToList();

            foreach (var section in sections)
            {
                section.Ingredients = ingredients.Where(i => i.RecipeSectionId == section.RecipeSectionId).ToList();
            }

            var result = new RecipeGetResponse
            {
                Id = recipeR.Id,
                Name = recipeR.Name,
                Description = recipeR.Description,
                AvarageRating = recipeR.AvarageRating,
                ImageUrl = recipeR.ImageUrl,
                VideoUrl = recipeR.VideoUrl,
                RecipeSections = sections,
                RecipeSteps = steps,
                CreatedAt = recipeR.CreatedAt,
                UpdatedAt = recipeR.UpdatedAt
            };

            return result;
        }
    }
}