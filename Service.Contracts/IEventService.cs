using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync(Guid locationId, EventParameters eventParameters, bool trackChanges);
        Task<EventDto> GetEventAsync(Guid locationId, Guid id, bool trackChanges);
        Task<EventDto> CreateEventForLocationAsync(Guid locationId, EventForCreationDto eventForCreation, bool trackChanges);
        Task DeleteEventForLocationAsync(Guid locationId, Guid id, bool trackChanges);
        Task UpdateEventForLocationAsync(Guid locationId, Guid id, EventForUpdateDto eventForUpdate, bool trackChanges);
        Task<(EventForUpdateDto eventToPatch, Guid eventId)> GetEventForPatchAsync(Guid locationId, Guid id, bool trackChanges);
        Task SaveChangesForPatchAsync(EventForUpdateDto eventToPatch, Guid locationId, Guid id, bool trackChanges);
    }
}
