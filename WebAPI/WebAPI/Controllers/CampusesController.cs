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

        // TODO: Just return campus names
        [HttpGet]
        public async Task<IActionResult> GetCampuses()
        {
            return Ok(await _campusService.GetCampuses());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCampus(string name)
        {
            await _campusService.RemoveCampus(name);

            return Ok();
        }
    }
}
