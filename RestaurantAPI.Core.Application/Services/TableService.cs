using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Table;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Services
{
    public class TableService : GenericService<TableSaveViewModel, TableViewModel, Table>, ITableService
    {
        private readonly ITableRepository _repo;
        private readonly IMapper _mapper;
        public TableService(ITableRepository repo, IMapper mapper): base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
