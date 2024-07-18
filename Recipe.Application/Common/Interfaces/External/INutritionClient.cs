namespace Recipe.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Recipe.Application.ApiModels;

    public interface INutritionClient
    {
        Task<Item> GetProductNutrition(string productName);
    }
}
