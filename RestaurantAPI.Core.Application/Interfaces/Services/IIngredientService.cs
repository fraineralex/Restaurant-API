using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IIngredientService : IGenericService<IngredientSaveViewModel, IngredientViewModel, Ingredient>
    {
    }
}
