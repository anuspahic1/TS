using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTicketsAsync(Guid locationId, Guid eventId, bool trackChanges);
        Task<TicketDto> GetTicketAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        Task<TicketDto> CreateTicketForEventAsync(Guid locationId, Guid eventId, TicketForCreationDto ticket, bool trackChanges);
        Task DeleteTicketForEventAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        Task UpdateTicketForEventAsync(Guid locationId, Guid eventId, Guid id, TicketForUpdateDto ticket, bool locationTrackChanges, bool eventTrackChanges, bool ticketTrackChanges);
        Task<(TicketForUpdateDto ticketToPatch, Guid ticketId)> GetTicketForPatchAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        Task SaveChangesForPatchAsync(TicketForUpdateDto ticketToPatch, Guid locationId, Guid eventId, Guid id, bool trackChanges);
    }
}
