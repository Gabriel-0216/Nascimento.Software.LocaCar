using Domain.Rent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.LocaCar.Api.DTO;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        [HttpPost]
        [Route("insert-a-new-vehicle")]
        public async Task<ActionResult> InsertNewVehicle()
        {
            return BadRequest();
        }
        [HttpPost]
        [Route("insert-new-fuel-type")]
        public async Task<ActionResult> InsertNewFuelType([FromServices] IRepository<FuelType> _fuelRepo, 
            [FromBody] FuelTypeDTO fuelTypeDTO)
        {
            var fuelType = new FuelType()
            {
                Name = fuelTypeDTO.FuelName,
            };
            var inserted = await _fuelRepo.Add(fuelType);
            if (inserted) return Ok();
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpDelete]
        [Route("delete-fuel-type")]
        public async Task<ActionResult> DeleteFuelType([FromServices] IRepository<FuelType> _fuelRepo,
            [FromHeader] string id)
        {
            if (id == null) return BadRequest("The id can't be null");

            var fuelGet = await _fuelRepo.Get(id);
            if (fuelGet == null) return BadRequest("The register you want to delete doesn't exists.");

            var deleted = await _fuelRepo.Remove(fuelGet);
            if (deleted) return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        [Route("insert-new-vehicle-category")]
        public async Task<ActionResult> InsertNewVehicleCategory
            ([FromServices] IRepository<Category> _categoryRepo,
            [FromBody] CategoryDTO modelDTO)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = modelDTO.Name,
                };
                var inserted = await _categoryRepo.Add(category);
                if (inserted) return Ok();
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete-vehicle-category")]
        public async Task<ActionResult> DeleteVehicleCategory
            ([FromServices] IRepository<Category> _categoryRepo, [FromHeader] string Id)
        {
            if (Id == null) return BadRequest();

            var categoryGet = await _categoryRepo.Get(Id);
            if(categoryGet == null) return BadRequest("Couldn't find this category.");

            var deleted = await _categoryRepo.Remove(categoryGet);
            if (deleted) return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);

        }
        [HttpPost]
        [Route("insert-new-vehicle-brand")]
        public async Task<ActionResult> InsertNewVehicleBrand([FromServices] IRepository<Brand> _brandRepo, [FromBody] BrandDTO brandDTO)
        {
            if (ModelState.IsValid)
            {
                var brandModel = new Brand()
                {
                    Name = brandDTO.Name,
                };
                var inserted = await _brandRepo.Add(brandModel);
                if (inserted) return Ok();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete-vehicle-brand")]
        public async Task<ActionResult> DeleteVehicleBrand([FromServices] IRepository<Brand> _repo, [FromHeader] string Id)
        {
            if (string.IsNullOrWhiteSpace(Id)) return BadRequest("Header Parameter ID: can not be null or empty");

            var brandGet = await _repo.Get(Id);
            if (brandGet == null) return BadRequest("The brand can not be found.");

            var deleted = await _repo.Remove(brandGet);
            if (deleted) return Ok("Deleted");

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpPost]
        [Route("insert-new-vehicle-model")]
        public async Task<ActionResult> InsertNewVehicleModel([FromServices] IRepository<Model> _repo, [FromBody] ModelDTO carModelDTO)
        {
            if (ModelState.IsValid)
            {
                var model = new Model()
                {
                    Name = carModelDTO.Name,
                    BrandId = carModelDTO.BrandId,
                };
                var inserted = await _repo.Add(model);
                if (inserted) return Ok();

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete-vehicle-model-by-id")]
        public async Task<ActionResult> DeleteVehicleModelById([FromServices] IRepository<Model> _repo, [FromHeader] string Id)
        {
            if (string.IsNullOrWhiteSpace(Id)) return BadRequest("The parameter from Header: 'Id' can not be null");

            var modelGet = await _repo.Get(Id);
            if (modelGet == null) return BadRequest("The server couldn't find the car model with this Id");

            var deleted = await _repo.Remove(modelGet);
            if (deleted) return Ok();

            return StatusCode(StatusCodes.Status500InternalServerError);

        }



    }
}
