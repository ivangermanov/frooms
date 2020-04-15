using Froom.Data.Models.Buildings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
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
        public async Task<IActionResult> GetBuildingsForCampus(string campusName)
        {
            return Ok(await _buildingService.GetBuildingsForCampus(campusName));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            await _buildingService.RemoveBuilding(id);

            return Ok();
        }
    }
}
