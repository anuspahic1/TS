using Entities.Models;

namespace Contracts
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents(bool trackChanges);
        IEnumerable<Event> GetEventsForLocation(Guid locationId, bool trackChanges);
        Event GetEvent(Guid eventId, bool trackChanges);
        void CreateEvent(Event ev);
    }
}
