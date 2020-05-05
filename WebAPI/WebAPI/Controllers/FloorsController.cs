using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/floors")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        // TODO: Filter by campusName AND buildingName, not only buildingName
        [HttpGet]
        public async Task<IActionResult> GetFloors(string buildingName)
        {
            return Ok(await _floorService.GetFloors(buildingName));
        }
    }
}