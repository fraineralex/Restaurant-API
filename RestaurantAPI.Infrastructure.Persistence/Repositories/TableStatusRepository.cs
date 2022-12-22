using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class TableStatusRepository : GenericRepository<TableStatus>, ITableStatusRepository
    {
        private readonly ApplicationContext _db;
        public TableStatusRepository(ApplicationContext db): base(db)
        {
            _db = db;
        }

    }
}
