using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/locations/{locationId}/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EventsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEventsForLocation(Guid locationId) 
        {
            var events = _service.EventService.GetEvents(locationId, trackChanges: false);
            return Ok(events);
        }

        [HttpGet("{id:guid}", Name = "GetEventForLocation")]
        public IActionResult GetEventForLocation(Guid locationId, Guid id)
        {
            var ev = _service.EventService.GetEvent(locationId, id, trackChanges: false);
            return Ok(ev);
        }

        [HttpPost]
        public IActionResult CreateEventForLocation(Guid locationId, [FromBody] EventForCreationDto ev)
        {
            if (ev is null)
                return BadRequest("EventForCreationDto is null.");

            var eventToReturn = _service.EventService.CreateEventForLocation(locationId, ev, trackChanges: false);

            return CreatedAtRoute("GetEventForLocation", new { id = eventToReturn.Id }, eventToReturn);
        }
    }
}
