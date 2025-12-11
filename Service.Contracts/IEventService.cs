using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetEvents(Guid locationId, bool trackChanges);
        EventDto GetEvent(Guid locationId, Guid id, bool trackChanges);
        EventDto CreateEventForLocation(Guid locationId, EventForCreationDto eventForCreation, bool trackChanges);
    }
}
