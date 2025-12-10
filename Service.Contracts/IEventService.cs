using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetAllEvents(bool trackChanges);
        IEnumerable<EventDto> GetEventsForLocation(Guid locationId, bool trackChanges);
        EventDto GetEvent(Guid eventId, bool trackChanges);
    }
}
