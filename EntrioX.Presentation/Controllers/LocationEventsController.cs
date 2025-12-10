using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/locations/{locationId}/events")]
    [ApiController]
    public class LocationEventsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public LocationEventsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEventsForLocation(Guid locationId)
        {
            var events = _service.EventService.GetEventsForLocation(locationId, false);
            return Ok(events);
        }
    }
}
