using Recipe.Infrastructure.Context;
using Recipe.Infrastructure.Context.Entities;
using Recipe.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
