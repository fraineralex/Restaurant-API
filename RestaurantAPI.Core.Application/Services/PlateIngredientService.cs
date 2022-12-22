using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.PlateIngredient;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Services
{
    public class PlateIngredientService : GenericService<PlateIngredientSaveViewModel,PlateIngredientViewModel, PlateIngredient>, IPlateIngredientService
    {
        private readonly IPlateIngredientRepository _repo;
        private readonly IMapper _mapper;
        public PlateIngredientService(IPlateIngredientRepository repo, IMapper mapper): base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
