using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        private readonly ApplicationContext _db;
        public OrderStatusRepository(ApplicationContext db): base(db)
        {
            _db = db;
        }

    }
}
