namespace Contracts
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationsAsync(Guid locationId, Guid eventId, bool trackChanges);
        Task<Reservation> GetReservationAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        void CreateReservationForEvent(Guid eventId, Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Task<int> GetTotalBookingsCountAsync(bool trackChanges);

        Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(Guid userId, bool trackChanges);
        Task<IEnumerable<Reservation>> GetReservationsByUserIdWithDetailsAsync(Guid userId, bool trackChanges);
        Task<IEnumerable<EventVisitorDto>> GetEventVisitorsAsync(Guid locationId, Guid eventId, bool trackChanges);
    }
}
