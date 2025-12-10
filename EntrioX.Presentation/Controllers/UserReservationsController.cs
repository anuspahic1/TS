using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/users/{userId}/reservations")]
    [ApiController]
    public class UserReservationsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UserReservationsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetReservationsForUser(Guid userId)
        {
            var reservations = _service.ReservationService.GetReservationsForUser(userId, false);
            return Ok(reservations);
        }
    }
}
