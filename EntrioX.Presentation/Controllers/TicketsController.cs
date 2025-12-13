using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/locations/{locationId}/events/{eventId}/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TicketsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets(Guid locationId, Guid eventId)
        {
            var tickets = await _service.TicketService.GetTicketsAsync(locationId, eventId, trackChanges: false);
            return Ok(tickets);
        }

        [HttpGet("{id:guid}", Name = "GetTicketForEvent")]
        public async Task<IActionResult> GetTicket(Guid locationId, Guid eventId, Guid id)
        {
            var ticket = await _service.TicketService.GetTicketAsync(locationId, eventId, id, trackChanges: false);
            return Ok(ticket);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTicket(Guid locationId, Guid eventId, [FromBody] TicketForCreationDto ticket)
        {
            var createdTicket = await _service.TicketService.CreateTicketForEventAsync(locationId, eventId, ticket, trackChanges: false);

            return CreatedAtRoute("GetTicketForEvent", new { locationId, eventId, id = createdTicket.Id }, createdTicket);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTicket(Guid locationId, Guid eventId, Guid id)
        {
            await _service.TicketService.DeleteTicketForEventAsync(locationId, eventId, id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateTicket(Guid locationId, Guid eventId, Guid id, [FromBody] TicketForUpdateDto ticket)
        {
            await _service.TicketService.UpdateTicketForEventAsync(locationId, eventId, id, ticket, locationTrackChanges: false, eventTrackChanges: false, ticketTrackChanges: true);
            return NoContent();
        }
    }
}
