using Entities.Models;

namespace Contracts
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAllReservations(bool trackChanges);
        IEnumerable<Reservation> GetReservationsForEvent(Guid eventId, bool trackChanges);
        IEnumerable<Reservation> GetReservationsForUser(Guid userId, bool trackChanges);
        Reservation GetReservation(Guid reservationId, bool trackChanges);
        void CreateReservation(Reservation reservation);
    }
}
