namespace Recipe.Application.Recipes.Queries.GetRecipiesList;

using Dapper;
using ErrorOr;
using MediatR;

using Recipe.Contracts.Recipes;

using Recipe.Contracts.Recipes.GetRecipeResponse;
using SharedCore.Data;

public class GetRecipiesListQueryHandler : IRequestHandler<GetRecipiesListQuery, ErrorOr<RecipiesListResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetRecipiesListQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ErrorOr<RecipiesListResponse>> Handle(GetRecipiesListQuery query, CancellationToken cancellationToken)
        {   
            var connection = _sqlConnectionFactory.GetOpenConnection();

            string sql = 
            $"""
                SELECT 
                    "Id", 
                    "Name", 
                    "Description", 
                    "UserId", 
                    "AvarageRating", 
                    "CreatedAt", 
                    "Category", 
                    "VideoUrl", 
                    "ImageUrl"
                FROM "Recipes"
                WHERE "UserId" = @UserId;

                SELECT
                    "RecipeId",
                    "RecipeSectionId", 
                    "Title"
                FROM "RecipeSections"
                WHERE "RecipeId" IN (SELECT "RecipeId" FROM "Recipes" WHERE "UserId" = @UserId);

                SELECT
                    ri."RecipeId",
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
                WHERE ri."RecipeId" IN (SELECT  "RecipeId" FROM "Recipes" WHERE  "UserId" = @UserId);

                SELECT
                    rs."RecipeId",
                    rs."RecipeStepId",
                    rs."Order",
                    rs."Name",
                    rs."ImgUrl",
                    rs."VideoUrl"
                FROM "RecipeSteps" as rs
                WHERE rs."RecipeId"  IN (SELECT "RecipeId" FROM "Recipes" WHERE "UserId" = @UserId);
            """;

            var multi = await connection.QueryMultipleAsync(sql, new { query.UserId });
            var recipeR = multi.ReadAsync<RecipeResponse>().Result.ToList();
            var sections = multi.ReadAsync<RecipeSectionResponse>().Result.ToList();
            var ingredients = multi.ReadAsync<RecipeIngredientResponse>().Result.ToList();
            var steps = multi.ReadAsync<RecipeStepResponse>().Result.ToList();

            var recipies = new List<RecipeGetResponse>();

            foreach (var recipe in recipeR)
            {
                var recipeSections = sections.Where(s => s.RecipeId == recipe.Id).ToList();
            
                foreach (var section in recipeSections)
                {
                    section.Ingredients = ingredients.Where(i => i.RecipeSectionId == section.RecipeSectionId).ToList();
                }

                var recipieSteps = steps.Where(s => s.RecipeId == recipe.Id).ToList();

                recipies.Add(new RecipeGetResponse
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    AvarageRating = recipe.AvarageRating,
                    ImageUrl = recipe.ImageUrl,
                    VideoUrl = recipe.VideoUrl,
                    RecipeSections = recipeSections,
                    RecipeSteps = recipieSteps ?? new List<RecipeStepResponse>(),
                    CreatedAt = recipe.CreatedAt,
                    UpdatedAt = recipe.UpdatedAt
                });
            }

            var result = new RecipiesListResponse();
            result.Recipies = recipies;

            return result;
        }
    }
