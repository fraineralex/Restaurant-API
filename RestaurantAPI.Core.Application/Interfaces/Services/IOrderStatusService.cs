using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.OrderStatus;
using RestaurantAPI.Core.Domain.Models;


namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IOrderStatusService : IGenericService<OrderStatusSaveViewModel, OrderStatusViewModel, OrderStatus>
    {
    }
}
