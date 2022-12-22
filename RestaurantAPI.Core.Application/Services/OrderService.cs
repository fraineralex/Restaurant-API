using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.Plates;
using RestaurantAPI.Core.Application.ViewModels.Table;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Services
{
    public class OrderService : GenericService<OrderSaveViewModel, OrderViewModel, Order>, IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository repo, IMapper mapper): base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
