using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Seeds.TableStatuses
{
    public static class DefaultInProccessStatus
    {
        public static async Task SeedAsync(ITableStatusRepository _repo)
        {
            
            TableStatus entity = new();
            entity.Name = "In Process Of Atention";

            var entities = await _repo.GetAllAsync();

            if (entities.All(e => e.Name != entity.Name))
            {
                var newCategory = await _repo.AddAsync(entity);
            }

        }
    }
}
