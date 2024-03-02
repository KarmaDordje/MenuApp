using AutoMapper;
using Recipe.Domain.Dtos;
using Recipe.Domain.Interfaces;
using Recipe.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _IngredientRepository;

        public IngredientService(IMapper mapper, IIngredientRepository IngredientRepository)
        {
            _mapper = mapper;
            _IngredientRepository = IngredientRepository;
        }

        public async Task<IEnumerable<IngredientDTO>> GetAllIngredientsAsync()
        {
            var result = await _IngredientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<IngredientDTO>>(result);
        }
    }
}
