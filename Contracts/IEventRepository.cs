using Entities.Models;

namespace Contracts
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents(Guid locationId, bool trackChanges);
        Event GetEvent(Guid locationId, Guid id, bool trackChanges);
        void CreateEventForLocation(Guid locationId, Event ev);
        void DeleteEvent(Event ev);
    }
}
