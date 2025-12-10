using Shared.DataTransferObjects;
using System;

namespace Service.Contracts
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetAllEvents(bool trackChanges);
        IEnumerable<EventDto> GetEventsForLocation(Guid locationId, bool trackChanges);
        EventDto GetEvent(Guid eventId, bool trackChanges);
        EventDto CreateEvent(EventForCreationDto ev);
    }
}
