using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/events/{eventId}/reservations")]
    [ApiController]
    public class EventReservationsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EventReservationsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetReservationsForEvent(Guid eventId)
        {
            var reservations = _service.ReservationService.GetReservationsForEvent(eventId, false);
            return Ok(reservations);
        }
    }
}
