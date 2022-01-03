using Domain.Rent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesGetController : ControllerBase
    {
        [HttpGet]
        [Route("get-all-vehicles")]
        public async Task<ActionResult> GetAllVehicles()
        {
            return BadRequest();
        }
        [HttpGet]
        [Route("get-vehicle-by-id")]
        public async Task<ActionResult> GetVehicleById([FromHeader] string vehicleId)
        {
            return BadRequest();
        }
        [HttpGet]
        [Route("get-vehicles-by-fuel")]
        public async Task<ActionResult> GetVehiclesByFuel([FromHeader] string? fuelId, [FromHeader] string? fuelName)
        {
            return BadRequest();
        }
        [HttpGet]
        [Route("get-vehicles-by-brand")]
        public async Task<ActionResult> GetVehiclesByBrand([FromHeader] string? brandId, [FromHeader] string? brandName)
        {
            return BadRequest();
        }
        [HttpGet]
        [Route("get-vehicles-by-model")]
        public async Task<ActionResult> GetVehiclesByModel([FromHeader] string? modelId, [FromHeader] string? modelName)
        {
            return BadRequest();
        }
        [HttpGet]
        [Route("get-vehicles-by-category")]
        public async Task<ActionResult> GetVehiclesByCategory([FromHeader] string? categoryId, [FromHeader] string? categoryName)
        {
            return BadRequest();
        }
        [HttpGet]
        [Route("get-all-brands")]
        public async Task<ActionResult> GetAllBrands([FromServices] IRepository<Brand> _brandRepo)
        {
            var brands = await _brandRepo.GetAll();
            return Ok(brands);
        }
        [HttpGet]
        [Route("get-brand-by-id")]
        public async Task<ActionResult> GetBrandById([FromHeader] string Id, [FromServices] IRepository<Brand> _brandRepo)
        {
            var brand = await _brandRepo.Get(Id);
            if (brand == null) return BadRequest();

            return Ok(brand);
        }
        [HttpGet]
        [Route("get-all-models")]
        public async Task<ActionResult> GetAllModels([FromServices] IRepository<Model> _modelRepo)
        {
            var models = await _modelRepo.GetAll();
            return Ok(models);
        }
        [HttpGet]
        [Route("get-model-by-id")]
        public async Task<ActionResult> GetModelById([FromHeader] string Id, [FromServices] IRepository<Model> _modelRepo)
        {
            var model = await _modelRepo.Get(Id);
            if (model == null) return BadRequest();
            return Ok(model);
        }
        [HttpGet]
        [Route("get-model-by-name")]
        public async Task<ActionResult> GetModelByName([FromHeader] string filter, [FromServices] IRepository<Model> _modelRepo)
        {
            return Ok();
        }
        [HttpGet]
        [Route("get-all-categories")]
        public async Task<ActionResult> GetAllCategories([FromServices] IRepository<Category> _categoryRepo)
        {
            return Ok(await _categoryRepo.GetAll());
        }
        [HttpGet]
        [Route("get-categories-by-id")]
        public async Task<ActionResult> GetCategoryById
            ([FromServices] IRepository<Category> _categoryRepo,
            [FromHeader] string Id)
        {
            if (Id == null) return BadRequest();
            var categoryGet = await _categoryRepo.Get(Id);
            if(categoryGet == null) return BadRequest();

            return Ok(categoryGet);
        }
        [HttpGet]
        [Route("get-all-fuel-types")]
        public async Task<ActionResult> GetFuelTypes([FromServices] IRepository<FuelType> _fuelRepo)
        {
            return Ok(await _fuelRepo.GetAll());
        }
        [HttpGet]
        [Route("get-fuel-type-by-id")]
        public async Task<ActionResult> GetFuelTypeById([FromServices] IRepository<FuelType> _fuelRepo,
            [FromHeader] string Id)
        {
            return Ok(await _fuelRepo.Get(Id));
        }
    }
}
