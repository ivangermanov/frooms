using Froom.Data.Entities;
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

        [Route("addBuilding")]
        [HttpPost]
        public async Task<IActionResult> AddBuilding(PostBuildingModel model)
        {
            await _buildingService.AddBuildingAsync(model);

            return Ok();
        }

        [Route("addFloor")]
        [HttpPost]
        public async Task<IActionResult> AddFloor(string buildingName, string floorNumber)
        {
            await _buildingService.AddFloorAsync(buildingName, floorNumber);

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
