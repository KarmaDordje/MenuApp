using ErrorOr;

using MediatR;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, ErrorOr<Domain.Entities.Recipe>>
    {
        public Task<ErrorOr<Domain.Entities.Recipe>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {   
            //Crete a new recipe
            //Persist the recipe
            //Return the recipe
            return default!;
        }
    }
}