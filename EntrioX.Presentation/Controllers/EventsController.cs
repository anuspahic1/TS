using EntrioX.Presentation.ActionFilters;
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
        public async Task<IActionResult> GetEventsForLocation(Guid locationId)
        {
            var events = await _service.EventService.GetEventsAsync(locationId, trackChanges: false);
            return Ok(events);
        }

        [HttpGet("{id:guid}", Name = "GetEventForLocation")]
        public async Task<IActionResult> GetEventForLocation(Guid locationId, Guid id)
        {
            var ev = await _service.EventService.GetEventAsync(locationId, id, trackChanges: false);
            return Ok(ev);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEventForLocation(Guid locationId, [FromBody] EventForCreationDto ev)
        {
            var eventToReturn = await _service.EventService.CreateEventForLocationAsync(locationId, ev, trackChanges: false);

            return CreatedAtRoute("GetEventForLocation", new { locationId, id = eventToReturn.Id }, eventToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEvent(Guid locationId, Guid id)
        {
            await _service.EventService.DeleteEventForLocationAsync(locationId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEventForLocation(Guid locationId, Guid id, [
            FromBody] EventForUpdateDto eventForUpdate)
        {
            await _service.EventService.UpdateEventForLocationAsync(locationId, id, eventForUpdate, trackChanges: true);
            return NoContent();
        }
    }
}
