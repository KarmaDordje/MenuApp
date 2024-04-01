using Recipe.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Persistence
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetAsync(Guid id);
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task AddAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(Guid id);
    }
}
