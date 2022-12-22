using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class PlateIngredientRepository : GenericRepository<PlateIngredient>, IPlateIngredientRepository
    {
        private readonly ApplicationContext _db;
        public PlateIngredientRepository(ApplicationContext db): base(db)
        {
            _db = db;
        }

    }
}
