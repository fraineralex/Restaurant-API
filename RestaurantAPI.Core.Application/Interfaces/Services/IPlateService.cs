using RestaurantAPI.Core.Application.ViewModels.Plates;
using RestaurantAPI.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IPlateService: IGenericService<PlateSaveViewModel, PlateViewModel, Plate>
    {
        Task UpdateAsync(PlateSaveViewModel vm, int id);
        Task AddIngredients(int Id, int ingredientId);
    }
}
