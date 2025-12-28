using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetReservations(Guid locationId, Guid eventId)
        {
            var reservations = await _service.ReservationService.GetReservationsAsync(locationId, eventId, trackChanges: false);
            return Ok(reservations);
        }

        [HttpGet("{id:guid}", Name = "GetReservationForEvent")]
        public async Task<IActionResult> GetReservation(Guid locationId, Guid eventId, Guid id)
        {
            var reservation = await _service.ReservationService.GetReservationAsync(locationId, eventId, id, trackChanges: false);

            return Ok(reservation);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateReservation(Guid locationId, Guid eventId, [FromBody] ReservationForCreationDto reservation)
        {
            var createdReservation = await _service.ReservationService.CreateReservationForEventAsync(locationId, eventId, reservation, trackChanges: true);

            return CreatedAtRoute("GetReservationForEvent", new { locationId, eventId, id = createdReservation.Id }, createdReservation);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReservation(Guid locationId, Guid eventId, Guid id)
        {
            await _service.ReservationService.DeleteReservationForEventAsync(locationId, eventId, id, trackChanges: false);
            return NoContent();
        }
        [HttpGet("visitors")]
        public async Task<IActionResult> GetEventVisitors(
            Guid locationId,
            Guid eventId)
        {
            var visitors = await _service.ReservationService
                .GetEventVisitorsAsync(locationId, eventId, trackChanges: false);

            return Ok(visitors);
        }
    }
}
