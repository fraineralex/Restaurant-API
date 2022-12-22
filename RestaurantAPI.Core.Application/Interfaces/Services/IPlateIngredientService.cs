using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.PlateIngredient;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IPlateIngredientService : IGenericService<PlateIngredientSaveViewModel, PlateIngredientViewModel, PlateIngredient>
    {
    }
}
