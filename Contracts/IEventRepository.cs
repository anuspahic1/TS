
namespace Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync(Guid locationId, EventParameters eventParameters, bool trackChanges);
        Task<Event> GetEventAsync(Guid locationId, Guid id, bool trackChanges);
        void CreateEventForLocation(Guid locationId, Event ev);
        void DeleteEvent(Event ev);
    }
}
