using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _db;
        public OrderRepository(ApplicationContext db): base(db)
        {
            _db = db;
        }

    }
}
