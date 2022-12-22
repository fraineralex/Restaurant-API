using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly ApplicationContext _db;
        public TableRepository(ApplicationContext db): base(db)
        {
            _db = db;
        }

    }
}
