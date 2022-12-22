using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Seeds.TableStatuses
{
    public static class DefaultAttendedStatus
    {
        public static async Task SeedAsync(ITableStatusRepository _repo)
        {
            
            TableStatus entity = new();
            entity.Name = "Attended";

            var entities = await _repo.GetAllAsync();

            if (entities.All(e => e.Name != entity.Name))
            {
                var newCategory = await _repo.AddAsync(entity);
            }

        }
    }
}
