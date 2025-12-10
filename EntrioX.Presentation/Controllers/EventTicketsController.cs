using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/events/{eventId}/tickets")]
    [ApiController]
    public class EventTicketsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EventTicketsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTicketsForEvent(Guid eventId)
        {
            var tickets = _service.TicketService.GetTicketsForEvent(eventId, false);
            return Ok(tickets);
        }
    }
}
