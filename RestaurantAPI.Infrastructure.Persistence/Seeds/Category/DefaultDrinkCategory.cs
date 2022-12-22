using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Seeds.Category
{
    public static class DefaultDrinkCategory
    {
        public static async Task SeedAsync(IPlateCategoryRepository _repo)
        {
            PlateCategory entity = new();
            entity.Name = "Drink";

            var entities = await _repo.GetAllAsync();

            if (entities.All(e => e.Name != entity.Name))
            {
                var newCategory = await _repo.AddAsync(entity);
            }

        }
    }
}
