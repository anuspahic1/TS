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
        public IActionResult GetLocations()
        {
            var locations = _service.LocationService.GetAllLocations(trackChanges: false);
            return Ok(locations);
        }

        [HttpGet("{id:guid}", Name = "LocationById")]
        public IActionResult GetLocation(Guid id)
        {
            var location = _service.LocationService.GetLocation(id, trackChanges: false);
            return Ok(location);
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody] LocationForCreationDto location)
        {
            if (location is null)
                return BadRequest("LocationForCreationDto is null.");

            var createdLocation = _service.LocationService.CreateLocation(location);
            return CreatedAtRoute("LocationById", new { id = createdLocation.Id }, createdLocation);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteLocation(Guid id)
        {
            _service.LocationService.DeleteLocation(id, trackChanges: false);
            return NoContent();
        }
    }
}
