using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetAllReservations(bool trackChanges);
        IEnumerable<ReservationDto> GetReservationsForEvent(Guid eventId, bool trackChanges);
        IEnumerable<ReservationDto> GetReservationsForUser(Guid userId, bool trackChanges);
        ReservationDto GetReservation(Guid reservationId, bool trackChanges);
    }
}
