using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetAllReservations(bool trackChanges);
        ReservationDto GetReservation(Guid reservationId, bool trackChanges);
    }
}
