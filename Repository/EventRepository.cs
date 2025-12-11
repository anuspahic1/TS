using Contracts;
using Entities.Models;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Event> GetEvents(Guid locationId, bool trackChanges)
        {
            return FindByCondition(e => e.LocationId.Equals(locationId), trackChanges)
                    .OrderBy(e => e.Name)
                    .ToList();
        }

        public Event GetEvent(Guid locationId, Guid id, bool trackChanges)
        {
            return FindByCondition(e => e.LocationId.Equals(locationId) && 
                                   e.Id.Equals(id), trackChanges)
                   .SingleOrDefault();
        }

        public void CreateEventForLocation(Guid locationId, Event ev)
        {
            ev.LocationId = locationId;
            Create(ev);
        }
    }
}
