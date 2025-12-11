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
        public IActionResult GetTickets(Guid locationId, Guid eventId)
        {
            var tickets = _service.TicketService.GetTickets(locationId, eventId, trackChanges: false);
            return Ok(tickets);
        }

        [HttpGet("{id:guid}", Name = "GetTicketForEvent")]
        public IActionResult GetTicket(Guid locationId, Guid eventId, Guid id)
        {
            var ticket = _service.TicketService.GetTicket(locationId, eventId, id, trackChanges: false);
            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult CreateTicket(Guid locationId, Guid eventId, [FromBody] TicketForCreationDto ticket)
        {
            if (ticket is null)
                return BadRequest("TicketForCreationDto is null.");

            var createdTicket = _service.TicketService.CreateTicketForEvent(locationId, eventId, ticket, trackChanges: false);

            return CreatedAtRoute("GetTicketForEvent", new { locationId, eventId, id = createdTicket.Id }, createdTicket);
        }
    }
}
