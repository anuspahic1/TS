using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
    }
}
