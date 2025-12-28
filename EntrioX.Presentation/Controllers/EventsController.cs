using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetEventsForLocation(Guid locationId, [FromQuery] EventParameters eventParameters)
        {
            var events = await _service.EventService.GetEventsAsync(locationId, eventParameters, trackChanges: false);
            return Ok(events);
        }
        

        [HttpGet("{id:guid}", Name = "GetEventForLocation")]
        public async Task<IActionResult> GetEventForLocation(Guid locationId, Guid id)
        {
            var ev = await _service.EventService.GetEventAsync(locationId, id, trackChanges: false);
            return Ok(ev);
        }

        [HttpPost]
        [Authorize(Policy = "OrganizerAccess")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEventForLocation(Guid locationId, [FromBody] EventForCreationDto ev)
        {
            var eventToReturn = await _service.EventService.CreateEventForLocationAsync(locationId, ev, trackChanges: false);

            return CreatedAtRoute("GetEventForLocation", new { locationId, id = eventToReturn.Id }, eventToReturn);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "OrganizerAccess")]
        public async Task<IActionResult> DeleteEvent(Guid locationId, Guid id)
        {
            await _service.EventService.DeleteEventForLocationAsync(locationId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "OrganizerAccess")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEventForLocation(Guid locationId, Guid id, [
            FromBody] EventForUpdateDto eventForUpdate)
        {
            await _service.EventService.UpdateEventForLocationAsync(locationId, id, eventForUpdate, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        [Authorize(Policy = "OrganizerAccess")]
        public async Task<IActionResult> PartiallyUpdateEventForLocation(Guid locationId, Guid id
            , [FromBody] JsonPatchDocument<EventForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object is null");

            var (eventToPatch, eventId) = await _service.EventService
                .GetEventForPatchAsync(locationId, id, trackChanges: true);

            patchDoc.ApplyTo(eventToPatch);

            if (!TryValidateModel(eventToPatch))
                return UnprocessableEntity(ModelState);

            await _service.EventService.SaveChangesForPatchAsync(eventToPatch, locationId, id, trackChanges: true);

            return NoContent();
        }
    }
}
