using RestaurantAPI.Core.Application.ViewModels.Table;
using RestaurantAPI.Core.Domain.Models;


namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface ITableService: IGenericService<TableSaveViewModel, TableViewModel, Table>
    {
    }
}
