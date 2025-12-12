namespace Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync(Guid locationId, bool trackChanges);
        Task<Event> GetEventAsync(Guid locationId, Guid id, bool trackChanges);
        void CreateEventForLocation(Guid locationId, Event ev);
        void DeleteEvent(Event ev);
    }
}
