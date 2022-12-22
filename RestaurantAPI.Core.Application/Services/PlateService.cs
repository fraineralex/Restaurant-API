using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Plates;
using RestaurantAPI.Core.Application.ViewModels.PlateIngredient;
using RestaurantAPI.Core.Domain.Models;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Services
{
    public class PlateService : GenericService<PlateSaveViewModel, PlateViewModel, Plate>, IPlateService
    {
        private readonly IPlateRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPlateIngredientService _plateIngredientService;
        public PlateService(IPlateRepository repo, IMapper mapper, IPlateIngredientService plateIngredientService) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _plateIngredientService = plateIngredientService;
        }

        public async Task AddIngredients(int plateId, int ingredientId)
        {
            PlateIngredientSaveViewModel ingredient = new()
            {
                PlateId = plateId,
                IngredientId = ingredientId
            };
            await _plateIngredientService.Add(ingredient);
        }

        //public virtual async Task Update(SaveViewModel vm, int id)
        //{
        //    Entity entity = _mapper.Map<Entity>(vm);
        //    await _repo.UpdateAsync(entity, id);
        //}
        public async Task UpdateAsync(PlateSaveViewModel vm, int id)
        {
            Plate elPlato = await _repo.GetByIdAsync(id);

            foreach (int item in vm.Ingredinets)
            {
                await this.AddIngredients(vm.Id, item);
            }
            Plate plate = new()
            {
                Id = elPlato.Id,
                Name = elPlato.Name,
                PlateCategoryId = elPlato.PlateCategoryId,
                ForHowManyPeople = elPlato.ForHowManyPeople,
                Price = elPlato.Price,
            };

            await _repo.UpdateAsync(plate, id);
        }
    }
}
