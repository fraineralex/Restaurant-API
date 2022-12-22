using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Domain.Models;


namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<OrderSaveViewModel, OrderViewModel, Order>
    {
    }
}
