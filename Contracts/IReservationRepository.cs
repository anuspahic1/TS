using Entities.Models;

namespace Contracts
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetReservations(Guid locationId, Guid eventId, bool trackChanges);
        Reservation GetReservation(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        void CreateReservationForEvent(Guid eventId, Reservation reservation);
    }
}
