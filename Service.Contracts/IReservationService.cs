using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetReservationsAsync(Guid locationId, Guid eventId, bool trackChanges);
        Task<ReservationDto> GetReservationAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        Task<ReservationDto> CreateReservationForEventAsync(Guid locationId, Guid eventId, ReservationForCreationDto reservation, bool trackChanges);
        Task DeleteReservationForEventAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);

        Task<IEnumerable<ReservationDto>> GetReservationsByUserIdAsync(Guid userId, bool trackChanges);
    }
}
