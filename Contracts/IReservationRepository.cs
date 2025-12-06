using Entities.Models;

namespace Contracts
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAllReservations(bool trackChanges);
        Reservation GetReservation(Guid reservationId, bool trackChanges);
    }
}
