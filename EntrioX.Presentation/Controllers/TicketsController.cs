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
            try
            {
                var tickets = _service.TicketService.GetAllTickets(trackChanges: false);
                return Ok(tickets);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
