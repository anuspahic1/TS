using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetReservations(Guid locationId, Guid eventId, bool trackChanges);
        ReservationDto GetReservation(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        ReservationDto CreateReservationForEvent(Guid locationId, Guid eventId, ReservationForCreationDto reservation, bool trackChanges);       
    }
}
