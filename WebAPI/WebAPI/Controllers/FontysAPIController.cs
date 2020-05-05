using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/fontys")]
    [ApiController]
    public class FontysAPIController : ControllerBase
    {
        private readonly FontysAPI _fontysApi;

        public FontysAPIController(FontysAPI fontysApi)
        {
            _fontysApi = fontysApi;
        }

        #region Buildings
        [HttpGet]
        [Route("buildings")]
        public async Task<IActionResult> GetBuildings()
        {
            var result = await _fontysApi.GetBuildings();
            return Ok(result);
        }
        #endregion

        #region Location
        [HttpGet]
        [Route("location/mapimage/{campusName}/{buildingName}/{floorNumber}")]
        public async Task<IActionResult> GetLocationMapImage(string campusName, string buildingName, string floorNumber)
        {
            var result = await _fontysApi.GetLocationMapImage(campusName, buildingName, floorNumber);
            
            return File(result, "image/png");
        }

        [HttpGet]
        [Route("location/floor-statistics")]
        public async Task<IActionResult> GetLocationFloorStatistics()
        {
            var result = await _fontysApi.GetLocationFloorStatistics();
            return Ok(result);
        }
        #endregion
    }
}