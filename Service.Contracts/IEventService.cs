using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync(Guid locationId, bool trackChanges);
        Task<EventDto> GetEventAsync(Guid locationId, Guid id, bool trackChanges);
        Task<EventDto> CreateEventForLocationAsync(Guid locationId, EventForCreationDto eventForCreation, bool trackChanges);
        Task DeleteEventForLocationAsync(Guid locationId, Guid id, bool trackChanges);
    }
}
