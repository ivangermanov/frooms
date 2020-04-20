using Froom.Data.Models.Campuses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/campuses")]
    [ApiController]
    public class CampusesController : ControllerBase
    {
        readonly ICampusService _campusService;

        public CampusesController(ICampusService campusService)
        {
            _campusService = campusService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCampus(PostCampusModel model)
        {
            await _campusService.AddCampusAsync(model);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCampuses()
        {
            return Ok(await _campusService.GetCampuses());
        }

        [HttpGet]
        [Route("names")]
        public async Task<IActionResult> GetCampusNames()
        {
            return Ok(await _campusService.GetCampusNames());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCampus(string name)
        {
            await _campusService.RemoveCampus(name);

            return Ok();
        }
    }
}
