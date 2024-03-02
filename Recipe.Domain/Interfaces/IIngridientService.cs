using Recipe.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDTO>> GetAllIngredientsAsync();
    }
}
