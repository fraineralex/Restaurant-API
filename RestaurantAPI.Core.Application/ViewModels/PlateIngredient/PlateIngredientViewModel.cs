using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.Plates;

namespace RestaurantAPI.Core.Application.ViewModels.PlateIngredient
{
    public class PlateIngredientViewModel
    {
        public int Id { get; set; }

        public int PlateId { get; set; }
        public PlateViewModel Plate { get; set; }

        public int IngredientId { get; set; }
        public IngredientViewModel Ingredient { get; set; }
    }
}
