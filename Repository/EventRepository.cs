using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Event>> GetEventsAsync(Guid locationId, EventParameters eventParameters, bool trackChanges)
        {
        return await FindByCondition(e => e.LocationId.Equals(locationId), trackChanges)
            .Include(e => e.Location) 
            .OrderBy(e => e.Name)
            .Skip((eventParameters.PageNumber - 1) * eventParameters.PageSize)
            .Take(eventParameters.PageSize)
            .Sort(eventParameters.OrderBy)
            .Search(eventParameters.SearchTerm)
            .ToListAsync(); 
        }

        public async Task<Event> GetEventAsync(Guid locationId, Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.LocationId.Equals(locationId) && e.Id.Equals(id), trackChanges)
                .Include(e => e.Location) 
                .SingleOrDefaultAsync();
        }

        public void CreateEventForLocation(Guid locationId, Event ev)
        {
            ev.LocationId = locationId;
            Create(ev);
        }

        public void DeleteEvent(Event ev)
        {
            Delete(ev);
        }
        public async Task<int> GetTotalEventsCountAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).CountAsync();
        }
    }
}
