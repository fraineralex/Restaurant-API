using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.Plates;
using System;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PlateController : BaseApiController
    {
        private readonly IPlateService _plateSvc;
        private readonly IIngredientService _ingredientSvc;
        public PlateController(IPlateService plateService, IIngredientService ingredientService)
        {
            _plateSvc = plateService;
            _ingredientSvc = ingredientService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlateViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ingredients = await _plateSvc.GetAllVm();
                if (ingredients == null || ingredients.Count == 0)
                {
                    return NotFound();
                }
                return Ok(ingredients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlateViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ingredient = await _plateSvc.GetbyIdVM(id);
                if (ingredient == null)
                {
                    return NotFound();
                }
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(PlateViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(PlateSaveViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (vm.Ingredinets.Count == 0)
                {
                    return BadRequest();
                }

                foreach (var id in vm.Ingredinets)
                {
                    var ingredinet = await _ingredientSvc.GetbyIdVM(id);
                    if (ingredinet == null)
                    {
                        return BadRequest();
                    }
                }

                var plate = await _plateSvc.Add(vm);

                foreach (var id in vm.Ingredinets)
                {
                    await _plateSvc.AddIngredients(plate.Id, id );
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlateViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, PlateSaveViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (vm.Ingredinets.Count == 0)
                {
                    return BadRequest();
                }

                foreach (var elId in vm.Ingredinets)
                {
                    var ingredinet = await _ingredientSvc.GetbyIdVM(elId);
                    if (ingredinet == null)
                    {
                        return BadRequest();
                    }
                }
                await _plateSvc.UpdateAsync(vm, id);

                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlateViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _plateSvc.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
