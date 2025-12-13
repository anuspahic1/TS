using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public LocationsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _service.LocationService.GetAllLocationsAsync(trackChanges: false);
            return Ok(locations);
        }

        [HttpGet("{id:guid}", Name = "LocationById")]
        public async Task<IActionResult> GetLocation(Guid id)
        {
            var location = await _service.LocationService.GetLocationAsync(id, trackChanges: false);
            return Ok(location);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateLocation([FromBody] LocationForCreationDto location)
        {
            var createdLocation = await _service.LocationService.CreateLocationAsync(location);

            return CreatedAtRoute("LocationById", new { id = createdLocation.Id }, createdLocation);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            await _service.LocationService.DeleteLocationAsync(id, trackChanges: false);
            return NoContent();
        }
    }
}
