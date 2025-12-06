using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ReservationsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            var reservations = _service.ReservationService.GetAllReservations(trackChanges: false);
            return Ok(reservations);
        }
    }
}
