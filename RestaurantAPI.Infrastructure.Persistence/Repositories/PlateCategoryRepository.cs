using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class PlateCategoryRepository : GenericRepository<PlateCategory>, IPlateCategoryRepository
    {
        private readonly ApplicationContext _db;
        public PlateCategoryRepository(ApplicationContext db): base(db)
        {
            _db = db;
        }

    }
}
