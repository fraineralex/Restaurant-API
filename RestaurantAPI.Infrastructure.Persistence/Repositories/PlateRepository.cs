using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class PlateRepository : GenericRepository<Plate>, IPlateRepository
    {
        private readonly ApplicationContext _db;
        public PlateRepository(ApplicationContext db): base(db)
        {
            _db = db;
        }

    }
}
