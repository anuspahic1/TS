using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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

        [HttpGet("{id:guid}")]
        public IActionResult GetLocation(Guid id)
        {
            var location = _service.LocationService.GetLocation(id, trackChanges: false);
            return Ok(location);
        }
    }
}
