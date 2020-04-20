using Froom.Data.Models.Buildings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        readonly IBuildingService _buildingService;

        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding(PostBuildingModel model)
        {
            await _buildingService.AddBuildingAsync(model);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildings(string? campusName)
        {
            return Ok(await _buildingService.GetBuildings(campusName));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            await _buildingService.RemoveBuilding(id);

            return Ok();
        }
    }
}
