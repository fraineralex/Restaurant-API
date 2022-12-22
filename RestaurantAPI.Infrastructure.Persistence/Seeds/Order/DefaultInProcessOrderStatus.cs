using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Seeds.Order
{
    public static class DefaultInProcessOrderStatus
    {
        public static async Task SeedAsync(IOrderStatusRepository _repo)
        {
            
            OrderStatus entity = new();
            entity.Name = "In Process";

            var entities = await _repo.GetAllAsync();

            if (entities.All(e => e.Name != entity.Name))
            {
                var newCategory = await _repo.AddAsync(entity);
            }

        }
    }
}
