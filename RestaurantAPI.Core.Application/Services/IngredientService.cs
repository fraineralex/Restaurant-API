using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Services
{
    public class IngredientService : GenericService<IngredientSaveViewModel,IngredientViewModel, Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository _repo;
        private readonly IMapper _mapper;
        public IngredientService(IIngredientRepository repo, IMapper mapper): base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
