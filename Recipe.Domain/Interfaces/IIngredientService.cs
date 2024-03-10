using Recipe.Domain.Dtos;
using Recipe.Infrastructure.External.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Interfaces
{
    public interface IIngredientService
    {
        Task<bool> AddIngridient(string ingredientName);
        Task<IEnumerable<IngredientDTO>> GetAllIngredientsAsync();
    }
}
