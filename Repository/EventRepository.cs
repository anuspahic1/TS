using Contracts;
using Entities.Models;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Event> GetAllEvents(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(e => e.Name)
                .ToList();
        }

        public Event GetEvent(Guid eventId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(eventId), trackChanges)
                   .SingleOrDefault();
        }
    }
}
