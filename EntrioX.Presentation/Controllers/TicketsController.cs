using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TicketsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            var tickets = _service.TicketService.GetAllTickets(trackChanges: false);
            return Ok(tickets);
        }

        [HttpGet("{id:guid}", Name = "TicketById")]
        public IActionResult GetTicket(Guid id)
        {
            var ticket = _service.TicketService.GetTicket(id, trackChanges: false);
            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody] TicketForCreationDto ticket)
        {
            if (ticket is null)
                return BadRequest("TicketForCreationDto is null.");

            var createdTicket = _service.TicketService.CreateTicket(ticket);
            return CreatedAtRoute("TicketById", new { id = createdTicket.Id }, createdTicket);
        }
    }
}
