using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/locations/{locationId}/events/{eventId}/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ReservationsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetReservations(Guid locationId, Guid eventId)
        {
            var reservations = _service.ReservationService.GetReservations(locationId, eventId, trackChanges: false);
            return Ok(reservations);
        }

        [HttpGet("{id:guid}", Name = "GetReservationForEvent")]
        public IActionResult GetReservation(Guid locationId, Guid eventId, Guid id)
        {
            var reservation = _service.ReservationService.GetReservation(locationId, eventId, id, trackChanges: false);

            return Ok(reservation);
        }

        [HttpPost]
        public IActionResult CreateReservation(Guid locationId, Guid eventId, [FromBody] ReservationForCreationDto reservation)
        {
            if (reservation is null)
                return BadRequest("ReservationForCreationDto is null.");

            var createdReservation = _service.ReservationService.CreateReservationForEvent(locationId, eventId, reservation, trackChanges: true);

            return CreatedAtRoute("GetReservationForEvent", new { locationId, eventId, id = createdReservation.Id }, createdReservation);
        }
    }
}
